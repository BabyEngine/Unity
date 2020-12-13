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
    public class SystemIOStreamWriterWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(System.IO.StreamWriter);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 3, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Close", _m_Close);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Flush", _m_Flush);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Write", _m_Write);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteAsync", _m_WriteAsync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteLineAsync", _m_WriteLineAsync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FlushAsync", _m_FlushAsync);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "AutoFlush", _g_get_AutoFlush);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BaseStream", _g_get_BaseStream);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Encoding", _g_get_Encoding);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "AutoFlush", _s_set_AutoFlush);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Null", System.IO.StreamWriter.Null);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.IO.Stream>(L, 2))
				{
					System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 2, typeof(System.IO.Stream));
					
					System.IO.StreamWriter gen_ret = new System.IO.StreamWriter(_stream);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<System.IO.Stream>(L, 2) && translator.Assignable<System.Text.Encoding>(L, 3))
				{
					System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 2, typeof(System.IO.Stream));
					System.Text.Encoding _encoding = (System.Text.Encoding)translator.GetObject(L, 3, typeof(System.Text.Encoding));
					
					System.IO.StreamWriter gen_ret = new System.IO.StreamWriter(_stream, _encoding);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && translator.Assignable<System.IO.Stream>(L, 2) && translator.Assignable<System.Text.Encoding>(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 2, typeof(System.IO.Stream));
					System.Text.Encoding _encoding = (System.Text.Encoding)translator.GetObject(L, 3, typeof(System.Text.Encoding));
					int _bufferSize = LuaAPI.xlua_tointeger(L, 4);
					
					System.IO.StreamWriter gen_ret = new System.IO.StreamWriter(_stream, _encoding, _bufferSize);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && translator.Assignable<System.IO.Stream>(L, 2) && translator.Assignable<System.Text.Encoding>(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5))
				{
					System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 2, typeof(System.IO.Stream));
					System.Text.Encoding _encoding = (System.Text.Encoding)translator.GetObject(L, 3, typeof(System.Text.Encoding));
					int _bufferSize = LuaAPI.xlua_tointeger(L, 4);
					bool _leaveOpen = LuaAPI.lua_toboolean(L, 5);
					
					System.IO.StreamWriter gen_ret = new System.IO.StreamWriter(_stream, _encoding, _bufferSize, _leaveOpen);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string _path = LuaAPI.lua_tostring(L, 2);
					
					System.IO.StreamWriter gen_ret = new System.IO.StreamWriter(_path);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3))
				{
					string _path = LuaAPI.lua_tostring(L, 2);
					bool _append = LuaAPI.lua_toboolean(L, 3);
					
					System.IO.StreamWriter gen_ret = new System.IO.StreamWriter(_path, _append);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3) && translator.Assignable<System.Text.Encoding>(L, 4))
				{
					string _path = LuaAPI.lua_tostring(L, 2);
					bool _append = LuaAPI.lua_toboolean(L, 3);
					System.Text.Encoding _encoding = (System.Text.Encoding)translator.GetObject(L, 4, typeof(System.Text.Encoding));
					
					System.IO.StreamWriter gen_ret = new System.IO.StreamWriter(_path, _append, _encoding);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3) && translator.Assignable<System.Text.Encoding>(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5))
				{
					string _path = LuaAPI.lua_tostring(L, 2);
					bool _append = LuaAPI.lua_toboolean(L, 3);
					System.Text.Encoding _encoding = (System.Text.Encoding)translator.GetObject(L, 4, typeof(System.Text.Encoding));
					int _bufferSize = LuaAPI.xlua_tointeger(L, 5);
					
					System.IO.StreamWriter gen_ret = new System.IO.StreamWriter(_path, _append, _encoding, _bufferSize);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to System.IO.StreamWriter constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Close(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.IO.StreamWriter gen_to_be_invoked = (System.IO.StreamWriter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Close(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Flush(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.IO.StreamWriter gen_to_be_invoked = (System.IO.StreamWriter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Flush(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Write(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.IO.StreamWriter gen_to_be_invoked = (System.IO.StreamWriter)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.Write( _value );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<char[]>(L, 2)) 
                {
                    char[] _buffer = (char[])translator.GetObject(L, 2, typeof(char[]));
                    
                    gen_to_be_invoked.Write( _buffer );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.Write( _value );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<char[]>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    char[] _buffer = (char[])translator.GetObject(L, 2, typeof(char[]));
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    int _count = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.Write( _buffer, _index, _count );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.IO.StreamWriter.Write!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.IO.StreamWriter gen_to_be_invoked = (System.IO.StreamWriter)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Threading.Tasks.Task gen_ret = gen_to_be_invoked.WriteAsync( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 2);
                    
                        System.Threading.Tasks.Task gen_ret = gen_to_be_invoked.WriteAsync( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<char[]>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    char[] _buffer = (char[])translator.GetObject(L, 2, typeof(char[]));
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    int _count = LuaAPI.xlua_tointeger(L, 4);
                    
                        System.Threading.Tasks.Task gen_ret = gen_to_be_invoked.WriteAsync( _buffer, _index, _count );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.IO.StreamWriter.WriteAsync!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteLineAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.IO.StreamWriter gen_to_be_invoked = (System.IO.StreamWriter)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        System.Threading.Tasks.Task gen_ret = gen_to_be_invoked.WriteLineAsync(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Threading.Tasks.Task gen_ret = gen_to_be_invoked.WriteLineAsync( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 2);
                    
                        System.Threading.Tasks.Task gen_ret = gen_to_be_invoked.WriteLineAsync( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<char[]>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    char[] _buffer = (char[])translator.GetObject(L, 2, typeof(char[]));
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    int _count = LuaAPI.xlua_tointeger(L, 4);
                    
                        System.Threading.Tasks.Task gen_ret = gen_to_be_invoked.WriteLineAsync( _buffer, _index, _count );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.IO.StreamWriter.WriteLineAsync!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FlushAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.IO.StreamWriter gen_to_be_invoked = (System.IO.StreamWriter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Threading.Tasks.Task gen_ret = gen_to_be_invoked.FlushAsync(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoFlush(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.IO.StreamWriter gen_to_be_invoked = (System.IO.StreamWriter)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.AutoFlush);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseStream(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.IO.StreamWriter gen_to_be_invoked = (System.IO.StreamWriter)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.BaseStream);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Encoding(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.IO.StreamWriter gen_to_be_invoked = (System.IO.StreamWriter)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Encoding);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AutoFlush(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.IO.StreamWriter gen_to_be_invoked = (System.IO.StreamWriter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.AutoFlush = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
