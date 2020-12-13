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
    public class UnityEngineNetworkingUnityWebRequestAssetBundleWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Networking.UnityWebRequestAssetBundle);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAssetBundle", _m_GetAssetBundle_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.Networking.UnityWebRequestAssetBundle does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAssetBundle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _uri = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Uri>(L, 1)) 
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _uri = LuaAPI.lua_tostring(L, 1);
                    uint _crc = LuaAPI.xlua_touint(L, 2);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _crc );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Uri>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    uint _crc = LuaAPI.xlua_touint(L, 2);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _crc );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _uri = LuaAPI.lua_tostring(L, 1);
                    uint _version = LuaAPI.xlua_touint(L, 2);
                    uint _crc = LuaAPI.xlua_touint(L, 3);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _version, _crc );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.Uri>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    uint _version = LuaAPI.xlua_touint(L, 2);
                    uint _crc = LuaAPI.xlua_touint(L, 3);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _version, _crc );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Hash128>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _uri = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.Hash128 _hash;translator.Get(L, 2, out _hash);
                    uint _crc = LuaAPI.xlua_touint(L, 3);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _hash, _crc );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Hash128>(L, 2)) 
                {
                    string _uri = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.Hash128 _hash;translator.Get(L, 2, out _hash);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _hash );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.Uri>(L, 1)&& translator.Assignable<UnityEngine.Hash128>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    UnityEngine.Hash128 _hash;translator.Get(L, 2, out _hash);
                    uint _crc = LuaAPI.xlua_touint(L, 3);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _hash, _crc );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Uri>(L, 1)&& translator.Assignable<UnityEngine.Hash128>(L, 2)) 
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    UnityEngine.Hash128 _hash;translator.Get(L, 2, out _hash);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _hash );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.CachedAssetBundle>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _uri = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.CachedAssetBundle _cachedAssetBundle;translator.Get(L, 2, out _cachedAssetBundle);
                    uint _crc = LuaAPI.xlua_touint(L, 3);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _cachedAssetBundle, _crc );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.CachedAssetBundle>(L, 2)) 
                {
                    string _uri = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.CachedAssetBundle _cachedAssetBundle;translator.Get(L, 2, out _cachedAssetBundle);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _cachedAssetBundle );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.Uri>(L, 1)&& translator.Assignable<UnityEngine.CachedAssetBundle>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    UnityEngine.CachedAssetBundle _cachedAssetBundle;translator.Get(L, 2, out _cachedAssetBundle);
                    uint _crc = LuaAPI.xlua_touint(L, 3);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _cachedAssetBundle, _crc );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Uri>(L, 1)&& translator.Assignable<UnityEngine.CachedAssetBundle>(L, 2)) 
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    UnityEngine.CachedAssetBundle _cachedAssetBundle;translator.Get(L, 2, out _cachedAssetBundle);
                    
                        UnityEngine.Networking.UnityWebRequest gen_ret = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle( _uri, _cachedAssetBundle );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
