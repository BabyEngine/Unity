using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BabyEngine {
    public class GameUpdateParser {
        Dictionary<string, Action<UpdateAction>> executor = new Dictionary<string, Action<UpdateAction>>();
        string baseURL;
        MonoBehaviour mono;
        Dictionary<UpdateAction, int> runningActions = new Dictionary<UpdateAction, int>();
        private string currentUpdateVersion = string.Empty;
        private string currentVersion;
        private string localVersion;
        public GameUpdateParser(MonoBehaviour mono, string baseURL) {
            this.mono = mono;
            this.baseURL = baseURL;

            //executor["version"] = OnVersion;
            //executor["inc"]     = OnInclude;
            executor["lua"]     = OnLua;
            executor["res"]     = OnRes;
        }

        private void PerfomDownload(string url, Action<int, Dictionary<string, string>, AssetBundle, string> cb) {
            CacheableDownloadHandler.GetAssetBundle(url, true, (code, header, ab, path) => {
                cb(code, header, ab, path);
                if (code == 200 || code == 304) {
                    long size = 0;
                    if (header.ContainsKey("Content-Length")) {
                        long.TryParse(header["Content-Length"], out size);
                    }
                    Debug.LogWarning($"下载成功: {code} {url} 剩余文件数量:{GetFileLeft()} 本次流量:{size}");
                } else {
                    Debug.LogWarning($"下载失败:{code} {url}");
                }
                if(GetFileLeft() == 0) {
                    OnAllUpdateFinished();
                }
            }).Run(mono);
        }

        private void OnAllUpdateFinished() {
            Debug.Log("更新全部完成");
            PlayerPrefs.SetString("_local_ver", currentUpdateVersion);
        }

        int GetFileLeft() {
            int n = 0;
            foreach(var act in runningActions) {
                if (act.Key.Status == 0) {
                    n++;
                }
            }
            return n;
        }

        private void OnRes(UpdateAction action) {
            // 解析
            if (action.Args.Length != 3) {
                Debug.LogWarning($"format error: {string.Join("|", action.Args)}");
                return;
            }
            var hash = action.Args[0];
            var size = action.Args[1];
            var path = action.Args[2];
            PerfomDownload($"{baseURL}/{path}", (code, header, ab, savePath) => {
                action.Status = 1;
                if (ab == null) {
                    return;
                }
                Debug.Log($"lua保存路径:{savePath}");
                // 解析资源文件
                foreach(string assetName in ab.GetAllAssetNames()) {
                    Debug.Log(assetName);
                }
            });
        }

        private void OnLua(UpdateAction action) {
            if (action.Args.Length != 3) {
                Debug.LogWarning($"format error: {string.Join("|", action.Args)}");
                return;
            }
            var hash = action.Args[0];
            var size = action.Args[1];
            var path = action.Args[2];
            PerfomDownload($"{baseURL}/{path}", (code, header, ab, savePath) => {
                Debug.Log($"lua保存路径:{savePath}");
                action.Status = 1;
            });
        }

        private void OnInclude(UpdateAction action) {
            Debug.Log("include:" + action);
            string incFile = action.Args[0];
            CacheableDownloadHandler.GetBytes(baseURL + $"/{incFile}", false, (statusCode, header, body) => {
                if (statusCode == 200 || statusCode == 304) { // ok
                    Parse(body.ToUTF8String());
                }
                
            }).Run(mono);
        }

        private void OnVersion(UpdateAction action) {
            currentUpdateVersion = action.Args[0];
            Debug.Log($"版本号:{currentUpdateVersion}");
            CheckIncludeFile();
            ExecuteActions();
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="data"></param>
        public void Parse(string content) {
            currentVersion = content;
            var lines = content.Split('\n');
            UpdateAction versionAction = null;
            foreach(string line in lines) {
                if (string.IsNullOrWhiteSpace(line)) {
                    continue;
                }
                var tokens = line.Replace("\n", "").Split('|');
                if (tokens == null || tokens.Length < 2) {
                    Debug.LogWarning($"format error:{line}");
                    continue;// invalid data
                }

                var ua = new UpdateAction();
                ua.Action = tokens[0];
                ua.Args = new string[tokens.Length - 1];
                if (string.IsNullOrWhiteSpace(ua.Action) || ua.Args.Length == 0) {
                    continue;
                }

                for(int i = 1; i < tokens.Length; i++) {
                    ua.Args[i - 1] = tokens[i];
                }
                if (ua.Action == "version") {
                    versionAction = ua;
                } else {
                    runningActions.Add(ua, 0);
                }
            }
            OnVersion(versionAction);
        }

        private void CheckIncludeFile() {
            
        }

        private void ExecuteActions() {
            mono.StartCoroutine(coExecuteActions());
        }

        IEnumerator coExecuteActions() {
            foreach (var kv in runningActions) {
                var action = kv.Key;
                if (!executor.ContainsKey(action.Action)) {
                    action.Status = -1;
                    continue;
                }
                executor[action.Action](action);
                yield return null;
            }
        }
    }

    public class UpdateAction {
        public string   Action = string.Empty;
        public string[] Args   = new string[0];
        public int      Status = 0;
        public override string ToString() {
            return $"action:{Action} args: {Args}";
        }
    }
}