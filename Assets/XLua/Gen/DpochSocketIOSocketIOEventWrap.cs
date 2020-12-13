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
    public class DpochSocketIOSocketIOEventWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Dpoch.SocketIO.SocketIOEvent);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 4, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Acknowledge", _m_Acknowledge);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Name", _g_get_Name);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Data", _g_get_Data);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsAcknowledgable", _g_get_IsAcknowledgable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "packet", _g_get_packet);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "packet", _s_set_packet);
            
			
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
				if(LuaAPI.lua_gettop(L) == 5 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && translator.Assignable<Newtonsoft.Json.Linq.JArray>(L, 3) && translator.Assignable<System.Action<object[]>>(L, 4) && translator.Assignable<Dpoch.SocketIO.Packet>(L, 5))
				{
					string _name = LuaAPI.lua_tostring(L, 2);
					Newtonsoft.Json.Linq.JArray _data = (Newtonsoft.Json.Linq.JArray)translator.GetObject(L, 3, typeof(Newtonsoft.Json.Linq.JArray));
					System.Action<object[]> _ack = translator.GetDelegate<System.Action<object[]>>(L, 4);
					Dpoch.SocketIO.Packet _packet = (Dpoch.SocketIO.Packet)translator.GetObject(L, 5, typeof(Dpoch.SocketIO.Packet));
					
					Dpoch.SocketIO.SocketIOEvent gen_ret = new Dpoch.SocketIO.SocketIOEvent(_name, _data, _ack, _packet);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Dpoch.SocketIO.SocketIOEvent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Acknowledge(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Dpoch.SocketIO.SocketIOEvent gen_to_be_invoked = (Dpoch.SocketIO.SocketIOEvent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _data = translator.GetParams<object>(L, 2);
                    
                    gen_to_be_invoked.Acknowledge( _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.SocketIOEvent gen_to_be_invoked = (Dpoch.SocketIO.SocketIOEvent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Name);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.SocketIOEvent gen_to_be_invoked = (Dpoch.SocketIO.SocketIOEvent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Data);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAcknowledgable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.SocketIOEvent gen_to_be_invoked = (Dpoch.SocketIO.SocketIOEvent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsAcknowledgable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_packet(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.SocketIOEvent gen_to_be_invoked = (Dpoch.SocketIO.SocketIOEvent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.packet);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_packet(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.SocketIOEvent gen_to_be_invoked = (Dpoch.SocketIO.SocketIOEvent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.packet = (Dpoch.SocketIO.Packet)translator.GetObject(L, 2, typeof(Dpoch.SocketIO.Packet));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
