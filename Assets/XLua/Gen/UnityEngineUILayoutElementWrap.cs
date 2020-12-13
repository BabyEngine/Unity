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
    public class UnityEngineUILayoutElementWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.UI.LayoutElement);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 8, 8);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateLayoutInputHorizontal", _m_CalculateLayoutInputHorizontal);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateLayoutInputVertical", _m_CalculateLayoutInputVertical);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOFlexibleSize", _m_DOFlexibleSize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOMinSize", _m_DOMinSize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPreferredSize", _m_DOPreferredSize);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "ignoreLayout", _g_get_ignoreLayout);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "minWidth", _g_get_minWidth);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "minHeight", _g_get_minHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "preferredWidth", _g_get_preferredWidth);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "preferredHeight", _g_get_preferredHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "flexibleWidth", _g_get_flexibleWidth);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "flexibleHeight", _g_get_flexibleHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "layoutPriority", _g_get_layoutPriority);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "ignoreLayout", _s_set_ignoreLayout);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "minWidth", _s_set_minWidth);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "minHeight", _s_set_minHeight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "preferredWidth", _s_set_preferredWidth);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "preferredHeight", _s_set_preferredHeight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "flexibleWidth", _s_set_flexibleWidth);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "flexibleHeight", _s_set_flexibleHeight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "layoutPriority", _s_set_layoutPriority);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.LayoutElement does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateLayoutInputHorizontal(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.CalculateLayoutInputHorizontal(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateLayoutInputVertical(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.CalculateLayoutInputVertical(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOFlexibleSize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOFlexibleSize( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOFlexibleSize( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.UI.LayoutElement.DOFlexibleSize!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOMinSize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOMinSize( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOMinSize( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.UI.LayoutElement.DOMinSize!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPreferredSize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOPreferredSize( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOPreferredSize( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.UI.LayoutElement.DOPreferredSize!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ignoreLayout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.ignoreLayout);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_minWidth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.minWidth);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_minHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.minHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preferredWidth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.preferredWidth);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preferredHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.preferredHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flexibleWidth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.flexibleWidth);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flexibleHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.flexibleHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_layoutPriority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.layoutPriority);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ignoreLayout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ignoreLayout = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_minWidth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.minWidth = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_minHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.minHeight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_preferredWidth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.preferredWidth = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_preferredHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.preferredHeight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_flexibleWidth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.flexibleWidth = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_flexibleHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.flexibleHeight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_layoutPriority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.LayoutElement gen_to_be_invoked = (UnityEngine.UI.LayoutElement)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.layoutPriority = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
