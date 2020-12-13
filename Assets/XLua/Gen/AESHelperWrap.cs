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
    public class AESHelperWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(AESHelper);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 14, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "EncryptBytes", _m_EncryptBytes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DecryptBytes", _m_DecryptBytes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EncryptHexStrings", _m_EncryptHexStrings_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DecryptHexStrings", _m_DecryptHexStrings_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HexStringToByteArray", _m_HexStringToByteArray_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ByteArrayToHexString", _m_ByteArrayToHexString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Encrypt", _m_Encrypt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Decrpyt", _m_Decrpyt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EncryptString", _m_EncryptString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DecrpytString", _m_DecrpytString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Base64Decode", _m_Base64Decode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Base64Encode", _m_Base64Encode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "JavaBase64", _m_JavaBase64_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					AESHelper gen_ret = new AESHelper();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to AESHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EncryptBytes_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    byte[] _input = LuaAPI.lua_tobytes(L, 1);
                    byte[] _aesKey = LuaAPI.lua_tobytes(L, 2);
                    byte[] _aesIV = LuaAPI.lua_tobytes(L, 3);
                    
                        byte[] gen_ret = AESHelper.EncryptBytes( _input, _aesKey, _aesIV );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DecryptBytes_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    byte[] _encryptedOutput = LuaAPI.lua_tobytes(L, 1);
                    byte[] _aesKey = LuaAPI.lua_tobytes(L, 2);
                    byte[] _aesIV = LuaAPI.lua_tobytes(L, 3);
                    
                        byte[] gen_ret = AESHelper.DecryptBytes( _encryptedOutput, _aesKey, _aesIV );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EncryptHexStrings_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _input = LuaAPI.lua_tostring(L, 1);
                    byte[] _aesKey = LuaAPI.lua_tobytes(L, 2);
                    byte[] _aesIV = LuaAPI.lua_tobytes(L, 3);
                    
                        string gen_ret = AESHelper.EncryptHexStrings( _input, _aesKey, _aesIV );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _input = LuaAPI.lua_tostring(L, 1);
                    string _aesKey = LuaAPI.lua_tostring(L, 2);
                    string _aesIV = LuaAPI.lua_tostring(L, 3);
                    
                        string gen_ret = AESHelper.EncryptHexStrings( _input, _aesKey, _aesIV );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AESHelper.EncryptHexStrings!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DecryptHexStrings_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _encryptedOutput = LuaAPI.lua_tostring(L, 1);
                    byte[] _aesKey = LuaAPI.lua_tobytes(L, 2);
                    byte[] _aesIV = LuaAPI.lua_tobytes(L, 3);
                    
                        string gen_ret = AESHelper.DecryptHexStrings( _encryptedOutput, _aesKey, _aesIV );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _encryptedOutput = LuaAPI.lua_tostring(L, 1);
                    string _aesKey = LuaAPI.lua_tostring(L, 2);
                    string _aesIV = LuaAPI.lua_tostring(L, 3);
                    
                        string gen_ret = AESHelper.DecryptHexStrings( _encryptedOutput, _aesKey, _aesIV );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AESHelper.DecryptHexStrings!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HexStringToByteArray_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _s = LuaAPI.lua_tostring(L, 1);
                    
                        byte[] gen_ret = AESHelper.HexStringToByteArray( _s );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ByteArrayToHexString_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 1);
                    
                        string gen_ret = AESHelper.ByteArrayToHexString( _bytes );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Encrypt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    byte[] _data = LuaAPI.lua_tobytes(L, 2);
                    
                        byte[] gen_ret = AESHelper.Encrypt( _key, _data );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Decrpyt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    byte[] _data = LuaAPI.lua_tobytes(L, 2);
                    
                        byte[] gen_ret = AESHelper.Decrpyt( _key, _data );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EncryptString_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    string _str = LuaAPI.lua_tostring(L, 2);
                    
                        byte[] gen_ret = AESHelper.EncryptString( _key, _str );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DecrpytString_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    string _str = LuaAPI.lua_tostring(L, 2);
                    
                        byte[] gen_ret = AESHelper.DecrpytString( _key, _str );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Base64Decode_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _i = LuaAPI.lua_tostring(L, 1);
                    
                        byte[] gen_ret = AESHelper.Base64Decode( _i );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Base64Encode_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    byte[] _i = LuaAPI.lua_tobytes(L, 1);
                    
                        string gen_ret = AESHelper.Base64Encode( _i );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_JavaBase64_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    byte[] _by = LuaAPI.lua_tobytes(L, 1);
                    
                        string gen_ret = AESHelper.JavaBase64( _by );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
