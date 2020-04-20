using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BabyEngine {
    public class GameUpdateViewManager : MonoBehaviour {

        public Slider progress;
        public Text text;

        public Transform GameListRoot;
        public GameObject GameItemPrefab;
        public Transform GameContentRoot;
        public void OnGameData(GameUpdateEntry[] games) {
            if (progress == null || text == null || GameListRoot == null) {
                return;
            }
            GameListRoot.gameObject.SetActive(true);

            for (int i = GameContentRoot.childCount - 1; i > 0; i--) {
                Destroy(GameContentRoot.GetChild(i).gameObject);
            }

            foreach(var game in games) {
                var go = Instantiate(GameItemPrefab);
                go.GetComponent<GameItemView>().gameInfo = game;
                go.transform.SetParent(GameContentRoot, false);
            }
        }
    }
}