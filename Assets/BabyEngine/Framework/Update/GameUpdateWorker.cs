using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BabyEngine {
    /// <summary>
    /// 游戏更新检查
    /// </summary>
    public class GameUpdateWorker : MonoBehaviour {
        [SerializeField] private GameApp app = null;
        [SerializeField] private string baseURL  = String.Empty;
        [SerializeField] private Transform showNoticeRoot = null;
        [SerializeField] private Text showNoticeText = null;

        private void Start() {
            CheckVersioning(onFetchSuccess, onFetchError);
        }
        /// <summary>
        /// 展示错误
        /// </summary>
        /// <param name="obj"></param>
        private void onFetchError(string obj) {
            if (showNoticeText != null) {
                showNoticeText.text = obj;
            }
            if (showNoticeRoot != null) {
                showNoticeRoot.gameObject.SetActive(true);
            }
        }

        private void onFetchSuccess() {
            
        }

        internal void CheckVersioning(Action onOk, Action<string> onErr) {
            StartCoroutine(CheckStartup(onOk, onErr));
        }

        private IEnumerator CheckStartup(Action onOk, Action<string> onErr) {
            yield return null;
            var co = CacheableDownloadHandler.GetBytes(baseURL + "/update.txt", false, (statusCode, header, body) => {
                if (statusCode == 200) { // use new data

                }
                switch (statusCode) {
                    case 200: // use new data=
                        ParseStartupData(body.ToUTF8String());
                        onOk();
                        break;
                    case 304: // use cache daeta
                        ParseStartupData(body.ToUTF8String());
                        onOk();
                        break;
                    default:  // not respect this
                        onErr($"http ${statusCode}");
                        break;
                }
            });
            StartCoroutine(co);
        }

        private void ParseStartupData(string data) {
            var p = new GameUpdateParser(this, baseURL);
            p.Parse(data);
        }

        void AfterUpdateDone() {
            if (app == null) {
                
            }
            app.PerfomLuaStart();
        }
    }
}
