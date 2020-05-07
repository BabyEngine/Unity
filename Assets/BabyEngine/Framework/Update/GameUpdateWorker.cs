using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace BabyEngine {
    /// <summary>
    /// 游戏更新检查
    /// </summary>
    public class GameUpdateWorker : MonoBehaviour {
        [SerializeField] private string baseURL  = string.Empty;
        private string webData;
        private GameVersining currentDownloadVersioning;
        public GameVersining NewVersion {
            get {
                return currentDownloadVersioning;
            }
        }
        internal void CheckVersioning(Action<string> onErr, Action onLatestVersion, Action onFoundUpdateVersion) {
            StartCoroutine(CheckStartup(onErr, onLatestVersion, onFoundUpdateVersion));
        }

        private IEnumerator CheckStartup(Action<string> onErr, Action onLatestVersion, Action onFoundUpdateVersion) {
            yield return null;
          
            var co = CacheableDownloadHandler.GetText(baseURL + "/update.txt", CacheOption.kNotCache, (statusCode, header, body) => {
                switch (statusCode) {
                    case 200: // use new data=
                        webData = body;
                        ParseStartupData(onLatestVersion, onFoundUpdateVersion);
                        break;
                    case 304: // use cache daeta
                        ParseStartupData(onLatestVersion, onFoundUpdateVersion);
                        break;
                    default:  // not respect this
                        onErr($"http ${statusCode}");
                        break;
                }
            });
            StartCoroutine(co);
        }
        
        private void ParseStartupData(Action onLatestVersion, Action onFoundUpdateVersion) {
            string locData = string.Empty;
            string locPath = $"{Application.persistentDataPath}/update.txt";
            if (File.Exists(locPath)) {
                locData = File.ReadAllText(locPath);
            }
            var webVersion = new GameUpdateParser(webData).Parse();
            var locVersion = new GameUpdateParser(locData).Parse();

            Debug.Log($"本地版本:{locVersion.Version} 线上版本:{webVersion.Version}");
            if (locVersion.Version == webVersion.Version) {
                onLatestVersion?.Invoke();
            } else {
                // 需要更新
                var diffVersion = locVersion.ToVersion(webVersion);
                Debug.Log($"版本 {diffVersion.Version} 差异文件数量: {diffVersion.FileCount} 文件大小: {diffVersion.SizeString}");
                currentDownloadVersioning = diffVersion;
                onFoundUpdateVersion?.Invoke();
            }
        }

        public void StartDownload(Action<bool> action) {
            if (currentDownloadVersioning == null) {
                return;
            }
            
            StartCoroutine(currentDownloadVersioning.Download(baseURL, (ok) => {
                if (ok) { // 如果都下载成功了 就保存版本信息
                    string locPath = $"{Application.persistentDataPath}/update.txt";
                    File.WriteAllText(locPath, webData);
                }
                action?.Invoke(ok);
            }));
        }
        
        public float Progress {
            get {
                if (currentDownloadVersioning == null) {
                    return 0;
                } else {
                    return currentDownloadVersioning.Progress;
                }
            }
        }
    }
}
