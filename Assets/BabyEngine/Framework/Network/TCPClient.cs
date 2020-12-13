using BabyEngine;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class TCPClient {
    private TcpClient client;
    private NetworkStream outStream;
    private MemoryStream memStream;
    private BinaryReader reader;
    LooperManager LooperMgr;
    private const int MAX_READ = 8192;
    private byte[] byteBuffer = new byte[MAX_READ];
    #region 接口
    public LuaFunction onOpen;       // 连接打开
    public LuaFunction onData;       // 收到数据
    public LuaFunction onDisconnect; // 断开
    #endregion

    public TCPClient( LooperManager looper ) {
        LooperMgr = looper;
    }

    /// <summary>
    /// 开始连接
    /// </summary>
    /// <param name="host">主机名</param>
    /// <param name="port">端口</param>
    public void Connect( string host, int port ) {
        try {
            IPAddress[] addresses = Dns.GetHostAddresses(host);
            if (addresses.Length == 0) {
                Debug.LogError("host invalid");
                return;
            }
            if (addresses[0].AddressFamily == AddressFamily.InterNetworkV6) {
                client = new TcpClient(AddressFamily.InterNetworkV6);
            } else {
                client = new TcpClient(AddressFamily.InterNetwork);
            }
            client.SendTimeout = 5000;
            client.ReceiveTimeout = 5000;
            client.NoDelay = true;
            client.BeginConnect(host, port, new AsyncCallback(OnConnect), null);
        } catch (Exception e) {
            Debug.LogError(e);
        }
    }
    /// <summary>
    /// 连上了服务器
    /// </summary>
    /// <param name="ar"></param>
    private void OnConnect( IAsyncResult ar ) {
        try {
            if (!client.Connected) {
                OnDisconnected("connect timeout");
                return;
            }
            outStream = client.GetStream();
            client.GetStream().BeginRead(byteBuffer, 0, MAX_READ, new AsyncCallback(OnRead), null);
            memStream = new MemoryStream();
            reader = new BinaryReader(memStream);
            LooperMgr.RunOnMainThread(() => {
                onOpen?.Call();
            });
        } catch (Exception e) {
            OnDisconnected(e.ToString());
        }
    }
    /// <summary>
    /// 断开
    /// </summary>
    /// <param name="reason"></param>
    void OnDisconnected( string reason ) {
        Close();
        LooperMgr.RunOnMainThread(() => {
            onDisconnect?.Call(reason);
        });
    }
    /// <summary>
    /// 读操作
    /// </summary>
    /// <param name="ar"></param>
    private void OnRead( IAsyncResult ar ) {
        int bytesRead = 0;
        try {
            lock (client.GetStream()) {
                bytesRead = client.GetStream().EndRead(ar);
            }
            if (bytesRead < 1) {
                OnDisconnected("read error");
                return;
            }
            OnReceive(byteBuffer, bytesRead);
            lock (client.GetStream()) {
                Array.Clear(byteBuffer, 0, byteBuffer.Length);
                client.GetStream().BeginRead(byteBuffer, 0, MAX_READ, new AsyncCallback(OnRead), null);
            }
        } catch (Exception e) {
            Debug.LogError(e);
        }
    }
    /// <summary>
    /// 关闭连接
    /// </summary>
    public void Close() {
        if (client != null) {
            try {
                client.Close();
                client.Dispose();
                client = null;
            } catch (Exception e) {
                Debug.LogError(e);
            }
        }
    }
    /// <summary>
    /// 读操作
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="length"></param>
    void OnReceive( byte[] bytes, int length ) {
        try {
            memStream.Seek(0, SeekOrigin.Begin);
            memStream.Write(bytes, 0, length);
            memStream.Seek(0, SeekOrigin.Begin);
            while (RemainingBytes() > 2) {
                ushort len = reader.ReadUInt16();
                if (RemainingBytes() >= len) {
                    MemoryStream ms = new MemoryStream();
                    BinaryWriter w = new BinaryWriter(ms);
                    w.Write(reader.ReadBytes(len));
                    ms.Seek(0, SeekOrigin.Begin);
                    OnReceivedMessage(ms);
                } else {
                    memStream.Position = memStream.Position - 2;
                    break;
                }
                byte[] left = reader.ReadBytes((int)RemainingBytes());
                memStream.SetLength(0);
                memStream.Write(left, 0, left.Length);
            }
        } catch (Exception e) {
            Debug.LogError(e);
        }
    }
    /// <summary>
    /// 读到完整消息
    /// </summary>
    /// <param name="ms"></param>
    private void OnReceivedMessage( MemoryStream ms ) {
        try {
            BinaryReader r = new BinaryReader(ms);
            byte[] message = r.ReadBytes((int)(ms.Length - ms.Position));

            LooperMgr.RunOnMainThread(() => {
                onData?.Call(message);
            });
        } catch (Exception e) {
            Debug.LogError(e);
        }
    }
    /// <summary>
    /// 剩余多少字节才能组合成消息
    /// </summary>
    /// <returns></returns>
    private long RemainingBytes() {
        if (memStream == null) return 0;
        return memStream.Length - memStream.Position;
    }
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="message"></param>
    public void WriteMessage( byte[] message ) {
        try {
            MemoryStream ms;
            using (ms = new MemoryStream()) {
                ms.Position = 0;
                BinaryWriter w = new BinaryWriter(ms);
                ushort len = (ushort)message.Length;
                w.Write(len);
                w.Write(message);
                w.Flush();
                if (client != null && client.Connected) {
                    byte[] payload = ms.ToArray();
                    outStream.BeginWrite(payload, 0, payload.Length, new AsyncCallback(OnWrite), null);
                } else {
                    Debug.LogError("client not connected.");
                }
            }
        } catch (Exception e) {
            Debug.LogError(e);
        }
    }
    /// <summary>
    /// 写操作
    /// </summary>
    /// <param name="ar"></param>
    private void OnWrite( IAsyncResult ar ) {
        try {
            outStream.EndWrite(ar);
        } catch (Exception e) {
            Debug.LogError(e);
        }
    }
}
