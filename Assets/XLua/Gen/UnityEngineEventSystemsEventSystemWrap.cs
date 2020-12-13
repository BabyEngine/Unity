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
    public class UnityEngineEventSystemsEventSystemWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.EventSystems.EventSystem);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 7, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateModules", _m_UpdateModules);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSelectedGameObject", _m_SetSelectedGameObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RaycastAll", _m_RaycastAll);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsPointerOverGameObject", _m_IsPointerOverGameObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToString", _m_ToString);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "sendNavigationEvents", _g_get_sendNavigationEvents);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pixelDragThreshold", _g_get_pixelDragThreshold);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "currentInputModule", _g_get_currentInputModule);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "firstSelectedGameObject", _g_get_firstSelectedGameObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "currentSelectedGameObject", _g_get_currentSelectedGameObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isFocused", _g_get_isFocused);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "alreadySelecting", _g_get_alreadySelecting);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "sendNavigationEvents", _s_set_sendNavigationEvents);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pixelDragThreshold", _s_set_pixelDragThreshold);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "firstSelectedGameObject", _s_set_firstSelectedGameObject);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 1);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "current", _g_get_current);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "current", _s_set_current);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.EventSystems.EventSystem does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateModules(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateModules(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSelectedGameObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 2)) 
                {
                    UnityEngine.GameObject _selected = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    
                    gen_to_be_invoked.SetSelectedGameObject( _selected );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& translator.Assignable<UnityEngine.EventSystems.BaseEventData>(L, 3)) 
                {
                    UnityEngine.GameObject _selected = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    UnityEngine.EventSystems.BaseEventData _pointer = (UnityEngine.EventSystems.BaseEventData)translator.GetObject(L, 3, typeof(UnityEngine.EventSystems.BaseEventData));
                    
                    gen_to_be_invoked.SetSelectedGameObject( _selected, _pointer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.EventSystems.EventSystem.SetSelectedGameObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RaycastAll(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.EventSystems.PointerEventData _eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> _raycastResults = (System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>));
                    
                    gen_to_be_invoked.RaycastAll( _eventData, _raycastResults );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPointerOverGameObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        bool gen_ret = gen_to_be_invoked.IsPointerOverGameObject(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _pointerId = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.IsPointerOverGameObject( _pointerId );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.EventSystems.EventSystem.IsPointerOverGameObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_current(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.EventSystems.EventSystem.current);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sendNavigationEvents(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.sendNavigationEvents);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pixelDragThreshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.pixelDragThreshold);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_currentInputModule(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.currentInputModule);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_firstSelectedGameObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.firstSelectedGameObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_currentSelectedGameObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.currentSelectedGameObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isFocused(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isFocused);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_alreadySelecting(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.alreadySelecting);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_current(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    UnityEngine.EventSystems.EventSystem.current = (UnityEngine.EventSystems.EventSystem)translator.GetObject(L, 1, typeof(UnityEngine.EventSystems.EventSystem));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sendNavigationEvents(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.sendNavigationEvents = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pixelDragThreshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pixelDragThreshold = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_firstSelectedGameObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.EventSystems.EventSystem gen_to_be_invoked = (UnityEngine.EventSystems.EventSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.firstSelectedGameObject = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
