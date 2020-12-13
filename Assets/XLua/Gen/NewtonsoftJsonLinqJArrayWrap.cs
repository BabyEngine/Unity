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
    public class NewtonsoftJsonLinqJArrayWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Newtonsoft.Json.Linq.JArray);
			Utils.BeginObjectRegister(type, L, translator, 0, 12, 2, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteTo", _m_WriteTo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_Item", _m_get_Item);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_Item", _m_set_Item);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IndexOf", _m_IndexOf);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Insert", _m_Insert);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveAt", _m_RemoveAt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEnumerator", _m_GetEnumerator);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Add", _m_Add);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Contains", _m_Contains);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CopyTo", _m_CopyTo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Remove", _m_Remove);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Type", _g_get_Type);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsReadOnly", _g_get_IsReadOnly);
            
			
			
			Utils.EndObjectRegister(type, L, translator, __CSIndexer, __NewIndexer,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Load", _m_Load_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Parse", _m_Parse_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FromObject", _m_FromObject_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Newtonsoft.Json.Linq.JArray gen_ret = new Newtonsoft.Json.Linq.JArray();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Newtonsoft.Json.Linq.JArray>(L, 2))
				{
					Newtonsoft.Json.Linq.JArray _other = (Newtonsoft.Json.Linq.JArray)translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JArray));
					
					Newtonsoft.Json.Linq.JArray gen_ret = new Newtonsoft.Json.Linq.JArray(_other);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) >= 1 && (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || translator.Assignable<object>(L, 2)))
				{
					object[] _content = translator.GetParams<object>(L, 2);
					
					Newtonsoft.Json.Linq.JArray gen_ret = new Newtonsoft.Json.Linq.JArray(_content);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<object>(L, 2))
				{
					object _content = translator.GetObject(L, 2, typeof(object));
					
					Newtonsoft.Json.Linq.JArray gen_ret = new Newtonsoft.Json.Linq.JArray(_content);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JArray constructor!");
            
        }
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __CSIndexer(RealStatePtr L)
        {
			try {
			    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				
				if (translator.Assignable<Newtonsoft.Json.Linq.JArray>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					
					Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
					int index = LuaAPI.xlua_tointeger(L, 2);
					LuaAPI.lua_pushboolean(L, true);
					translator.Push(L, gen_to_be_invoked[index]);
					return 2;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			
            LuaAPI.lua_pushboolean(L, false);
			return 1;
        }
		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __NewIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
			try {
				
				if (translator.Assignable<Newtonsoft.Json.Linq.JArray>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 3))
				{
					
					Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
					int key = LuaAPI.xlua_tointeger(L, 2);
					gen_to_be_invoked[key] = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 3, typeof(Newtonsoft.Json.Linq.JToken));
					LuaAPI.lua_pushboolean(L, true);
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			
			LuaAPI.lua_pushboolean(L, false);
            return 1;
        }
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Load_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<Newtonsoft.Json.JsonReader>(L, 1)) 
                {
                    Newtonsoft.Json.JsonReader _reader = (Newtonsoft.Json.JsonReader)translator.GetObject(L, 1, typeof(Newtonsoft.Json.JsonReader));
                    
                        Newtonsoft.Json.Linq.JArray gen_ret = Newtonsoft.Json.Linq.JArray.Load( _reader );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.JsonReader>(L, 1)&& translator.Assignable<Newtonsoft.Json.Linq.JsonLoadSettings>(L, 2)) 
                {
                    Newtonsoft.Json.JsonReader _reader = (Newtonsoft.Json.JsonReader)translator.GetObject(L, 1, typeof(Newtonsoft.Json.JsonReader));
                    Newtonsoft.Json.Linq.JsonLoadSettings _settings = (Newtonsoft.Json.Linq.JsonLoadSettings)translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JsonLoadSettings));
                    
                        Newtonsoft.Json.Linq.JArray gen_ret = Newtonsoft.Json.Linq.JArray.Load( _reader, _settings );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JArray.Load!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Parse_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _json = LuaAPI.lua_tostring(L, 1);
                    
                        Newtonsoft.Json.Linq.JArray gen_ret = Newtonsoft.Json.Linq.JArray.Parse( _json );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Newtonsoft.Json.Linq.JsonLoadSettings>(L, 2)) 
                {
                    string _json = LuaAPI.lua_tostring(L, 1);
                    Newtonsoft.Json.Linq.JsonLoadSettings _settings = (Newtonsoft.Json.Linq.JsonLoadSettings)translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JsonLoadSettings));
                    
                        Newtonsoft.Json.Linq.JArray gen_ret = Newtonsoft.Json.Linq.JArray.Parse( _json, _settings );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JArray.Parse!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromObject_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _o = translator.GetObject(L, 1, typeof(object));
                    
                        Newtonsoft.Json.Linq.JArray gen_ret = Newtonsoft.Json.Linq.JArray.FromObject( _o );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<Newtonsoft.Json.JsonSerializer>(L, 2)) 
                {
                    object _o = translator.GetObject(L, 1, typeof(object));
                    Newtonsoft.Json.JsonSerializer _jsonSerializer = (Newtonsoft.Json.JsonSerializer)translator.GetObject(L, 2, typeof(Newtonsoft.Json.JsonSerializer));
                    
                        Newtonsoft.Json.Linq.JArray gen_ret = Newtonsoft.Json.Linq.JArray.FromObject( _o, _jsonSerializer );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JArray.FromObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteTo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Newtonsoft.Json.JsonWriter _writer = (Newtonsoft.Json.JsonWriter)translator.GetObject(L, 2, typeof(Newtonsoft.Json.JsonWriter));
                    Newtonsoft.Json.JsonConverter[] _converters = translator.GetParams<Newtonsoft.Json.JsonConverter>(L, 3);
                    
                    gen_to_be_invoked.WriteTo( _writer, _converters );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_get_Item(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
					object key = translator.GetObject(L, 2, typeof(object));
					translator.Push(L, gen_to_be_invoked[key]);
					
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_set_Item(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
					object key = translator.GetObject(L, 2, typeof(object));
					gen_to_be_invoked[key] = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 3, typeof(Newtonsoft.Json.Linq.JToken));
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IndexOf(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Newtonsoft.Json.Linq.JToken _item = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JToken));
                    
                        int gen_ret = gen_to_be_invoked.IndexOf( _item );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Insert(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    Newtonsoft.Json.Linq.JToken _item = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 3, typeof(Newtonsoft.Json.Linq.JToken));
                    
                    gen_to_be_invoked.Insert( _index, _item );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAt(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.RemoveAt( _index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEnumerator(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.IEnumerator<Newtonsoft.Json.Linq.JToken> gen_ret = gen_to_be_invoked.GetEnumerator(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Add(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Newtonsoft.Json.Linq.JToken _item = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JToken));
                    
                    gen_to_be_invoked.Add( _item );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Contains(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Newtonsoft.Json.Linq.JToken _item = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JToken));
                    
                        bool gen_ret = gen_to_be_invoked.Contains( _item );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CopyTo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Newtonsoft.Json.Linq.JToken[] _array = (Newtonsoft.Json.Linq.JToken[])translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JToken[]));
                    int _arrayIndex = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.CopyTo( _array, _arrayIndex );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Remove(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Newtonsoft.Json.Linq.JToken _item = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JToken));
                    
                        bool gen_ret = gen_to_be_invoked.Remove( _item );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Type(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Type);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsReadOnly(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Newtonsoft.Json.Linq.JArray gen_to_be_invoked = (Newtonsoft.Json.Linq.JArray)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsReadOnly);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
