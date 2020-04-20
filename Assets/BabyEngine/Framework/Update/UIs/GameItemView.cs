using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace BabyEngine {
    public class GameItemView : MonoBehaviour {
        public GameUpdateEntry gameInfo;
        public Image gameIcon;
        public Text gameNameText;
        public Text gameDescText;
        public Text buttonText;
        public GameItemState state;
        public bool isCheckingGameinfo = false;
        public void Start() {
            gameNameText.text = gameInfo.GameName;
            ChangeState(GameItemState.kNotDownload);
            //CheckGame();

            CheckGame();
        }

        private void CheckGame() {
            if (isCheckingGameinfo) {
                Debug.LogError("xx");
                return; 
            }
            isCheckingGameinfo = true;
            Debug.Log($"game item start:{gameInfo}");
            CacheableDownloadHandler.GetBytes(gameInfo.GameUrl, (statusCode, header, data) => {
                if(statusCode == 200 || statusCode == 304) {
                    // status ok
                } else {
                    Debug.Log($"game error:{statusCode} {gameInfo.GameUrl} => {statusCode}");
                    ChangeState(GameItemState.kNotAvailable);
                    isCheckingGameinfo = false;
                    return;
                }
                ParseGameData(data.ToUTF8String());
            }).Run(this);
        }
        struct LineAction {
            public string action;
            public string hash;
            public int size;
            public string url;

            public override string ToString() {
                return $"{action}|{hash}|{size}|{url}";
            }
        }
        List<LineAction> lineActions = new List<LineAction>();
        private void ParseGameData(string v) {
            string[] lines = v.Split('\n');
            foreach(string line in lines) {
                ParseLineData(line);
            }
            // process line actions
            foreach(var act in lineActions) {
                processAction(act);
            }
        }

        private void processAction(LineAction act) {
            switch (act.action) {
                case "icon":
                    gameIcon.LoadImage(act.url);
                   // StartCoroutine(LoadImage(act));
                    break;
                case "desc":
                    gameDescText.text = act.url;
                    break;
            }
        }

        private IEnumerator LoadImage(LineAction act) {
            var request = UnityWebRequest.Get(act.url);
            yield return request.SendWebRequest();
            if(request.isNetworkError) {
                Debug.LogError(request.error);
                yield break;
            }
            Debug.Log(request.downloadHandler.text);
            if (request.isHttpError) {
                Debug.LogError(request.error);
                yield break;
            }
            var tex = new Texture2D(1, 1);
            tex.LoadImage(request.downloadHandler.data, true);

            this.gameIcon.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        }

        private void ParseLineData(string line) {
            string[] tokens = line.Split('|');
            if (tokens == null || tokens.Length != 4) {
                Debug.LogWarning("format err" + line);
                return;
            }
            string action = tokens[0];
            string hash = tokens[1];
            string size = tokens[2];
            string url = tokens[3];
          
            int sizeI;
            int.TryParse(size, out sizeI);
            var act = new LineAction() {
                action = action,
                hash = hash,
                size = sizeI,
                url = url,
            };
            lineActions.Add(act);
        }

        void ChangeState(GameItemState newState) {
            state = newState;
            switch (state) {
                case GameItemState.kNotDownload:
                    buttonText.text = "Download";
                    break;
                case GameItemState.kDownloading:
                    buttonText.text = "Downloading";
                    break;
                case GameItemState.kDownloaded:
                    buttonText.text = "Start Game";
                    break;
                case GameItemState.kNotAvailable:
                    buttonText.text = "Not Available";
                    break;
            }
        }
        public void OnClicked() {
            Debug.Log($"click {gameInfo.GameName}");
            switch (state) {
                case GameItemState.kNotDownload:
                    DownloadStart();
                    break;
                case GameItemState.kDownloading:
                    DownloadPause();
                    break;
                case GameItemState.kDownloaded:
                    GameStart();
                    break;
                case GameItemState.kNotAvailable:
                    RecheckGameInfo();
                    break;
            }
        }
        private void RecheckGameInfo() {
            Debug.Log($"Game Start: {gameInfo.GameName}");
            CheckGame();
        }
        private void GameStart() {
            Debug.Log($"Game Start: {gameInfo.GameName}");
        }

        private void DownloadPause() {
            Debug.Log($"Download pause: {gameInfo.GameName}");
        }

        private void DownloadStart() {
            Debug.Log($"Download start: {gameInfo.GameName}");
        }
    }

    public enum GameItemState {
        kNotDownload,
        kDownloading,
        kDownloaded,
        kNotAvailable
    }
}