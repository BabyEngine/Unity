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
    public class UnityEngineNetworkingUnityWebRequestTextureWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Networking.UnityWebRequestTexture);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTexture", _m_GetTexture_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.Networking.UnityWebRequestTexture does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTexture_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _uri = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestTexture.GetTexture( _uri );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Uri>(L, 1)) 
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestTexture.GetTexture( _uri );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    string _uri = LuaAPI.lua_tostring(L, 1);
                    bool _nonReadable = LuaAPI.lua_toboolean(L, 2);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestTexture.GetTexture( _uri, _nonReadable );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Uri>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    bool _nonReadable = LuaAPI.lua_toboolean(L, 2);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestTexture.GetTexture( _uri, _nonReadable );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Networking.UnityWebRequestTexture.GetTexture!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
