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
    public class WSClientWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(WSClient);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 5, 5);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Connect", _m_Connect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Send", _m_Send);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "client", _g_get_client);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onOpen", _g_get_onOpen);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onData", _g_get_onData);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onError", _g_get_onError);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onClose", _g_get_onClose);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "client", _s_set_client);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onOpen", _s_set_onOpen);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onData", _s_set_onData);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onError", _s_set_onError);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onClose", _s_set_onClose);
            
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<BabyEngine.LooperManager>(L, 2))
				{
					BabyEngine.LooperManager _looper = (BabyEngine.LooperManager)translator.GetObject(L, 2, typeof(BabyEngine.LooperManager));
					
					WSClient gen_ret = new WSClient(_looper);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to WSClient constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Connect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.Connect( _url );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Send(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] _data = LuaAPI.lua_tobytes(L, 2);
                    
                    gen_to_be_invoked.Send( _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_client(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.client);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onOpen(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onOpen);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onData);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onError(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onError);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onClose(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onClose);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_client(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.client = (WebSocketSharp.WebSocket)translator.GetObject(L, 2, typeof(WebSocketSharp.WebSocket));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onOpen(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onOpen = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onData = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onError(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onError = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onClose(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WSClient gen_to_be_invoked = (WSClient)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onClose = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
