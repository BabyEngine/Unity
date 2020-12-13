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
    public class UnityEngineGUIUtilityWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.GUIUtility);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 12, 4, 3);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetControlID", _m_GetControlID_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AlignRectToDevice", _m_AlignRectToDevice_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetStateObject", _m_GetStateObject_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "QueryStateObject", _m_QueryStateObject_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ExitGUI", _m_ExitGUI_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GUIToScreenPoint", _m_GUIToScreenPoint_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GUIToScreenRect", _m_GUIToScreenRect_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ScreenToGUIPoint", _m_ScreenToGUIPoint_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ScreenToGUIRect", _m_ScreenToGUIRect_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RotateAroundPivot", _m_RotateAroundPivot_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ScaleAroundPivot", _m_ScaleAroundPivot_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "hasModalWindow", _g_get_hasModalWindow);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "systemCopyBuffer", _g_get_systemCopyBuffer);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "hotControl", _g_get_hotControl);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "keyboardControl", _g_get_keyboardControl);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "systemCopyBuffer", _s_set_systemCopyBuffer);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "hotControl", _s_set_hotControl);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "keyboardControl", _s_set_keyboardControl);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.GUIUtility gen_ret = new UnityEngine.GUIUtility();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUIUtility constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetControlID_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.FocusType>(L, 1)) 
                {
                    UnityEngine.FocusType _focus;translator.Get(L, 1, out _focus);
                    
                        int gen_ret = UnityEngine.GUIUtility.GetControlID( _focus );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.FocusType>(L, 2)) 
                {
                    int _hint = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.FocusType _focus;translator.Get(L, 2, out _focus);
                    
                        int gen_ret = UnityEngine.GUIUtility.GetControlID( _hint, _focus );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.GUIContent>(L, 1)&& translator.Assignable<UnityEngine.FocusType>(L, 2)) 
                {
                    UnityEngine.GUIContent _contents = (UnityEngine.GUIContent)translator.GetObject(L, 1, typeof(UnityEngine.GUIContent));
                    UnityEngine.FocusType _focus;translator.Get(L, 2, out _focus);
                    
                        int gen_ret = UnityEngine.GUIUtility.GetControlID( _contents, _focus );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.FocusType>(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)) 
                {
                    UnityEngine.FocusType _focus;translator.Get(L, 1, out _focus);
                    UnityEngine.Rect _position;translator.Get(L, 2, out _position);
                    
                        int gen_ret = UnityEngine.GUIUtility.GetControlID( _focus, _position );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.FocusType>(L, 2)&& translator.Assignable<UnityEngine.Rect>(L, 3)) 
                {
                    int _hint = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.FocusType _focusType;translator.Get(L, 2, out _focusType);
                    UnityEngine.Rect _rect;translator.Get(L, 3, out _rect);
                    
                        int gen_ret = UnityEngine.GUIUtility.GetControlID( _hint, _focusType, _rect );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.GUIContent>(L, 1)&& translator.Assignable<UnityEngine.FocusType>(L, 2)&& translator.Assignable<UnityEngine.Rect>(L, 3)) 
                {
                    UnityEngine.GUIContent _contents = (UnityEngine.GUIContent)translator.GetObject(L, 1, typeof(UnityEngine.GUIContent));
                    UnityEngine.FocusType _focus;translator.Get(L, 2, out _focus);
                    UnityEngine.Rect _position;translator.Get(L, 3, out _position);
                    
                        int gen_ret = UnityEngine.GUIUtility.GetControlID( _contents, _focus, _position );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUIUtility.GetControlID!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AlignRectToDevice_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.Rect>(L, 1)) 
                {
                    UnityEngine.Rect _rect;translator.Get(L, 1, out _rect);
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUIUtility.AlignRectToDevice( _rect );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.Rect>(L, 1)) 
                {
                    UnityEngine.Rect _rect;translator.Get(L, 1, out _rect);
                    int _widthInPixels;
                    int _heightInPixels;
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUIUtility.AlignRectToDevice( _rect, out _widthInPixels, out _heightInPixels );
                        translator.Push(L, gen_ret);
                    LuaAPI.xlua_pushinteger(L, _widthInPixels);
                        
                    LuaAPI.xlua_pushinteger(L, _heightInPixels);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUIUtility.AlignRectToDevice!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStateObject_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Type _t = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    int _controlID = LuaAPI.xlua_tointeger(L, 2);
                    
                        object gen_ret = UnityEngine.GUIUtility.GetStateObject( _t, _controlID );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QueryStateObject_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Type _t = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    int _controlID = LuaAPI.xlua_tointeger(L, 2);
                    
                        object gen_ret = UnityEngine.GUIUtility.QueryStateObject( _t, _controlID );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitGUI_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    UnityEngine.GUIUtility.ExitGUI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GUIToScreenPoint_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector2 _guiPoint;translator.Get(L, 1, out _guiPoint);
                    
                        UnityEngine.Vector2 gen_ret = UnityEngine.GUIUtility.GUIToScreenPoint( _guiPoint );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GUIToScreenRect_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Rect _guiRect;translator.Get(L, 1, out _guiRect);
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUIUtility.GUIToScreenRect( _guiRect );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScreenToGUIPoint_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector2 _screenPoint;translator.Get(L, 1, out _screenPoint);
                    
                        UnityEngine.Vector2 gen_ret = UnityEngine.GUIUtility.ScreenToGUIPoint( _screenPoint );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScreenToGUIRect_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Rect _screenRect;translator.Get(L, 1, out _screenRect);
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUIUtility.ScreenToGUIRect( _screenRect );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RotateAroundPivot_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    float _angle = (float)LuaAPI.lua_tonumber(L, 1);
                    UnityEngine.Vector2 _pivotPoint;translator.Get(L, 2, out _pivotPoint);
                    
                    UnityEngine.GUIUtility.RotateAroundPivot( _angle, _pivotPoint );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScaleAroundPivot_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector2 _scale;translator.Get(L, 1, out _scale);
                    UnityEngine.Vector2 _pivotPoint;translator.Get(L, 2, out _pivotPoint);
                    
                    UnityEngine.GUIUtility.ScaleAroundPivot( _scale, _pivotPoint );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hasModalWindow(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.GUIUtility.hasModalWindow);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_systemCopyBuffer(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, UnityEngine.GUIUtility.systemCopyBuffer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hotControl(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.GUIUtility.hotControl);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_keyboardControl(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.GUIUtility.keyboardControl);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_systemCopyBuffer(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.GUIUtility.systemCopyBuffer = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hotControl(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.GUIUtility.hotControl = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_keyboardControl(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.GUIUtility.keyboardControl = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
