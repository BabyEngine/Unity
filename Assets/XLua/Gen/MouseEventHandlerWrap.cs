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
    public class MouseEventHandlerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(MouseEventHandler);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 3, 3);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMouseDown", _g_get_onMouseDown);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMouseUp", _g_get_onMouseUp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMouseUpAsButton", _g_get_onMouseUpAsButton);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMouseDown", _s_set_onMouseDown);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMouseUp", _s_set_onMouseUp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMouseUpAsButton", _s_set_onMouseUpAsButton);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetMouseEventHandler", _m_GetMouseEventHandler_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetMouseUpAsButtonEvent", _m_SetMouseUpAsButtonEvent_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					MouseEventHandler gen_ret = new MouseEventHandler();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MouseEventHandler constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMouseEventHandler_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject _go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                        MouseEventHandler gen_ret = MouseEventHandler.GetMouseEventHandler( _go );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMouseUpAsButtonEvent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject _go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    XLua.LuaFunction _luaFunction = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
                    
                    MouseEventHandler.SetMouseUpAsButtonEvent( _go, _luaFunction );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMouseDown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MouseEventHandler gen_to_be_invoked = (MouseEventHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMouseDown);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMouseUp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MouseEventHandler gen_to_be_invoked = (MouseEventHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMouseUp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMouseUpAsButton(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MouseEventHandler gen_to_be_invoked = (MouseEventHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMouseUpAsButton);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMouseDown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MouseEventHandler gen_to_be_invoked = (MouseEventHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMouseDown = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMouseUp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MouseEventHandler gen_to_be_invoked = (MouseEventHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMouseUp = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMouseUpAsButton(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MouseEventHandler gen_to_be_invoked = (MouseEventHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMouseUpAsButton = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
