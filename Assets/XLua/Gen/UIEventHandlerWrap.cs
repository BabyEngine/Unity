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
    public class UIEventHandlerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UIEventHandler);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 6, 6);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrag", _m_OnDrag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPointerClick", _m_OnPointerClick);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPointerDown", _m_OnPointerDown);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPointerEnter", _m_OnPointerEnter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPointerExit", _m_OnPointerExit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPointerUp", _m_OnPointerUp);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "onDrag", _g_get_onDrag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onPointerClick", _g_get_onPointerClick);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onPointerDown", _g_get_onPointerDown);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onPointerUp", _g_get_onPointerUp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onPointerEnter", _g_get_onPointerEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onPointerExit", _g_get_onPointerExit);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "onDrag", _s_set_onDrag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onPointerClick", _s_set_onPointerClick);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onPointerDown", _s_set_onPointerDown);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onPointerUp", _s_set_onPointerUp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onPointerEnter", _s_set_onPointerEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onPointerExit", _s_set_onPointerExit);
            
			
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
					
					UIEventHandler gen_ret = new UIEventHandler();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UIEventHandler constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.EventSystems.PointerEventData _eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    gen_to_be_invoked.OnDrag( _eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerClick(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.EventSystems.PointerEventData _eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    gen_to_be_invoked.OnPointerClick( _eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerDown(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.EventSystems.PointerEventData _eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    gen_to_be_invoked.OnPointerDown( _eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerEnter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.EventSystems.PointerEventData _eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    gen_to_be_invoked.OnPointerEnter( _eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerExit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.EventSystems.PointerEventData _eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    gen_to_be_invoked.OnPointerExit( _eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerUp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.EventSystems.PointerEventData _eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    gen_to_be_invoked.OnPointerUp( _eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onDrag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onDrag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onPointerClick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onPointerClick);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onPointerDown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onPointerDown);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onPointerUp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onPointerUp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onPointerEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onPointerEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onPointerExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onPointerExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onDrag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onDrag = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onPointerClick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onPointerClick = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onPointerDown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onPointerDown = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onPointerUp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onPointerUp = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onPointerEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onPointerEnter = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onPointerExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIEventHandler gen_to_be_invoked = (UIEventHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onPointerExit = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
