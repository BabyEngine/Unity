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
    public class DGTweeningDOTweenVisualManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DG.Tweening.DOTweenVisualManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 3, 3);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "preset", _g_get_preset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onEnableBehaviour", _g_get_onEnableBehaviour);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onDisableBehaviour", _g_get_onDisableBehaviour);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "preset", _s_set_preset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onEnableBehaviour", _s_set_onEnableBehaviour);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onDisableBehaviour", _s_set_onDisableBehaviour);
            
			
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
					
					var gen_ret = new DG.Tweening.DOTweenVisualManager();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTweenVisualManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenVisualManager gen_to_be_invoked = (DG.Tweening.DOTweenVisualManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.preset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onEnableBehaviour(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenVisualManager gen_to_be_invoked = (DG.Tweening.DOTweenVisualManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onEnableBehaviour);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onDisableBehaviour(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenVisualManager gen_to_be_invoked = (DG.Tweening.DOTweenVisualManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onDisableBehaviour);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_preset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenVisualManager gen_to_be_invoked = (DG.Tweening.DOTweenVisualManager)translator.FastGetCSObj(L, 1);
                DG.Tweening.Core.VisualManagerPreset gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.preset = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onEnableBehaviour(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenVisualManager gen_to_be_invoked = (DG.Tweening.DOTweenVisualManager)translator.FastGetCSObj(L, 1);
                DG.Tweening.Core.OnEnableBehaviour gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.onEnableBehaviour = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onDisableBehaviour(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenVisualManager gen_to_be_invoked = (DG.Tweening.DOTweenVisualManager)translator.FastGetCSObj(L, 1);
                DG.Tweening.Core.OnDisableBehaviour gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.onDisableBehaviour = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
