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
    public class UnityEngineAnimationsScaleConstraintWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Animations.ScaleConstraint);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 7, 6);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSources", _m_GetSources);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSources", _m_SetSources);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddSource", _m_AddSource);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveSource", _m_RemoveSource);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSource", _m_GetSource);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSource", _m_SetSource);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "weight", _g_get_weight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scaleAtRest", _g_get_scaleAtRest);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scaleOffset", _g_get_scaleOffset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scalingAxis", _g_get_scalingAxis);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "constraintActive", _g_get_constraintActive);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "locked", _g_get_locked);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sourceCount", _g_get_sourceCount);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "weight", _s_set_weight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scaleAtRest", _s_set_scaleAtRest);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scaleOffset", _s_set_scaleOffset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scalingAxis", _s_set_scalingAxis);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "constraintActive", _s_set_constraintActive);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "locked", _s_set_locked);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.Animations.ScaleConstraint does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSources(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
            
            
                
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
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.weight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scaleAtRest(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.scaleAtRest);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scaleOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.scaleOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scalingAxis(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.scalingAxis);
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
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
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
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.locked);
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
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
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
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.weight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scaleAtRest(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.scaleAtRest = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scaleOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.scaleOffset = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scalingAxis(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
                UnityEngine.Animations.Axis gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.scalingAxis = gen_value;
            
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
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
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
			
                UnityEngine.Animations.ScaleConstraint gen_to_be_invoked = (UnityEngine.Animations.ScaleConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.locked = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
