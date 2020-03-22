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
using DG.Tweening;

namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>);
			Utils.BeginObjectRegister(type, L, translator, 0, 28, 6, 6);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangeStartValue", _m_ChangeStartValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangeEndValue", _m_ChangeEndValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangeValues", _m_ChangeValues);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Pause", _m_Pause);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Play", _m_Play);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAutoKill", _m_SetAutoKill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetId", _m_SetId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetLink", _m_SetLink);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTarget", _m_SetTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetLoops", _m_SetLoops);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetEase", _m_SetEase);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRecyclable", _m_SetRecyclable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetUpdate", _m_SetUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStart", _m_OnStart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPlay", _m_OnPlay);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPause", _m_OnPause);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnRewind", _m_OnRewind);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnUpdate", _m_OnUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStepComplete", _m_OnStepComplete);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnComplete", _m_OnComplete);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnKill", _m_OnKill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnWaypointChange", _m_OnWaypointChange);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAs", _m_SetAs);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "From", _m_From);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDelay", _m_SetDelay);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRelative", _m_SetRelative);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSpeedBased", _m_SetSpeedBased);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetOptions", _m_SetOptions);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "startValue", _g_get_startValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "endValue", _g_get_endValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "changeValue", _g_get_changeValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "plugOptions", _g_get_plugOptions);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "getter", _g_get_getter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "setter", _g_get_setter);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "startValue", _s_set_startValue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "endValue", _s_set_endValue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "changeValue", _s_set_changeValue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "plugOptions", _s_set_plugOptions);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "getter", _s_set_getter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "setter", _s_set_setter);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeStartValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    object _newStartValue = translator.GetObject(L, 2, typeof(object));
                    float _newDuration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.ChangeStartValue( _newStartValue, _newDuration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object _newStartValue = translator.GetObject(L, 2, typeof(object));
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.ChangeStartValue( _newStartValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _newStartValue;translator.Get(L, 2, out _newStartValue);
                    float _newDuration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.ChangeStartValue( _newStartValue, _newDuration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _newStartValue;translator.Get(L, 2, out _newStartValue);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.ChangeStartValue( _newStartValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.ChangeStartValue!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeEndValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    object _newEndValue = translator.GetObject(L, 2, typeof(object));
                    bool _snapStartValue = LuaAPI.lua_toboolean(L, 3);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.ChangeEndValue( _newEndValue, _snapStartValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _newEndValue;translator.Get(L, 2, out _newEndValue);
                    bool _snapStartValue = LuaAPI.lua_toboolean(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.ChangeEndValue( _newEndValue, _snapStartValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    object _newEndValue = translator.GetObject(L, 2, typeof(object));
                    float _newDuration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapStartValue = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.ChangeEndValue( _newEndValue, _newDuration, _snapStartValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    object _newEndValue = translator.GetObject(L, 2, typeof(object));
                    float _newDuration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.ChangeEndValue( _newEndValue, _newDuration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object _newEndValue = translator.GetObject(L, 2, typeof(object));
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.ChangeEndValue( _newEndValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3 _newEndValue;translator.Get(L, 2, out _newEndValue);
                    float _newDuration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapStartValue = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.ChangeEndValue( _newEndValue, _newDuration, _snapStartValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _newEndValue;translator.Get(L, 2, out _newEndValue);
                    float _newDuration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.ChangeEndValue( _newEndValue, _newDuration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _newEndValue;translator.Get(L, 2, out _newEndValue);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.ChangeEndValue( _newEndValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.ChangeEndValue!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeValues(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    object _newStartValue = translator.GetObject(L, 2, typeof(object));
                    object _newEndValue = translator.GetObject(L, 3, typeof(object));
                    float _newDuration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.ChangeValues( _newStartValue, _newEndValue, _newDuration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    object _newStartValue = translator.GetObject(L, 2, typeof(object));
                    object _newEndValue = translator.GetObject(L, 3, typeof(object));
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.ChangeValues( _newStartValue, _newEndValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3 _newStartValue;translator.Get(L, 2, out _newStartValue);
                    UnityEngine.Vector3 _newEndValue;translator.Get(L, 3, out _newEndValue);
                    float _newDuration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.ChangeValues( _newStartValue, _newEndValue, _newDuration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _newStartValue;translator.Get(L, 2, out _newStartValue);
                    UnityEngine.Vector3 _newEndValue;translator.Get(L, 3, out _newEndValue);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.ChangeValues( _newStartValue, _newEndValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.ChangeValues!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Pause(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.Pause(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Play(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.Play(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAutoKill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetAutoKill(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _autoKillOnCompletion = LuaAPI.lua_toboolean(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetAutoKill( _autoKillOnCompletion );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetAutoKill!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _intId = LuaAPI.xlua_tointeger(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetId( _intId );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object _objectId = translator.GetObject(L, 2, typeof(object));
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetId( _objectId );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _stringId = LuaAPI.lua_tostring(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetId( _stringId );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetId!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLink(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 2)) 
                {
                    UnityEngine.GameObject _gameObject = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetLink( _gameObject );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& translator.Assignable<DG.Tweening.LinkBehaviour>(L, 3)) 
                {
                    UnityEngine.GameObject _gameObject = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    DG.Tweening.LinkBehaviour _behaviour;translator.Get(L, 3, out _behaviour);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetLink( _gameObject, _behaviour );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetLink!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTarget(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object _target = translator.GetObject(L, 2, typeof(object));
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetTarget( _target );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLoops(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _loops = LuaAPI.xlua_tointeger(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetLoops( _loops );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<DG.Tweening.LoopType>(L, 3)) 
                {
                    int _loops = LuaAPI.xlua_tointeger(L, 2);
                    DG.Tweening.LoopType _loopType;translator.Get(L, 3, out _loopType);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetLoops( _loops, _loopType );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetLoops!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEase(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<DG.Tweening.Ease>(L, 2)) 
                {
                    DG.Tweening.Ease _ease;translator.Get(L, 2, out _ease);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetEase( _ease );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.AnimationCurve>(L, 2)) 
                {
                    UnityEngine.AnimationCurve _animCurve = (UnityEngine.AnimationCurve)translator.GetObject(L, 2, typeof(UnityEngine.AnimationCurve));
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetEase( _animCurve );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<DG.Tweening.EaseFunction>(L, 2)) 
                {
                    DG.Tweening.EaseFunction _customEase = translator.GetDelegate<DG.Tweening.EaseFunction>(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetEase( _customEase );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<DG.Tweening.Ease>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    DG.Tweening.Ease _ease;translator.Get(L, 2, out _ease);
                    float _overshoot = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetEase( _ease, _overshoot );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<DG.Tweening.Ease>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Ease _ease;translator.Get(L, 2, out _ease);
                    float _amplitude = (float)LuaAPI.lua_tonumber(L, 3);
                    float _period = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetEase( _ease, _amplitude, _period );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetEase!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRecyclable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetRecyclable(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _recyclable = LuaAPI.lua_toboolean(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetRecyclable( _recyclable );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetRecyclable!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _isIndependentUpdate = LuaAPI.lua_toboolean(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetUpdate( _isIndependentUpdate );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<DG.Tweening.UpdateType>(L, 2)) 
                {
                    DG.Tweening.UpdateType _updateType;translator.Get(L, 2, out _updateType);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetUpdate( _updateType );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<DG.Tweening.UpdateType>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    DG.Tweening.UpdateType _updateType;translator.Get(L, 2, out _updateType);
                    bool _isIndependentUpdate = LuaAPI.lua_toboolean(L, 3);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetUpdate( _updateType, _isIndependentUpdate );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetUpdate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStart(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    DG.Tweening.TweenCallback _action = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.OnStart( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPlay(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    DG.Tweening.TweenCallback _action = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.OnPlay( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPause(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    DG.Tweening.TweenCallback _action = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.OnPause( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnRewind(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    DG.Tweening.TweenCallback _action = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.OnRewind( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    DG.Tweening.TweenCallback _action = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.OnUpdate( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStepComplete(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    DG.Tweening.TweenCallback _action = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.OnStepComplete( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnComplete(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    DG.Tweening.TweenCallback _action = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.OnComplete( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnKill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    DG.Tweening.TweenCallback _action = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.OnKill( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnWaypointChange(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    DG.Tweening.TweenCallback<int> _action = translator.GetDelegate<DG.Tweening.TweenCallback<int>>(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.OnWaypointChange( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAs(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<DG.Tweening.Tween>(L, 2)) 
                {
                    DG.Tweening.Tween _asTween = (DG.Tweening.Tween)translator.GetObject(L, 2, typeof(DG.Tweening.Tween));
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetAs( _asTween );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<DG.Tweening.TweenParams>(L, 2)) 
                {
                    DG.Tweening.TweenParams _tweenParams = (DG.Tweening.TweenParams)translator.GetObject(L, 2, typeof(DG.Tweening.TweenParams));
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetAs( _tweenParams );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetAs!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_From(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.From(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _isRelative = LuaAPI.lua_toboolean(L, 2);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.From( _isRelative );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _fromValue = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _setImmediately = LuaAPI.lua_toboolean(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.From( _fromValue, _setImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _fromValue = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.From( _fromValue );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.From!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDelay(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _delay = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetDelay( _delay );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRelative(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetRelative(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _isRelative = LuaAPI.lua_toboolean(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetRelative( _isRelative );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetRelative!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSpeedBased(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetSpeedBased(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _isSpeedBased = LuaAPI.lua_toboolean(L, 2);
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.SetSpeedBased( _isSpeedBased );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetSpeedBased!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetOptions(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _snapping = LuaAPI.lua_toboolean(L, 2);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.SetOptions( _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<DG.Tweening.AxisConstraint>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    DG.Tweening.AxisConstraint _axisConstraint;translator.Get(L, 2, out _axisConstraint);
                    bool _snapping = LuaAPI.lua_toboolean(L, 3);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.SetOptions( _axisConstraint, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<DG.Tweening.AxisConstraint>(L, 2)) 
                {
                    DG.Tweening.AxisConstraint _axisConstraint;translator.Get(L, 2, out _axisConstraint);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.SetOptions( _axisConstraint );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetOptions!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.startValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_endValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.endValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_changeValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.changeValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_plugOptions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.plugOptions);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_getter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.getter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_setter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.setter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.startValue = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_endValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.endValue = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_changeValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.changeValue = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_plugOptions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                DG.Tweening.Plugins.Options.VectorOptions gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.plugOptions = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_getter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_setter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_to_be_invoked = (DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
