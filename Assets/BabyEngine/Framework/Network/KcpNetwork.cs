using System;
using UnityEngine;
using BabyEngine;
using XLua;

public class KcpNetwork : INetwork{
    public KcpHandler client;

    public bool Connected = false;
    public float Heartbeat = 10.0f;
    public float Delta = 0;
    LooperManager looper;
    public KcpNetwork(LooperManager looper) {
        this.looper = looper;
    }

    public void Connect(string host, int port) {
        if (null != client) {
            client.Stop();
        }
        connectState = 1;
        client = new KcpHandler(this);
        client.NoDelay(1, 10, 2, 1);//fast
        client.WndSize(4096, 4096);
        client.Timeout(40 * 1000);
        client.SetMtu(512);
        client.SetMinRto(10);
        client.SetConv(121106);

        client.Connect(host, port);

        client.Start();
    }

    
    public void Send(byte[] data) {
        var bb = new ByteBuffer(null);
        bb.WriteInt(data.Length);
        bb.WriteBytes(data);
        client.Send(bb);
    }
    public void SendRaw(byte[] data) {
        client.Send(new ByteBuffer(data));
    }
    public static string ToHex(byte[] bytes) {
        char[] c = new char[bytes.Length * 2];
        byte b;
        for (int bx = 0, cx = 0; bx < bytes.Length; ++bx, ++cx) {
            b = ((byte)(bytes[bx] >> 4));
            c[cx] = (char)(b > 9 ? b - 10 + 'A' : b + '0');

            b = ((byte)(bytes[bx] & 0x0F));
            c[++cx] = (char)(b > 9 ? b - 10 + 'A' : b + '0');
        }

        return new string(c);
    }
    
    public void OnUpdate() {
        if (null != client && client.IsRunning() && Connected) {
            Delta += Time.unscaledDeltaTime;
            if (Delta > Heartbeat) {
                Delta = 0;
            }
        }
    }

    public void OnData(ByteBuffer buffer) {
        looper.RunOnMainThread(()=> {
            if (connectState == 1) {
                connectState = 2;
                OnOpenFunc?.Call();
            }
            var rawData = buffer.GetRaw();
            OnDataFunc?.Call(rawData);
        });
    }

    public void OnTimeout() {
        looper.RunOnMainThread(() => {
            OnErrorFunc?.Call(new Exception("timeout"));
        });
    }

    public void OnException(Exception exception) {
        looper.RunOnMainThread(()=> {
            OnErrorFunc?.Call(exception);
        });
    }

    public void OnRelease() {
        if (null != client) {
            client.Stop();
        }
    }

    public void Close() {
        if (null != client) {
            client.Stop();
        }
        client = null;
    }
    //
    private int connectState = 0;
    public LuaFunction OnOpenFunc;
    public LuaFunction OnDataFunc;
    public LuaFunction OnErrorFunc;
}
