using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BabyEngine {
    public class GameUpdatePanel : MonoBehaviour {
        [SerializeField] private GameApp app = null;
        [SerializeField] private Transform[] StateRoot = new Transform[0];
        [SerializeField] private Text ErrorText = null;
        [SerializeField] private Text NewVersionText = null;
        [SerializeField] private Slider DownloadingProgress = null;
        GameUpdateState updateState = GameUpdateState.kChecking;
        public GameUpdateWorker worker;
        public Transform activeWhenGameReady;
        public bool AutoDownload;
        public bool AutoStartGame;
        public bool AllowNetworkErrorPlayLocal;
        private void Start() {
            worker.gameObject.SetActive(true);
            worker.CheckVersioning(onError, onLatestVersion, onFoundUpdateVersion);
        }

        private void onFoundUpdateVersion() {
            Debug.Log("发现新版本");
            ChangeState(GameUpdateState.kFoundNewVersion);
            NewVersionText.text = $"发现新版本, 文件大小:{worker.NewVersion.SizeString}";
        }

        public void OnClickedDownload() {
            ChangeState(GameUpdateState.kDownloading);
            worker.StartDownload(onDownloadFinished);
        }

        public void OnClickedStartGame() {
            DoStartGame();
        }

        public void OnClickedRepairFile() {
            worker.gameObject.SetActive(true);
            worker.CheckVersioning(onError, onLatestVersion, onFoundUpdateVersion, true);
        }

        private void DoStartGame() {
            gameObject.SetActive(false);
            worker.gameObject.SetActive(false);
            activeWhenGameReady.gameObject.SetActive(true);

            app.gameObject.SetActive(true);
            app.PerfomLuaStart();
        }

        private void onDownloadFinished(bool ok) {
            Debug.Log($"下载成功 {ok}");
            if(ok) {
                ChangeState(GameUpdateState.kIsLatest);
                if (AutoStartGame) {
                    DoStartGame();
                }
            } else {
                ChangeState(GameUpdateState.kError);
            }
        }

        private void onLatestVersion() {
            ChangeState(GameUpdateState.kIsLatest);
            if (AutoStartGame) {
                DoStartGame();
            }
        }

        private void onError(string obj) {
            Debug.LogWarning($"发生错误:{obj}");
            ChangeState(GameUpdateState.kError);
            ErrorText.text = obj;
            if (AllowNetworkErrorPlayLocal) {
                Debug.Log("允许本地游戏");
                onLatestVersion();
            }
        }

        public void ChangeState(GameUpdateState state) {
            updateState = state;
            foreach(var r in StateRoot) {
                r.gameObject.SetActive(false);
            }
            int idx = (int)updateState;
            if (idx < 0 || idx >= StateRoot.Length) {
                // not in list
                //Debug.LogError($"idx error:{idx}");
            } else {
                StateRoot[idx].gameObject.SetActive(true);
            }
            switch (updateState) {
                case GameUpdateState.kChecking:
                    break;
                case GameUpdateState.kFoundNewVersion:
                    if (AutoDownload) {
                        OnClickedDownload();
                    }
                    break;
                case GameUpdateState.kIsLatest:
                    break;
            }
        }
        private void Update() {
            if (updateState == GameUpdateState.kDownloading) {
                DownloadingProgress.value = worker.Progress;
            }
        }
    }

    public enum GameUpdateState {
        kChecking,
        kFoundNewVersion,
        kDownloading,
        kIsLatest,
        kError,
    }
}
