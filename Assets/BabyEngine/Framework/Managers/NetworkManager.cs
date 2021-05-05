using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using System;

namespace BabyEngine {
    public class NetworkManager : IManager {
        List<INetwork> networks = new List<INetwork>();
        public Coroutine RunWebRequest(UnityWebRequest request, XLua.LuaFunction cb) {
            return StartCoroutine(runWebRequest(request, cb));
        }

        private IEnumerator runWebRequest(UnityWebRequest request, XLua.LuaFunction cb) {
            yield return request.SendWebRequest();
            cb.Call(request);
        }
        private void Update() {
            foreach(INetwork client in networks) {
                client.OnUpdate();
            }
        }
        void OnDestroy() {
            foreach (INetwork client in networks) {
                client.OnRelease();
            }
        }

        public INetwork AddClient(string network) {
            switch (network) {
                case "kcp":
                    var looper = (LooperManager)GetManager("LooperManager");
                    return new KcpNetwork(looper);
            }
            return null;
        }
    }
    public interface INetwork {
        void Connect(string host, int port);
        void Send(byte[] data);
        void OnUpdate();
        void OnData(ByteBuffer buffer);
        void OnTimeout();
        void OnException(Exception exception);
        void OnRelease();
        void Close();
    }
}