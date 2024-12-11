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
    public class DGTweeningDOVirtualWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DG.Tweening.DOVirtual);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Float", _m_Float_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EasedValue", _m_EasedValue_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DelayedCall", _m_DelayedCall_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "DG.Tweening.DOVirtual does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Float_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    float _from = (float)LuaAPI.lua_tonumber(L, 1);
                    float _to = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    DG.Tweening.TweenCallback<float> _onVirtualUpdate = translator.GetDelegate<DG.Tweening.TweenCallback<float>>(L, 4);
                    
                        var gen_ret = DG.Tweening.DOVirtual.Float( _from, _to, _duration, _onVirtualUpdate );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EasedValue_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<DG.Tweening.Ease>(L, 4)) 
                {
                    float _from = (float)LuaAPI.lua_tonumber(L, 1);
                    float _to = (float)LuaAPI.lua_tonumber(L, 2);
                    float _lifetimePercentage = (float)LuaAPI.lua_tonumber(L, 3);
                    DG.Tweening.Ease _easeType;translator.Get(L, 4, out _easeType);
                    
                        var gen_ret = DG.Tweening.DOVirtual.EasedValue( _from, _to, _lifetimePercentage, _easeType );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.AnimationCurve>(L, 4)) 
                {
                    float _from = (float)LuaAPI.lua_tonumber(L, 1);
                    float _to = (float)LuaAPI.lua_tonumber(L, 2);
                    float _lifetimePercentage = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.AnimationCurve _easeCurve = (UnityEngine.AnimationCurve)translator.GetObject(L, 4, typeof(UnityEngine.AnimationCurve));
                    
                        var gen_ret = DG.Tweening.DOVirtual.EasedValue( _from, _to, _lifetimePercentage, _easeCurve );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<DG.Tweening.Ease>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    float _from = (float)LuaAPI.lua_tonumber(L, 1);
                    float _to = (float)LuaAPI.lua_tonumber(L, 2);
                    float _lifetimePercentage = (float)LuaAPI.lua_tonumber(L, 3);
                    DG.Tweening.Ease _easeType;translator.Get(L, 4, out _easeType);
                    float _overshoot = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        var gen_ret = DG.Tweening.DOVirtual.EasedValue( _from, _to, _lifetimePercentage, _easeType, _overshoot );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<DG.Tweening.Ease>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    float _from = (float)LuaAPI.lua_tonumber(L, 1);
                    float _to = (float)LuaAPI.lua_tonumber(L, 2);
                    float _lifetimePercentage = (float)LuaAPI.lua_tonumber(L, 3);
                    DG.Tweening.Ease _easeType;translator.Get(L, 4, out _easeType);
                    float _amplitude = (float)LuaAPI.lua_tonumber(L, 5);
                    float _period = (float)LuaAPI.lua_tonumber(L, 6);
                    
                        var gen_ret = DG.Tweening.DOVirtual.EasedValue( _from, _to, _lifetimePercentage, _easeType, _amplitude, _period );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOVirtual.EasedValue!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelayedCall_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<DG.Tweening.TweenCallback>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _delay = (float)LuaAPI.lua_tonumber(L, 1);
                    DG.Tweening.TweenCallback _callback = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = DG.Tweening.DOVirtual.DelayedCall( _delay, _callback, _ignoreTimeScale );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<DG.Tweening.TweenCallback>(L, 2)) 
                {
                    float _delay = (float)LuaAPI.lua_tonumber(L, 1);
                    DG.Tweening.TweenCallback _callback = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    
                        var gen_ret = DG.Tweening.DOVirtual.DelayedCall( _delay, _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOVirtual.DelayedCall!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
