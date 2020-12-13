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
    public class TaggedValueWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(TaggedValue);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 9, 9);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "IntValue", _g_get_IntValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FloatValue", _g_get_FloatValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StringValue", _g_get_StringValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Vector2Value", _g_get_Vector2Value);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Vector3Value", _g_get_Vector3Value);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "GameObjectValue", _g_get_GameObjectValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SpriteValue", _g_get_SpriteValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TextureValue", _g_get_TextureValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AudioClipValue", _g_get_AudioClipValue);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "IntValue", _s_set_IntValue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "FloatValue", _s_set_FloatValue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "StringValue", _s_set_StringValue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Vector2Value", _s_set_Vector2Value);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Vector3Value", _s_set_Vector3Value);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "GameObjectValue", _s_set_GameObjectValue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SpriteValue", _s_set_SpriteValue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TextureValue", _s_set_TextureValue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "AudioClipValue", _s_set_AudioClipValue);
            
			
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
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					TaggedValue gen_ret = new TaggedValue();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to TaggedValue constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IntValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.IntValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FloatValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.FloatValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StringValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.StringValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Vector2Value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Vector2Value);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Vector3Value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Vector3Value);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GameObjectValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.GameObjectValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SpriteValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.SpriteValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TextureValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.TextureValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AudioClipValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.AudioClipValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IntValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.IntValue = (TaggedInt[])translator.GetObject(L, 2, typeof(TaggedInt[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FloatValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.FloatValue = (TaggedFloat[])translator.GetObject(L, 2, typeof(TaggedFloat[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StringValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.StringValue = (TaggedString[])translator.GetObject(L, 2, typeof(TaggedString[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Vector2Value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Vector2Value = (TaggedVector2[])translator.GetObject(L, 2, typeof(TaggedVector2[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Vector3Value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Vector3Value = (TaggedVector3[])translator.GetObject(L, 2, typeof(TaggedVector3[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GameObjectValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.GameObjectValue = (TaggedGameObject[])translator.GetObject(L, 2, typeof(TaggedGameObject[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SpriteValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SpriteValue = (TaggedSprite[])translator.GetObject(L, 2, typeof(TaggedSprite[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TextureValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TextureValue = (TaggedTexture[])translator.GetObject(L, 2, typeof(TaggedTexture[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AudioClipValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TaggedValue gen_to_be_invoked = (TaggedValue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.AudioClipValue = (TaggedAudioClip[])translator.GetObject(L, 2, typeof(TaggedAudioClip[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
