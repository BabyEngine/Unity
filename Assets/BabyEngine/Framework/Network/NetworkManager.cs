using System;
using System.IO;
using System.Text;
using UnityEngine;

public class NetworkManager {
    #region Static API
    static NetworkManager _Instance = null;
    static NetworkManager Instance {
        get {
            if (_Instance == null) {
                _Instance = new NetworkManager();
                _Instance.init();
            }
            return _Instance;
        }
    }


    public static void Send( UInt32 tag, string v ) {
        byte[] payload = Encoding.UTF8.GetBytes(v);
        Send(tag, payload);
    }
    public static void Send( UInt32 tag, byte[] payload ) {
        Instance.client.Send(tag, payload);
    }
    public static void SendMessage( UInt32 tag, byte[] payload ) {
        Instance.client.Send(tag, payload);
    }

    public static void Init( string address, int port, Action cb ) {
        if (Instance.client != null) {
            Instance.client.Stop();
        }
        Instance.client = new NetworkClient();
        Instance.client.Connect(address, port);
        Instance.client.OnData += Instance.OnData;
        cb();
    }

    private void OnData( UInt32 tag, byte[] payload ) {
        Debug.Log($"收到消息{tag} {Encoding.UTF8.GetString(payload)}");
    }
    #endregion
    NetworkClient client = new NetworkClient();
    void init() {
        Application.quitting += this.Stop;
    }

    void Stop() {
        if (client != null) {
            client.Stop();
        }
        client = null;
    }


}
