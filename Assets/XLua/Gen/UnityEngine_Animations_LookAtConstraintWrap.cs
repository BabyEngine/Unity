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
    public class UnityEngineAnimationsLookAtConstraintWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Animations.LookAtConstraint);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 9, 8);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSources", _m_GetSources);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSources", _m_SetSources);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddSource", _m_AddSource);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveSource", _m_RemoveSource);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSource", _m_GetSource);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSource", _m_SetSource);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "weight", _g_get_weight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "roll", _g_get_roll);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "constraintActive", _g_get_constraintActive);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "locked", _g_get_locked);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotationAtRest", _g_get_rotationAtRest);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotationOffset", _g_get_rotationOffset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "worldUpObject", _g_get_worldUpObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useUpObject", _g_get_useUpObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sourceCount", _g_get_sourceCount);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "weight", _s_set_weight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "roll", _s_set_roll);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "constraintActive", _s_set_constraintActive);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "locked", _s_set_locked);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rotationAtRest", _s_set_rotationAtRest);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rotationOffset", _s_set_rotationOffset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "worldUpObject", _s_set_worldUpObject);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useUpObject", _s_set_useUpObject);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.Animations.LookAtConstraint does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSources(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<UnityEngine.Animations.ConstraintSource> _sources = (System.Collections.Generic.List<UnityEngine.Animations.ConstraintSource>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Animations.ConstraintSource>));
                    
                    gen_to_be_invoked.GetSources( _sources );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSources(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<UnityEngine.Animations.ConstraintSource> _sources = (System.Collections.Generic.List<UnityEngine.Animations.ConstraintSource>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Animations.ConstraintSource>));
                    
                    gen_to_be_invoked.SetSources( _sources );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSource(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Animations.ConstraintSource _source;translator.Get(L, 2, out _source);
                    
                        var gen_ret = gen_to_be_invoked.AddSource( _source );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveSource(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.RemoveSource( _index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSource(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSource( _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSource(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Animations.ConstraintSource _source;translator.Get(L, 3, out _source);
                    
                    gen_to_be_invoked.SetSource( _index, _source );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_weight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.weight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_roll(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.roll);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_constraintActive(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.constraintActive);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_locked(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.locked);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rotationAtRest(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.rotationAtRest);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rotationOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.rotationOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_worldUpObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.worldUpObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useUpObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useUpObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sourceCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.sourceCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_weight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.weight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_roll(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.roll = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_constraintActive(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.constraintActive = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_locked(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.locked = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rotationAtRest(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.rotationAtRest = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rotationOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.rotationOffset = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_worldUpObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.worldUpObject = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useUpObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.LookAtConstraint gen_to_be_invoked = (UnityEngine.Animations.LookAtConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useUpObject = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
