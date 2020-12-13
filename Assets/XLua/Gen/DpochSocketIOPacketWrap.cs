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
    public class DpochSocketIOPacketWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Dpoch.SocketIO.Packet);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 7, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Encode", _m_Encode);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnginePacketType", _g_get_EnginePacketType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SocketPacketType", _g_get_SocketPacketType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ID", _g_get_ID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Nsp", _g_get_Nsp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Attachments", _g_get_Attachments);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsComplete", _g_get_IsComplete);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Data", _g_get_Data);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 7, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Ping", _m_Ping_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Pong", _m_Pong_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Event", _m_Event_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Ack", _m_Ack_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BinaryPacket", _m_BinaryPacket_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Parse", _m_Parse_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Dpoch.SocketIO.Packet does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Ping_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        Dpoch.SocketIO.Packet gen_ret = Dpoch.SocketIO.Packet.Ping(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Pong_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        Dpoch.SocketIO.Packet gen_ret = Dpoch.SocketIO.Packet.Pong(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Event_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object[]>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _ev = LuaAPI.lua_tostring(L, 1);
                    object[] _data = (object[])translator.GetObject(L, 2, typeof(object[]));
                    int _id = LuaAPI.xlua_tointeger(L, 3);
                    
                        Dpoch.SocketIO.Packet gen_ret = Dpoch.SocketIO.Packet.Event( _ev, _data, _id );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object[]>(L, 2)) 
                {
                    string _ev = LuaAPI.lua_tostring(L, 1);
                    object[] _data = (object[])translator.GetObject(L, 2, typeof(object[]));
                    
                        Dpoch.SocketIO.Packet gen_ret = Dpoch.SocketIO.Packet.Event( _ev, _data );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Dpoch.SocketIO.Packet.Event!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Ack_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    object[] _data = (object[])translator.GetObject(L, 2, typeof(object[]));
                    
                        Dpoch.SocketIO.Packet gen_ret = Dpoch.SocketIO.Packet.Ack( _id, _data );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BinaryPacket_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    byte[] _data = LuaAPI.lua_tobytes(L, 1);
                    
                        byte[] gen_ret = Dpoch.SocketIO.Packet.BinaryPacket( _data );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Encode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Dpoch.SocketIO.Packet gen_to_be_invoked = (Dpoch.SocketIO.Packet)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.Encode(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Parse_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _packetData = LuaAPI.lua_tostring(L, 1);
                    
                        Dpoch.SocketIO.Packet gen_ret = Dpoch.SocketIO.Packet.Parse( _packetData );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnginePacketType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.Packet gen_to_be_invoked = (Dpoch.SocketIO.Packet)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.EnginePacketType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SocketPacketType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.Packet gen_to_be_invoked = (Dpoch.SocketIO.Packet)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.SocketPacketType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.Packet gen_to_be_invoked = (Dpoch.SocketIO.Packet)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Nsp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.Packet gen_to_be_invoked = (Dpoch.SocketIO.Packet)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Nsp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Attachments(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.Packet gen_to_be_invoked = (Dpoch.SocketIO.Packet)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Attachments);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsComplete(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Dpoch.SocketIO.Packet gen_to_be_invoked = (Dpoch.SocketIO.Packet)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsComplete);
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
			
                Dpoch.SocketIO.Packet gen_to_be_invoked = (Dpoch.SocketIO.Packet)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Data);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
