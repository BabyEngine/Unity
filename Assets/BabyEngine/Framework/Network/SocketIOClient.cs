using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dpoch.SocketIO;
using XLua;
using System;

public static class XLuaExport_SocketIOClient {
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp2 = new List<Type>() {
                typeof(SocketIOConnection),
                typeof(SocketIOEvent),
                typeof(SocketIOConnection),
                typeof(Packet),
                typeof(SocketIO),
                // json
                typeof(Newtonsoft.Json.Linq.JArray),
                typeof(Newtonsoft.Json.Linq.JObject),
                // callback
                typeof(Action<SocketIOEvent>),
    };
}