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
    public class DpochSocketIOSocketIOWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Dpoch.SocketIO.SocketIO);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Connect", _m_Connect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Close", _m_Close);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "On", _m_On);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Off", _m_Off);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Emit", _m_Emit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "EmitACK", _m_EmitACK);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnOpen", _e_OnOpen);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnConnectFailed", _e_OnConnectFailed);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnClose", _e_OnClose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnError", _e_OnError);
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsAlive", _g_get_IsAlive);
            
			
			
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
				if(LuaAPI.lua_gettop(L) == 4 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					string _url = LuaAPI.lua_tostring(L, 2);
					int _connectTimeoutMS = LuaAPI.xlua_tointeger(L, 3);
					int _ackExpireTimeMS = LuaAPI.xlua_tointeger(L, 4);
					
					Dpoch.SocketIO.SocketIO gen_ret = new Dpoch.SocketIO.SocketIO(_url, _connectTimeoutMS, _ackExpireTimeMS);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3))
				{
					string _url = LuaAPI.lua_tostring(L, 2);
					int _connectTimeoutMS = LuaAPI.xlua_tointeger(L, 3);
					
					Dpoch.SocketIO.SocketIO gen_ret = new Dpoch.SocketIO.SocketIO(_url, _connectTimeoutMS);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string _url = LuaAPI.lua_tostring(L, 2);
					
					Dpoch.SocketIO.SocketIO gen_ret = new Dpoch.SocketIO.SocketIO(_url);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Dpoch.SocketIO.SocketIO constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Connect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Connect(  );
                    
                    
                    
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
            
            
                Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Close(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_On(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _ev = LuaAPI.lua_tostring(L, 2);
                    System.Action<Dpoch.SocketIO.SocketIOEvent> _handler = translator.GetDelegate<System.Action<Dpoch.SocketIO.SocketIOEvent>>(L, 3);
                    
                    gen_to_be_invoked.On( _ev, _handler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Off(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _ev = LuaAPI.lua_tostring(L, 2);
                    System.Action<Dpoch.SocketIO.SocketIOEvent> _handler = translator.GetDelegate<System.Action<Dpoch.SocketIO.SocketIOEvent>>(L, 3);
                    
                    gen_to_be_invoked.Off( _ev, _handler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Emit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _ev = LuaAPI.lua_tostring(L, 2);
                    object[] _data = translator.GetParams<object>(L, 3);
                    
                    gen_to_be_invoked.Emit( _ev, _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EmitACK(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _ev = LuaAPI.lua_tostring(L, 2);
                    System.Action<Dpoch.SocketIO.SocketIO.ACKEvent> _ackHandler = translator.GetDelegate<System.Action<Dpoch.SocketIO.SocketIO.ACKEvent>>(L, 3);
                    object[] _data = translator.GetParams<object>(L, 4);
                    
                    gen_to_be_invoked.EmitACK( _ev, _ackHandler, _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAlive(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsAlive);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnOpen(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
                System.Action gen_delegate = translator.GetDelegate<System.Action>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action!");
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
			LuaAPI.luaL_error(L, "invalid arguments to Dpoch.SocketIO.SocketIO.OnOpen!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnConnectFailed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
                System.Action gen_delegate = translator.GetDelegate<System.Action>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnConnectFailed += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnConnectFailed -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Dpoch.SocketIO.SocketIO.OnConnectFailed!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnClose(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
                System.Action gen_delegate = translator.GetDelegate<System.Action>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action!");
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
			LuaAPI.luaL_error(L, "invalid arguments to Dpoch.SocketIO.SocketIO.OnClose!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnError(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Dpoch.SocketIO.SocketIO gen_to_be_invoked = (Dpoch.SocketIO.SocketIO)translator.FastGetCSObj(L, 1);
                System.Action<Dpoch.SocketIO.SocketIOException> gen_delegate = translator.GetDelegate<System.Action<Dpoch.SocketIO.SocketIOException>>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action<Dpoch.SocketIO.SocketIOException>!");
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
			LuaAPI.luaL_error(L, "invalid arguments to Dpoch.SocketIO.SocketIO.OnError!");
            return 0;
        }
        
		
		
    }
}
