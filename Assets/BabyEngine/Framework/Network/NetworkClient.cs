using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class NetworkClient {
    public static int UpdateInterval = 10;
    public static int ReconnectInterval = 1000;
    KCPClient client = new KCPClient();
    bool isRunning = true;
    Task runningTask;
    public NetworkClient() {
        runningTask = new Task(Update);
        runningTask.Start();
    }

    public void Connect( string address, int port ) {
        //Debug.Log($"连接{ address } {port}");
        this.address = address;
        this.port = port;
        client.OnData = ( data ) => {
            if (data.Length < 5) {
                // ERR!
                return;
            }

            lastSeen = DateTime.Now;
            //Debug.Log($"data: {data.Length}");
            // parse header
            // msg type
            byte msgType = data[0];
            // size
            var header = new byte[4];
            Array.Copy(data, 1, header, 0, 4);
            if (BitConverter.IsLittleEndian) {
                Array.Reverse(header);
            }
            //Debug.Log($" { BitConverter.ToString(header).Replace("-", ", ") }");
            var payloadSize = BitConverter.ToUInt32(header, 0);

            //Debug.Log($"recv: {msgType} {payloadSize}");
            switch (msgType) {
            case 0: // data
                // parse tag
                byte[] tagBytes = new byte[4];
                Array.Copy(data, 5, tagBytes, 0, 4);
                var tag = GetUint32(tagBytes);
                // parse payload
                byte[] payload = new byte[0];
                if (payloadSize > 0) {
                    payload = new byte[payloadSize];
                    Array.Copy(data, 9, payload, 0, payloadSize);
                }
                //var msg = Encoding.UTF8.GetString(payload);
                //Debug.Log($"============={msg}");
                OnData.Invoke(tag, payload);
                break;
            case 1:// ping
                break;
            case 2:// pong
                break;
            }
        };
        client.OnOpen = () => {
            //Debug.Log("OPEN");
            OnOpen?.Invoke();
        };

        client.OnError = ( err ) => {
            //Debug.Log($"err: {err}");
            OnError?.Invoke(err);
            Connect();
        };
        Connect();
    }
    DateTime lastConnectTime = DateTime.FromFileTimeUtc(0);
    void Connect() {
        if (DateTime.Now.Subtract(lastConnectTime) < TimeSpan.FromSeconds(5)) {
            //Debug.Log("连接过于频繁");
            return;
        }
        lastConnectTime = DateTime.Now;
        client.Connect(this.address, this.port);
        //Debug.Log("请求连接");
    }
    public void Stop() {
        isRunning = false;
        //Debug.Log("停止运行");
        client.Close();
    }

    public void Send( UInt32 tag, byte[] payload ) {
        SendInternal(tag, payload, 0);
    }
    private byte[] PutInt32( UInt32 val ) {
        byte[] bytes = BitConverter.GetBytes(val);
        if (BitConverter.IsLittleEndian) {
            Array.Reverse(bytes);
        }
        return bytes;
    }
    private UInt32 GetUint32( byte[] bytes ) {
        if (BitConverter.IsLittleEndian) {
            Array.Reverse(bytes);
        }
        return BitConverter.ToUInt32(bytes, 0);
    }
    private void SendInternal( UInt32 tag, byte[] payload, byte msgType ) {
        // message header
        UInt32 sz = (uint)payload.Length;
        byte[] header = PutInt32((uint)payload.Length);
        //byte[] header = BitConverter.GetBytes(sz);
        //if (BitConverter.IsLittleEndian) {
        //    Array.Reverse(header);
        //}
        // message type
        byte[] typeByte = new byte[1] { msgType };
        byte[] tagByte = null;
        if (msgType == 0) {
            tagByte = PutInt32(tag);
        }

        // message payload
        using (MemoryStream ms = new MemoryStream()) {
            ms.Write(typeByte, 0, 1);
            ms.Write(header, 0, 4);
            if (tagByte != null) {
                ms.Write(tagByte, 0, 4);
            }
            ms.Write(payload, 0, payload.Length);
            var data = ms.ToArray();
            //Debug.Log($"send=> {payload.Length} { BitConverter.ToString(data).Replace("-", ", ") }");
            client.Send(data);
        }
    }

    DateTime lastTimePing = DateTime.Now;
    DateTime lastSeen = DateTime.Now;
    string address;
    int port;
    public Action<UInt32, byte[]> OnData { get; internal set; }
    public Action OnOpen { get; internal set; }
    public Action OnClose { get; internal set; }
    public Action<object> OnError { get; internal set; }

    private void Update() {
        while (isRunning) {
            Thread.Sleep(UpdateInterval);
            do {
                client.Update();
                // check heartbeat
                if (DateTime.Now.Subtract(lastSeen).Seconds > 10) {
                    Debug.Log("心跳超时");
                    lastSeen = DateTime.Now;
                    Connect();
                    break;
                }
                // check ping
                if (DateTime.Now.Subtract(lastTimePing).Seconds > 3) {
                    sendPing();
                    lastTimePing = DateTime.Now;
                }
            } while (true);

        }

        //Debug.Log("退出...");
    }

    private void sendPing() {
        //Debug.Log($"send ping {lastSeen}");
        SendInternal(0, new byte[0], 1);
    }
}
