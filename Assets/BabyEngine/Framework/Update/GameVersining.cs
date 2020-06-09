using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace BabyEngine {
    public class GameVersining {
        public int Version = 0;
        private List<ResourceData> resourceDatas = new List<ResourceData>();
        public bool hasError;
        public void Add(ResourceData resourceData) {
            resourceDatas.Add(resourceData);
            resourceDatas = resourceDatas.Distinct().ToList();
        }

        public GameVersining ToVersion(GameVersining webVersion) {
            var myVer = GetResourceMap();
            var webVer = webVersion.GetResourceMap();
            // 1. 计算新增的文件
            List<ResourceData> addList = new List<ResourceData>();
            foreach (var item in webVer) {
                if (!myVer.ContainsKey(item.Key)) { // 远程有, 本地没有的
                    addList.Add(item.Value);
                }
            }
            // 2. 计算被删除的文件
            List<ResourceData> delList = new List<ResourceData>();
            foreach (var item in myVer) {
                if (!webVer.ContainsKey(item.Key)) { // 本地有, 远程没有的
                    delList.Add(item.Value);
                }
            }
            // 3. 计算hash不一致的文件
            List<ResourceData> diffList = new List<ResourceData>();
            foreach (var item in webVer) {
                if (myVer.ContainsKey(item.Key)) { // 远程有, 本地也要有
                    var locItem = myVer[item.Key];
                    if (locItem.Hash != item.Value.Hash) { // 对比Hash是否一致
                        diffList.Add(item.Value);
                    }
                }
            }
            // 4. 删除本地文件 TODO
            // 5. 计算出diff ver
            var tmpList = new List<ResourceData>();
            tmpList.AddRange(addList);
            tmpList.AddRange(diffList);
            var diffVersion = new GameVersining();
            diffVersion.Version = webVersion.Version;
            diffVersion.resourceDatas.AddRange(tmpList.Distinct().ToArray());

            Debug.Log($"新增文件: {addList.Count} 删除文件: {delList.Count} 差异文件: {diffList.Count}");
            return diffVersion;
        }
        private Dictionary<string, ResourceData> GetResourceMap() {
            Dictionary<string, ResourceData> result = new Dictionary<string, ResourceData>();
            foreach(var r in resourceDatas.Distinct().ToList()) {
                result.Add(r.Path, r);
            }
            return result;
        }

        public int FileCount {
            get {
                return resourceDatas.Count;
            }
        }
        public long SizeCount {
            get {
                long n = 0;
                foreach (var item in resourceDatas) {
                    n += item.Size;
                }
                return n;
            }
        }

        public string SizeString {
            get {
                return SizeCount.ToByteSize();
            }
        }
        public float Progress {
            get {
                return ((float)downloadSize / (float)(SizeCount));
            }
        }
        private ulong downloadSize {
            get {
                if (www == null) {
                    return downloadedSize;
                }
                return downloadedSize + www.downloadedBytes;
            }
        }
        private ulong downloadedSize = 0;
        private UnityWebRequest www;
        public IEnumerator Download(MonoBehaviour mono, string BaseURL, Action<bool> cb) {
            yield return null;
            downloadedSize = 0;
            foreach (var data in resourceDatas) {
                www = data.Download(BaseURL);
                yield return www.SendWebRequest();
                if (www.isNetworkError) {
                    data.Status = -1; // 发生错误
                }
                if (www.isDone) {
                    data.Status = 1; // 下载完成
                    downloadedSize += www.downloadedBytes;
                    data.Save(www.downloadHandler.data);
                }
            }
            DoInstall(mono, () => { cb(true); });
        }

        public void DoInstall(MonoBehaviour mono, Action cb) {
            foreach (var data in resourceDatas) {
                Debug.Log($"内建安装: {data.assetBundle}");
                data.LoadLocal(mono);
                data.Install();
            }
            cb();
        }
    }
}
