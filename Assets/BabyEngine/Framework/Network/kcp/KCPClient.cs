using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[XLua.LuaCallCSharp]
public class KCPClient {
    UDPSession session = null;
    public bool IsHeadlike = true;
    public bool SessionOk {
        get {
            if (session == null)
                return false;
            return session.IsConnected;
        }
    }
    public Action<object> OnError;
    public Action<byte[]> OnData;
    public Action OnOpen;
    private bool hasComunication;

    public void Connect( string addr, int port ) {
        if (session != null) {
            session.Close();
            session = null;
        }

        session = new UDPSession();
        session.onError = this.onError;

        session.Connect(addr, port);
    }

    public void Send( byte[] data ) {
        if (!SessionOk) {
            return;
        }
        if (IsHeadlike) {
            var header = BitConverter.GetBytes((uint)data.Length);
            ByteBuffer bf = new ByteBuffer();
            if(BitConverter.IsLittleEndian) {
                Array.Reverse(header);
            }

            bf.EnsureWritableBytes(4 + data.Length);
            bf.WriteBytes(header);
            bf.WriteBytes(data);
            data = bf.ReadBytes(4 + data.Length);
        }
        session.Send(data);
    }

    public void Send( string data ) {
        this.Send(System.Text.Encoding.UTF8.GetBytes(data));
    }

    public void Update() {
        updateSession();
    }

    void updateSession() {
        if (session != null) {
            session.Update();
            doRead();
        }
    }

    void doRead( byte[] buf = null ) {
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
            var data = new byte[n];
            Buffer.BlockCopy(buf, 0, data, 0, n);
            onData(data);
        }
    }

    void onError( object err ) {
        OnError?.Invoke(err);
    }
    void onData( byte[] data ) {
        if (hasComunication == false) {
            hasComunication = true;
            OnOpen?.Invoke();
        }
        if (IsHeadlike) {
            var bf = new ByteBuffer();
            bf.WriteBytes(data);

            var header = bf.ReadBytes(4);
            if (BitConverter.IsLittleEndian) {
                Array.Reverse(header);
            }
            var size = BitConverter.ToUInt32(header, 0);
            data = bf.ReadBytes((int)size);
        }
        OnData?.Invoke(data);
    }

    public void Close() {
        session.Close();
        session = null;
    }
}
