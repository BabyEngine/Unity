using System;
using UnityEngine;
using XLua;
using WebSocketSharp;
using BabyEngine;

[LuaCallCSharp]
public class WSClient {
    public WebSocket client;

    LooperManager LooperMgr;
    #region 接口
    public LuaFunction onOpen;  // 连接打开
    public LuaFunction onData;  // 收到数据
    public LuaFunction onError; // 错误
    public LuaFunction onClose; // 断开
    #endregion

    public WSClient( LooperManager looper ) {
        LooperMgr = looper;
    }

    /// <summary>
    /// 开始连接
    /// </summary>
    /// <param name="host">主机名</param>
    /// <param name="port">端口</param>
    public void Connect( string url ) {
        try {
            client = new WebSocket(url);
            client.OnMessage += OnMessage;
            client.OnOpen += OnOpen;
            client.OnError += OnError;
            client.OnClose += OnClose;
            client.Connect();

        } catch (Exception e) {
            Debug.LogError(e);
        }
    }
    public void Send( byte[] data ) {
        client.Send(data);
    }
    private void OnClose( object sender, CloseEventArgs e ) {
        LooperMgr.RunOnMainThread(() => {
            onClose?.Call(sender, e);
        });
    }

    private void OnError( object sender, WebSocketSharp.ErrorEventArgs e ) {
        LooperMgr.RunOnMainThread(() => {
            onError?.Call(sender, e);
        });
    }

    private void OnOpen( object sender, EventArgs e ) {
        LooperMgr.RunOnMainThread(() => {

            onOpen?.Call(sender, e);
        });
    }

    private void OnMessage( object sender, MessageEventArgs e ) {

        LooperMgr.RunOnMainThread(() => {
            onData?.Call(sender, e);
        });
    }
}
