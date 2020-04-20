using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.UI;
using System.Collections.Generic;

namespace BabyEngine {
    /// <summary>
    /// UnityWebRequest 扩展
    /// </summary>
    public static class UnityWebRequestCachingExtensions {
        public static DownloadHandler SetCacheable(this UnityWebRequest www) {
            CacheableDownloadHandler handler = new CacheableDownloadHandler(www, new byte[1024]);
            var etag = ICacheableDownloadHandler.GetCacheEtag(www.url);
            if (etag != null) {
                www.SetRequestHeader("If-None-Match", etag);
            }
            www.downloadHandler = handler;
            return www.downloadHandler;
        }

        public static void LoadImage(this Image image, string url) {
            var mo = image.gameObject.GetComponent<MonoBehaviour>();
            if (!mo.gameObject.activeInHierarchy) {
                Debug.LogWarning("object not active");
                return; 
            }

            mo.StartCoroutine(CacheableDownloadHandler.GetTexture2D(url, (code, header, tex) => {
                if (code == 200 || code == 304) {
                    image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one / 2.0f);
                } else {
                    Debug.LogWarning($"download error: {code} {url}");
                }
            }));
        }
      
        public static void Run(this IEnumerator co, MonoBehaviour mono) {
            if (mono != null) {
                mono.StartCoroutine(co);
            } else {
                Debug.LogError("error");
            }
        }
    }

    /// <summary>
    /// 基于Etag可缓存DownloadHandler
    /// </summary>
    public abstract class ICacheableDownloadHandler : DownloadHandlerScript {
        /// <summary>
        /// 数据后缀
        /// </summary>
        const string kDataSufix = "_d";
        /// <summary>
        /// Etag后缀
        /// </summary>
        const string kEtagSufix = "_e";
        /// <summary>
        /// 缓存地址
        /// </summary>
        static string sWebCachePath;
        /// <summary>
        /// UnityRequest
        /// </summary>
        UnityWebRequest mWebRequest;
        /// <summary>
        /// 内存流
        /// </summary>
        MemoryStream mStream;
        /// <summary>
        /// 最终数据的字节数组
        /// </summary>
        protected byte[] mBuffer = null;
        /// <summary>
        /// 是否加载完成
        /// </summary>
        public new bool isDone { get; private set; } = false;
        /// <summary>
        /// SHA1
        /// </summary>
        static SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="www"></param>
        /// <param name="preallocBuffer"></param>
        internal ICacheableDownloadHandler(UnityWebRequest www, byte[] preallocBuffer) : base(preallocBuffer) {
            this.mWebRequest = www;
            if (preallocBuffer == null) {
                preallocBuffer = new byte[4096];
            }
            mStream = new MemoryStream(preallocBuffer.Length);
        }
        /// <summary>
        /// 根据URL获取本地保存的Etag
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetCacheEtag(string url) {
            var path = GetCachePath(url);
            var infoPath = path + kEtagSufix;
            var dataPath = path + kDataSufix;
            return (File.Exists(infoPath)) && File.Exists(dataPath)
                ? File.ReadAllText(infoPath)
                : null;
        }
        /// <summary>
        /// 根据url获取本地保存路径
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetCachePath(string url) {
            if (string.IsNullOrEmpty(sWebCachePath)) {
                sWebCachePath = Application.temporaryCachePath + "/WebCache/";
            }
            if (!Directory.Exists(sWebCachePath)) {
                Directory.CreateDirectory(sWebCachePath);
            }
            var hash = Convert.ToBase64String(sha1.ComputeHash(Encoding.Default.GetBytes(url)));
            hash = hash.Replace($"{Path.DirectorySeparatorChar}", "").Replace("/", "");
            var path = sWebCachePath + hash;
            return path;
        }
        /// <summary>
        /// 读取cache
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] LoadCache(string url) {
            return File.ReadAllBytes(GetCachePath(url) + kDataSufix);
        }
        /// <summary>
        /// 保存cache
        /// </summary>
        /// <param name="url"></param>
        /// <param name="etag"></param>
        /// <param name="datas"></param>
        public static void SaveCache(string url, string etag, byte[] datas) {
            var path = GetCachePath(url);
            File.WriteAllText(path + kEtagSufix, etag);
            File.WriteAllBytes(path + kDataSufix, datas);
        }

        public static void RemoveCache(string url) {
            var path = GetCachePath(url);
            if (File.Exists(path + kEtagSufix)) {
                File.Delete(path + kEtagSufix);
            }
            if (File.Exists(path + kDataSufix)) {
                File.Delete(path + kDataSufix);
            }
        }

        #region override
        protected override byte[] GetData() {
            var url = mWebRequest.url;
            if (mBuffer == null) {
                switch (mWebRequest.responseCode) {
                    case 304: // 数据没有变化, 直接取本地缓存
                        mBuffer = LoadCache(url);
                        break;
                    case 200: // 数据有变化, 用服务器下发数据覆盖本地缓存
                        mBuffer = mStream.GetBuffer();
                        SaveCache(url, mWebRequest.GetResponseHeader("Etag"), mBuffer);
                        break;
                    default:
                        mBuffer = mStream.GetBuffer();
                        // deleate cache
                        RemoveCache(url);
                        break;
                }
            }
            if (mStream != null) {
                mStream.Dispose();
                mStream = null;
            }
            return mBuffer;
        }
        /// <summary>
        /// 收到数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataLength"></param>
        /// <returns></returns>
        protected override bool ReceiveData(byte[] data, int dataLength) {
            mStream.Write(data, 0, dataLength);
            return true;
        }

        /// <summary>
        /// 读取数据完成
        /// </summary>
        protected override void CompleteContent() {
            base.CompleteContent();
            isDone = true;
        }

        public new void Dispose() {
            base.Dispose();
            if (mStream != null) {
                mStream.Dispose();
                mStream = null;
            }
        }
        #endregion


    }

    /// <summary>
    /// 可缓存 Bytes DownloadHandler
    /// </summary>
    public class CacheableDownloadHandler : ICacheableDownloadHandler {
        public CacheableDownloadHandler(UnityWebRequest www, byte[] preallocBuffer) : base(www, preallocBuffer) {
        }
        #region APIs
        /// <summary>
        /// 获取 Texture2D
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static IEnumerator GetTexture2D(string url, Action<int, Dictionary<string, string>, Texture2D> cb) {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            www.SetCacheable();
            yield return www.SendWebRequest();

            while (!www.isDone)
                yield return true;
            
            if (www.isNetworkError) {
                Debug.Log(": Error: " + www.error);
                cb(-1, null, null);
                yield break;
            }

            if (www.isHttpError) {
                Debug.Log(": Error: " + www.error);
                cb((int)www.responseCode, www.GetResponseHeaders(), null);
                yield break;
            }

            var tex = new Texture2D(1, 1);
            tex.LoadImage(www.downloadHandler.data, true);
            cb((int)www.responseCode, www.GetResponseHeaders(), tex);
        }

        public static IEnumerator GetBytes(string url, Action<int, Dictionary<string, string>, byte[]> cb) {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            while (!www.isDone)
                yield return true;
          
            if (www.isNetworkError) {
                Debug.Log(": Error: " + www.error);
                cb((int)www.responseCode, www.GetResponseHeaders(), null);
                yield break;
            }
            cb((int)www.responseCode, www.GetResponseHeaders(), www.downloadHandler.data);
        }

        #endregion
    }
}