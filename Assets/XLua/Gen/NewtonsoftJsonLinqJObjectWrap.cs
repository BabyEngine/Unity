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
    public class NewtonsoftJsonLinqJObjectWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Newtonsoft.Json.Linq.JObject);
			Utils.BeginObjectRegister(type, L, translator, 0, 12, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Properties", _m_Properties);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Property", _m_Property);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PropertyValues", _m_PropertyValues);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_Item", _m_get_Item);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_Item", _m_set_Item);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteTo", _m_WriteTo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetValue", _m_GetValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TryGetValue", _m_TryGetValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Add", _m_Add);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Remove", _m_Remove);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEnumerator", _m_GetEnumerator);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PropertyChanged", _e_PropertyChanged);
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Type", _g_get_Type);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
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
					
					Newtonsoft.Json.Linq.JObject gen_ret = new Newtonsoft.Json.Linq.JObject();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 2))
				{
					Newtonsoft.Json.Linq.JObject _other = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JObject));
					
					Newtonsoft.Json.Linq.JObject gen_ret = new Newtonsoft.Json.Linq.JObject(_other);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) >= 1 && (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || translator.Assignable<object>(L, 2)))
				{
					object[] _content = translator.GetParams<object>(L, 2);
					
					Newtonsoft.Json.Linq.JObject gen_ret = new Newtonsoft.Json.Linq.JObject(_content);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<object>(L, 2))
				{
					object _content = translator.GetObject(L, 2, typeof(object));
					
					Newtonsoft.Json.Linq.JObject gen_ret = new Newtonsoft.Json.Linq.JObject(_content);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JObject constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Properties(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JProperty> gen_ret = gen_to_be_invoked.Properties(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Property(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                        Newtonsoft.Json.Linq.JProperty gen_ret = gen_to_be_invoked.Property( _name );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PropertyValues(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        Newtonsoft.Json.Linq.JEnumerable<Newtonsoft.Json.Linq.JToken> gen_ret = gen_to_be_invoked.PropertyValues(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
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
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    
					object key = translator.GetObject(L, 2, typeof(object));
					translator.Push(L, gen_to_be_invoked[key]);
					
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    
					string key = LuaAPI.lua_tostring(L, 2);
					translator.Push(L, gen_to_be_invoked[key]);
					
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JObject.get_Item!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_set_Item(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<object>(L, 2)&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 3)) 
                {
                    
					object key = translator.GetObject(L, 2, typeof(object));
					gen_to_be_invoked[key] = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 3, typeof(Newtonsoft.Json.Linq.JToken));
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 3)) 
                {
                    
					string key = LuaAPI.lua_tostring(L, 2);
					gen_to_be_invoked[key] = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 3, typeof(Newtonsoft.Json.Linq.JToken));
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JObject.set_Item!");
            
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
                    
                        Newtonsoft.Json.Linq.JObject gen_ret = Newtonsoft.Json.Linq.JObject.Load( _reader );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.JsonReader>(L, 1)&& translator.Assignable<Newtonsoft.Json.Linq.JsonLoadSettings>(L, 2)) 
                {
                    Newtonsoft.Json.JsonReader _reader = (Newtonsoft.Json.JsonReader)translator.GetObject(L, 1, typeof(Newtonsoft.Json.JsonReader));
                    Newtonsoft.Json.Linq.JsonLoadSettings _settings = (Newtonsoft.Json.Linq.JsonLoadSettings)translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JsonLoadSettings));
                    
                        Newtonsoft.Json.Linq.JObject gen_ret = Newtonsoft.Json.Linq.JObject.Load( _reader, _settings );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JObject.Load!");
            
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
                    
                        Newtonsoft.Json.Linq.JObject gen_ret = Newtonsoft.Json.Linq.JObject.Parse( _json );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Newtonsoft.Json.Linq.JsonLoadSettings>(L, 2)) 
                {
                    string _json = LuaAPI.lua_tostring(L, 1);
                    Newtonsoft.Json.Linq.JsonLoadSettings _settings = (Newtonsoft.Json.Linq.JsonLoadSettings)translator.GetObject(L, 2, typeof(Newtonsoft.Json.Linq.JsonLoadSettings));
                    
                        Newtonsoft.Json.Linq.JObject gen_ret = Newtonsoft.Json.Linq.JObject.Parse( _json, _settings );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JObject.Parse!");
            
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
                    
                        Newtonsoft.Json.Linq.JObject gen_ret = Newtonsoft.Json.Linq.JObject.FromObject( _o );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<Newtonsoft.Json.JsonSerializer>(L, 2)) 
                {
                    object _o = translator.GetObject(L, 1, typeof(object));
                    Newtonsoft.Json.JsonSerializer _jsonSerializer = (Newtonsoft.Json.JsonSerializer)translator.GetObject(L, 2, typeof(Newtonsoft.Json.JsonSerializer));
                    
                        Newtonsoft.Json.Linq.JObject gen_ret = Newtonsoft.Json.Linq.JObject.FromObject( _o, _jsonSerializer );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JObject.FromObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteTo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _propertyName = LuaAPI.lua_tostring(L, 2);
                    
                        Newtonsoft.Json.Linq.JToken gen_ret = gen_to_be_invoked.GetValue( _propertyName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.StringComparison>(L, 3)) 
                {
                    string _propertyName = LuaAPI.lua_tostring(L, 2);
                    System.StringComparison _comparison;translator.Get(L, 3, out _comparison);
                    
                        Newtonsoft.Json.Linq.JToken gen_ret = gen_to_be_invoked.GetValue( _propertyName, _comparison );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JObject.GetValue!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryGetValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _propertyName = LuaAPI.lua_tostring(L, 2);
                    Newtonsoft.Json.Linq.JToken _value;
                    
                        bool gen_ret = gen_to_be_invoked.TryGetValue( _propertyName, out _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _value);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.StringComparison>(L, 3)) 
                {
                    string _propertyName = LuaAPI.lua_tostring(L, 2);
                    System.StringComparison _comparison;translator.Get(L, 3, out _comparison);
                    Newtonsoft.Json.Linq.JToken _value;
                    
                        bool gen_ret = gen_to_be_invoked.TryGetValue( _propertyName, _comparison, out _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _value);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JObject.TryGetValue!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Add(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _propertyName = LuaAPI.lua_tostring(L, 2);
                    Newtonsoft.Json.Linq.JToken _value = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 3, typeof(Newtonsoft.Json.Linq.JToken));
                    
                    gen_to_be_invoked.Add( _propertyName, _value );
                    
                    
                    
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
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _propertyName = LuaAPI.lua_tostring(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.Remove( _propertyName );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
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
            
            
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>> gen_ret = gen_to_be_invoked.GetEnumerator(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
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
			
                Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Type);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_PropertyChanged(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Newtonsoft.Json.Linq.JObject gen_to_be_invoked = (Newtonsoft.Json.Linq.JObject)translator.FastGetCSObj(L, 1);
                System.ComponentModel.PropertyChangedEventHandler gen_delegate = translator.GetDelegate<System.ComponentModel.PropertyChangedEventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.ComponentModel.PropertyChangedEventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.PropertyChanged += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.PropertyChanged -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Newtonsoft.Json.Linq.JObject.PropertyChanged!");
            return 0;
        }
        
		
		
    }
}
