using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BabyEngine {
    public class StartupChecker : MonoBehaviour {
        public string StartupUrl;
        public delegate void GameDataHandler(GameUpdateEntry[] games);
        public GameDataHandler handler;

        private void Awake() {
            if (handler == null) {
                var comp = transform.GetComponent<GameUpdateViewManager>();
                if (comp != null) {
                    handler = comp.OnGameData;
                }
            }
        }

        internal void CheckVersioning(Action onOk, Action<string> onErr) {
            StartCoroutine(CheckStartup(onOk, onErr));
        }

        private IEnumerator CheckStartup(Action onOk, Action<string> onErr) {
            yield return null;
            var co = CacheableDownloadHandler.GetBytes(StartupUrl, (statusCode, header, body) => {
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

        void ParseStartupData(string content) {
            var games = content.Split('\n'); // BBE|http://bbe.com/startup
            List<GameUpdateEntry> list = new List<GameUpdateEntry>();
            foreach (var game in games) {
                var tokens = game.Split('|');
                if (tokens != null && tokens.Length == 2) {
                    string gameName = tokens[0];
                    string gameUrl = tokens[1];
                    list.Add(new GameUpdateEntry() { GameName = gameName, GameUrl = gameUrl });
                }
            }
            GameUpdateEntry[] result = list.ToArray();
            handler?.Invoke(result);
        }
    }
}