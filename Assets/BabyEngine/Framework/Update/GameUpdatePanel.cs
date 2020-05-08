﻿using System;
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
        public Transform gamePlayPanel;
        public bool AutoStartGame;
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

        private void DoStartGame() {
            gameObject.SetActive(false);
            worker.gameObject.SetActive(false);
            gamePlayPanel.gameObject.SetActive(true);

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
            Debug.Log("已经是最新版本");
            ChangeState(GameUpdateState.kIsLatest);
            if (AutoStartGame) {
                DoStartGame();
            }
        }

        private void onError(string obj) {
            Debug.LogError($"发生错误:{obj}");
            ChangeState(GameUpdateState.kError);
            ErrorText.text = obj;
        }

        public void ChangeState(GameUpdateState state) {
            updateState = state;
            foreach(var r in StateRoot) {
                r.gameObject.SetActive(false);
            }
            int idx = (int)updateState;
            if (idx < 0 || idx >= StateRoot.Length) {
                // not in list
                Debug.LogError($"idx error:{idx}");
            } else {
                StateRoot[idx].gameObject.SetActive(true);
            }
            switch (updateState) {
                case GameUpdateState.kChecking:
                    break;
                case GameUpdateState.kFoundNewVersion:
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
