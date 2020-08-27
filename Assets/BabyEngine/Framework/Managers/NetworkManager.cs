using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace BabyEngine {
    public class NetworkManager : MonoBehaviour {
        public static NetworkManager Instance;
        public static NetworkManager Get() {
            return Instance;
        }

        private void Awake() {
            Instance = this;
        }

        public Coroutine RunWebRequest(UnityWebRequest request, XLua.LuaFunction cb) {
            return StartCoroutine(runWebRequest(request, cb));
        }

        private IEnumerator runWebRequest(UnityWebRequest request, XLua.LuaFunction cb) {
            yield return request.SendWebRequest();
            cb.Call(request);
        }
    }
}
