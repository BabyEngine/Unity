using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BabyEngine {
    public class GameUpdateParser {
        string content = string.Empty;
        public GameUpdateParser(string content) {
            this.content = content; 
        }
        
        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="data"></param>
        public GameVersining Parse() {
            var lines = content.Split('\n');
            GameVersining gameVersining = new GameVersining();
            foreach(string line in lines) {
                try {
                    string cleaned = line.Replace("\n", "").Replace("\r", "");
                    if (string.IsNullOrWhiteSpace(cleaned)) {
                        continue;
                    }
                    
                    var tokens = cleaned.Split('|');
                    if (tokens == null || tokens.Length < 2) {
                        Debug.LogWarning($"format error:{cleaned}");
                        continue;// invalid data
                    }
                    var ActionName = tokens[0];
                    var Args = new string[tokens.Length - 1];

                    if (ActionName == "version") {
                        if (tokens.Length != 2) {
                            Debug.LogError("version format error");
                            return gameVersining;
                        }
                        int.TryParse(tokens[1], out gameVersining.Version);
                    } else {
                        if (string.IsNullOrWhiteSpace(ActionName) || Args.Length == 0) {
                            continue;
                        }
                        for (int i = 1; i < tokens.Length; i++) {
                            Args[i - 1] = tokens[i];
                        }

                        gameVersining.Add(new ResourceData(tokens[0], Args));
                    }
                } catch (Exception e) {
                    Debug.LogError(e);
                }
                
            }
            return gameVersining;
        }
    }

}