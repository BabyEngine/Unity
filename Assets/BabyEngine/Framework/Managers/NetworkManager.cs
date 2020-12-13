using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace BabyEngine {
    public class NetworkManager : IManager {
        public Coroutine RunWebRequest(UnityWebRequest request, XLua.LuaFunction cb) {
            return StartCoroutine(runWebRequest(request, cb));
        }

        private IEnumerator runWebRequest(UnityWebRequest request, XLua.LuaFunction cb) {
            yield return request.SendWebRequest();
            cb.Call(request);
        }
    }
}