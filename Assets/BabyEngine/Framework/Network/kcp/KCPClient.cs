using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uKCP {
    public class KCPClient : MonoBehaviour {
        UDPSession session = null;

        public bool SessionOk {
            get {
                if (session == null)
                    return false;
                return session.IsConnected;
            }
        }
        public Action<object> OnError;
        public Action<byte[]> OnData;

        public void Connect(string addr, int port) {
            if (session != null) {
                session.Close();
                session = null;
            }

            session = new UDPSession();
            session.onError = this.onError;

            session.Connect(addr, port);
            Debug.Log($"do conn{addr}:{port}");
        }

        public void Send(byte[] data) {
            if (!SessionOk) {
                return;
            }
            session.Send(data);
        }

        public void Send(string data) {
            this.Send(System.Text.Encoding.UTF8.GetBytes(data));
        }

        public void Update() {
            updateSession();
        }

        /// <summary>
        /// 
        /// </summary>
        void updateSession() {
            if (session != null) {
                session.Update();
                doRead();
            }
        }

        void doRead(byte[] buf = null) {
            if (buf == null)
                buf = new byte[4096];
            int n = session.Recv(buf, 0, buf.Length);
            if (n == 0) {
                // no data
                return;
            } else if (n < 0) {
                session.Close();
                session = null;
                return;
            } else {
                // read data ok
                onData(buf);
            }
        }

        void onError(object err) {
            OnError?.Invoke(err);
        }
        void onData(byte[] data) {
            OnData?.Invoke(data);
        }
    }
}