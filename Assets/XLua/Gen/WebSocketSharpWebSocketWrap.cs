#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class WebSocketSharpWebSocketWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(WebSocketSharp.WebSocket);
			Utils.BeginObjectRegister(type, L, translator, 0, 16, 15, 6);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Accept", _m_Accept);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AcceptAsync", _m_AcceptAsync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Close", _m_Close);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseAsync", _m_CloseAsync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Connect", _m_Connect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ConnectAsync", _m_ConnectAsync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Ping", _m_Ping);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Send", _m_Send);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendAsync", _m_SendAsync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCookie", _m_SetCookie);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCredentials", _m_SetCredentials);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetProxy", _m_SetProxy);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnClose", _e_OnClose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnError", _e_OnError);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnMessage", _e_OnMessage);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnOpen", _e_OnOpen);
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Compression", _g_get_Compression);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Cookies", _g_get_Cookies);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Credentials", _g_get_Credentials);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EmitOnPing", _g_get_EmitOnPing);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnableRedirection", _g_get_EnableRedirection);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Extensions", _g_get_Extensions);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsAlive", _g_get_IsAlive);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsSecure", _g_get_IsSecure);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Log", _g_get_Log);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Origin", _g_get_Origin);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Protocol", _g_get_Protocol);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReadyState", _g_get_ReadyState);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SslConfiguration", _g_get_SslConfiguration);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Url", _g_get_Url);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WaitTime", _g_get_WaitTime);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Compression", _s_set_Compression);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "EmitOnPing", _s_set_EmitOnPing);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "EnableRedirection", _s_set_EnableRedirection);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Origin", _s_set_Origin);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SslConfiguration", _s_set_SslConfiguration);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "WaitTime", _s_set_WaitTime);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) >= 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)))
				{
					string _url = LuaAPI.lua_tostring(L, 2);
					string[] _protocols = translator.GetParams<string>(L, 3);
					
					WebSocketSharp.WebSocket gen_ret = new WebSocketSharp.WebSocket(_url, _protocols);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to WebSocketSharp.WebSocket constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Accept(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Accept(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AcceptAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.AcceptAsync(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Close(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.Close(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    ushort _code = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.Close( _code );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<WebSocketSharp.CloseStatusCode>(L, 2)) 
                {
                    WebSocketSharp.CloseStatusCode _code;translator.Get(L, 2, out _code);
                    
                    gen_to_be_invoked.Close( _code );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    ushort _code = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    string _reason = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.Close( _code, _reason );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<WebSocketSharp.CloseStatusCode>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    WebSocketSharp.CloseStatusCode _code;translator.Get(L, 2, out _code);
                    string _reason = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.Close( _code, _reason );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to WebSocketSharp.WebSocket.Close!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.CloseAsync(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    ushort _code = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.CloseAsync( _code );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<WebSocketSharp.CloseStatusCode>(L, 2)) 
                {
                    WebSocketSharp.CloseStatusCode _code;translator.Get(L, 2, out _code);
                    
                    gen_to_be_invoked.CloseAsync( _code );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    ushort _code = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    string _reason = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.CloseAsync( _code, _reason );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<WebSocketSharp.CloseStatusCode>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    WebSocketSharp.CloseStatusCode _code;translator.Get(L, 2, out _code);
                    string _reason = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.CloseAsync( _code, _reason );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to WebSocketSharp.WebSocket.CloseAsync!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Connect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Connect(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConnectAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ConnectAsync(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Ping(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        bool gen_ret = gen_to_be_invoked.Ping(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.Ping( _message );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to WebSocketSharp.WebSocket.Ping!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Send(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    byte[] _data = LuaAPI.lua_tobytes(L, 2);
                    
                    gen_to_be_invoked.Send( _data );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<System.IO.FileInfo>(L, 2)) 
                {
                    System.IO.FileInfo _file = (System.IO.FileInfo)translator.GetObject(L, 2, typeof(System.IO.FileInfo));
                    
                    gen_to_be_invoked.Send( _file );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _data = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.Send( _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to WebSocketSharp.WebSocket.Send!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<bool>>(L, 3)) 
                {
                    byte[] _data = LuaAPI.lua_tobytes(L, 2);
                    System.Action<bool> _completed = translator.GetDelegate<System.Action<bool>>(L, 3);
                    
                    gen_to_be_invoked.SendAsync( _data, _completed );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<System.IO.FileInfo>(L, 2)&& translator.Assignable<System.Action<bool>>(L, 3)) 
                {
                    System.IO.FileInfo _file = (System.IO.FileInfo)translator.GetObject(L, 2, typeof(System.IO.FileInfo));
                    System.Action<bool> _completed = translator.GetDelegate<System.Action<bool>>(L, 3);
                    
                    gen_to_be_invoked.SendAsync( _file, _completed );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<bool>>(L, 3)) 
                {
                    string _data = LuaAPI.lua_tostring(L, 2);
                    System.Action<bool> _completed = translator.GetDelegate<System.Action<bool>>(L, 3);
                    
                    gen_to_be_invoked.SendAsync( _data, _completed );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<System.IO.Stream>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Action<bool>>(L, 4)) 
                {
                    System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 2, typeof(System.IO.Stream));
                    int _length = LuaAPI.xlua_tointeger(L, 3);
                    System.Action<bool> _completed = translator.GetDelegate<System.Action<bool>>(L, 4);
                    
                    gen_to_be_invoked.SendAsync( _stream, _length, _completed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to WebSocketSharp.WebSocket.SendAsync!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCookie(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    WebSocketSharp.Net.Cookie _cookie = (WebSocketSharp.Net.Cookie)translator.GetObject(L, 2, typeof(WebSocketSharp.Net.Cookie));
                    
                    gen_to_be_invoked.SetCookie( _cookie );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCredentials(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _username = LuaAPI.lua_tostring(L, 2);
                    string _password = LuaAPI.lua_tostring(L, 3);
                    bool _preAuth = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.SetCredentials( _username, _password, _preAuth );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetProxy(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    string _username = LuaAPI.lua_tostring(L, 3);
                    string _password = LuaAPI.lua_tostring(L, 4);
                    
                    gen_to_be_invoked.SetProxy( _url, _username, _password );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Compression(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Compression);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Cookies(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, gen_to_be_invoked.Cookies);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Credentials(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Credentials);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EmitOnPing(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.EmitOnPing);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnableRedirection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.EnableRedirection);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Extensions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Extensions);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAlive(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsAlive);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsSecure(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsSecure);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Log(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Log);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Origin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Origin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Protocol(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Protocol);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReadyState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ReadyState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SslConfiguration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.SslConfiguration);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Url(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Url);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WaitTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.WaitTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Compression(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                WebSocketSharp.CompressionMethod gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.Compression = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EmitOnPing(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.EmitOnPing = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EnableRedirection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.EnableRedirection = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Origin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Origin = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SslConfiguration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SslConfiguration = (WebSocketSharp.Net.ClientSslConfiguration)translator.GetObject(L, 2, typeof(WebSocketSharp.Net.ClientSslConfiguration));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WaitTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                System.TimeSpan gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.WaitTime = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnClose(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                System.EventHandler<WebSocketSharp.CloseEventArgs> gen_delegate = translator.GetDelegate<System.EventHandler<WebSocketSharp.CloseEventArgs>>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.EventHandler<WebSocketSharp.CloseEventArgs>!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnClose += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnClose -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to WebSocketSharp.WebSocket.OnClose!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnError(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                System.EventHandler<WebSocketSharp.ErrorEventArgs> gen_delegate = translator.GetDelegate<System.EventHandler<WebSocketSharp.ErrorEventArgs>>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.EventHandler<WebSocketSharp.ErrorEventArgs>!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnError += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnError -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to WebSocketSharp.WebSocket.OnError!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnMessage(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                System.EventHandler<WebSocketSharp.MessageEventArgs> gen_delegate = translator.GetDelegate<System.EventHandler<WebSocketSharp.MessageEventArgs>>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.EventHandler<WebSocketSharp.MessageEventArgs>!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnMessage += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnMessage -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to WebSocketSharp.WebSocket.OnMessage!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnOpen(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			WebSocketSharp.WebSocket gen_to_be_invoked = (WebSocketSharp.WebSocket)translator.FastGetCSObj(L, 1);
                System.EventHandler gen_delegate = translator.GetDelegate<System.EventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.EventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnOpen += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnOpen -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to WebSocketSharp.WebSocket.OnOpen!");
            return 0;
        }
        
		
		
    }
}
