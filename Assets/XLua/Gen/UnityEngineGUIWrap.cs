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
    public class UnityEngineGUIWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.GUI);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 36, 9, 9);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SetNextControlName", _m_SetNextControlName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetNameOfFocusedControl", _m_GetNameOfFocusedControl_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FocusControl", _m_FocusControl_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DragWindow", _m_DragWindow_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BringWindowToFront", _m_BringWindowToFront_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BringWindowToBack", _m_BringWindowToBack_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FocusWindow", _m_FocusWindow_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UnfocusWindow", _m_UnfocusWindow_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Label", _m_Label_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DrawTexture", _m_DrawTexture_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DrawTextureWithTexCoords", _m_DrawTextureWithTexCoords_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Box", _m_Box_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Button", _m_Button_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RepeatButton", _m_RepeatButton_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TextField", _m_TextField_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PasswordField", _m_PasswordField_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TextArea", _m_TextArea_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Toggle", _m_Toggle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Toolbar", _m_Toolbar_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SelectionGrid", _m_SelectionGrid_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HorizontalSlider", _m_HorizontalSlider_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "VerticalSlider", _m_VerticalSlider_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Slider", _m_Slider_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HorizontalScrollbar", _m_HorizontalScrollbar_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "VerticalScrollbar", _m_VerticalScrollbar_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BeginClip", _m_BeginClip_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BeginGroup", _m_BeginGroup_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EndGroup", _m_EndGroup_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EndClip", _m_EndClip_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BeginScrollView", _m_BeginScrollView_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EndScrollView", _m_EndScrollView_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ScrollTo", _m_ScrollTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ScrollTowards", _m_ScrollTowards_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Window", _m_Window_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ModalWindow", _m_ModalWindow_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "color", _g_get_color);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "backgroundColor", _g_get_backgroundColor);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "contentColor", _g_get_contentColor);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "changed", _g_get_changed);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "enabled", _g_get_enabled);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "depth", _g_get_depth);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "skin", _g_get_skin);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "matrix", _g_get_matrix);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "tooltip", _g_get_tooltip);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "color", _s_set_color);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "backgroundColor", _s_set_backgroundColor);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "contentColor", _s_set_contentColor);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "changed", _s_set_changed);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "enabled", _s_set_enabled);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "depth", _s_set_depth);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "skin", _s_set_skin);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "matrix", _s_set_matrix);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "tooltip", _s_set_tooltip);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.GUI gen_ret = new UnityEngine.GUI();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNextControlName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                    UnityEngine.GUI.SetNextControlName( _name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNameOfFocusedControl_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        string gen_ret = UnityEngine.GUI.GetNameOfFocusedControl(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FocusControl_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                    UnityEngine.GUI.FocusControl( _name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DragWindow_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 0) 
                {
                    
                    UnityEngine.GUI.DragWindow(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.Rect>(L, 1)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    
                    UnityEngine.GUI.DragWindow( _position );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.DragWindow!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BringWindowToFront_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _windowID = LuaAPI.xlua_tointeger(L, 1);
                    
                    UnityEngine.GUI.BringWindowToFront( _windowID );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BringWindowToBack_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _windowID = LuaAPI.xlua_tointeger(L, 1);
                    
                    UnityEngine.GUI.BringWindowToBack( _windowID );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FocusWindow_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _windowID = LuaAPI.xlua_tointeger(L, 1);
                    
                    UnityEngine.GUI.FocusWindow( _windowID );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnfocusWindow_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    UnityEngine.GUI.UnfocusWindow(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Label_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                    UnityEngine.GUI.Label( _position, _text );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    
                    UnityEngine.GUI.Label( _position, _image );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIContent>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 2, typeof(UnityEngine.GUIContent));
                    
                    UnityEngine.GUI.Label( _position, _content );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                    UnityEngine.GUI.Label( _position, _text, _style );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                    UnityEngine.GUI.Label( _position, _image, _style );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIContent>(L, 2)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 2, typeof(UnityEngine.GUIContent));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                    UnityEngine.GUI.Label( _position, _content, _style );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.Label!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawTexture_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    
                    UnityEngine.GUI.DrawTexture( _position, _image );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.ScaleMode>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.ScaleMode _scaleMode;translator.Get(L, 3, out _scaleMode);
                    
                    UnityEngine.GUI.DrawTexture( _position, _image, _scaleMode );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.ScaleMode>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.ScaleMode _scaleMode;translator.Get(L, 3, out _scaleMode);
                    bool _alphaBlend = LuaAPI.lua_toboolean(L, 4);
                    
                    UnityEngine.GUI.DrawTexture( _position, _image, _scaleMode, _alphaBlend );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.ScaleMode>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.ScaleMode _scaleMode;translator.Get(L, 3, out _scaleMode);
                    bool _alphaBlend = LuaAPI.lua_toboolean(L, 4);
                    float _imageAspect = (float)LuaAPI.lua_tonumber(L, 5);
                    
                    UnityEngine.GUI.DrawTexture( _position, _image, _scaleMode, _alphaBlend, _imageAspect );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 8&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.ScaleMode>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.Color>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.ScaleMode _scaleMode;translator.Get(L, 3, out _scaleMode);
                    bool _alphaBlend = LuaAPI.lua_toboolean(L, 4);
                    float _imageAspect = (float)LuaAPI.lua_tonumber(L, 5);
                    UnityEngine.Color _color;translator.Get(L, 6, out _color);
                    float _borderWidth = (float)LuaAPI.lua_tonumber(L, 7);
                    float _borderRadius = (float)LuaAPI.lua_tonumber(L, 8);
                    
                    UnityEngine.GUI.DrawTexture( _position, _image, _scaleMode, _alphaBlend, _imageAspect, _color, _borderWidth, _borderRadius );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 8&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.ScaleMode>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.Color>(L, 6)&& translator.Assignable<UnityEngine.Vector4>(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.ScaleMode _scaleMode;translator.Get(L, 3, out _scaleMode);
                    bool _alphaBlend = LuaAPI.lua_toboolean(L, 4);
                    float _imageAspect = (float)LuaAPI.lua_tonumber(L, 5);
                    UnityEngine.Color _color;translator.Get(L, 6, out _color);
                    UnityEngine.Vector4 _borderWidths;translator.Get(L, 7, out _borderWidths);
                    float _borderRadius = (float)LuaAPI.lua_tonumber(L, 8);
                    
                    UnityEngine.GUI.DrawTexture( _position, _image, _scaleMode, _alphaBlend, _imageAspect, _color, _borderWidths, _borderRadius );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 8&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.ScaleMode>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.Color>(L, 6)&& translator.Assignable<UnityEngine.Vector4>(L, 7)&& translator.Assignable<UnityEngine.Vector4>(L, 8)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.ScaleMode _scaleMode;translator.Get(L, 3, out _scaleMode);
                    bool _alphaBlend = LuaAPI.lua_toboolean(L, 4);
                    float _imageAspect = (float)LuaAPI.lua_tonumber(L, 5);
                    UnityEngine.Color _color;translator.Get(L, 6, out _color);
                    UnityEngine.Vector4 _borderWidths;translator.Get(L, 7, out _borderWidths);
                    UnityEngine.Vector4 _borderRadiuses;translator.Get(L, 8, out _borderRadiuses);
                    
                    UnityEngine.GUI.DrawTexture( _position, _image, _scaleMode, _alphaBlend, _imageAspect, _color, _borderWidths, _borderRadiuses );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.DrawTexture!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawTextureWithTexCoords_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.Rect>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.Rect _texCoords;translator.Get(L, 3, out _texCoords);
                    
                    UnityEngine.GUI.DrawTextureWithTexCoords( _position, _image, _texCoords );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.Rect>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.Rect _texCoords;translator.Get(L, 3, out _texCoords);
                    bool _alphaBlend = LuaAPI.lua_toboolean(L, 4);
                    
                    UnityEngine.GUI.DrawTextureWithTexCoords( _position, _image, _texCoords, _alphaBlend );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.DrawTextureWithTexCoords!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Box_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                    UnityEngine.GUI.Box( _position, _text );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    
                    UnityEngine.GUI.Box( _position, _image );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIContent>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 2, typeof(UnityEngine.GUIContent));
                    
                    UnityEngine.GUI.Box( _position, _content );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                    UnityEngine.GUI.Box( _position, _text, _style );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                    UnityEngine.GUI.Box( _position, _image, _style );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIContent>(L, 2)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 2, typeof(UnityEngine.GUIContent));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                    UnityEngine.GUI.Box( _position, _content, _style );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.Box!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Button_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                        bool gen_ret = UnityEngine.GUI.Button( _position, _text );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    
                        bool gen_ret = UnityEngine.GUI.Button( _position, _image );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIContent>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 2, typeof(UnityEngine.GUIContent));
                    
                        bool gen_ret = UnityEngine.GUI.Button( _position, _content );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                        bool gen_ret = UnityEngine.GUI.Button( _position, _text, _style );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                        bool gen_ret = UnityEngine.GUI.Button( _position, _image, _style );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIContent>(L, 2)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 2, typeof(UnityEngine.GUIContent));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                        bool gen_ret = UnityEngine.GUI.Button( _position, _content, _style );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.Button!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RepeatButton_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                        bool gen_ret = UnityEngine.GUI.RepeatButton( _position, _text );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    
                        bool gen_ret = UnityEngine.GUI.RepeatButton( _position, _image );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIContent>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 2, typeof(UnityEngine.GUIContent));
                    
                        bool gen_ret = UnityEngine.GUI.RepeatButton( _position, _content );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                        bool gen_ret = UnityEngine.GUI.RepeatButton( _position, _text, _style );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                        bool gen_ret = UnityEngine.GUI.RepeatButton( _position, _image, _style );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIContent>(L, 2)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 2, typeof(UnityEngine.GUIContent));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                        bool gen_ret = UnityEngine.GUI.RepeatButton( _position, _content, _style );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.RepeatButton!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TextField_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                        string gen_ret = UnityEngine.GUI.TextField( _position, _text );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    int _maxLength = LuaAPI.xlua_tointeger(L, 3);
                    
                        string gen_ret = UnityEngine.GUI.TextField( _position, _text, _maxLength );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                        string gen_ret = UnityEngine.GUI.TextField( _position, _text, _style );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    int _maxLength = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    
                        string gen_ret = UnityEngine.GUI.TextField( _position, _text, _maxLength, _style );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.TextField!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PasswordField_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _password = LuaAPI.lua_tostring(L, 2);
                    char _maskChar = (char)LuaAPI.xlua_tointeger(L, 3);
                    
                        string gen_ret = UnityEngine.GUI.PasswordField( _position, _password, _maskChar );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _password = LuaAPI.lua_tostring(L, 2);
                    char _maskChar = (char)LuaAPI.xlua_tointeger(L, 3);
                    int _maxLength = LuaAPI.xlua_tointeger(L, 4);
                    
                        string gen_ret = UnityEngine.GUI.PasswordField( _position, _password, _maskChar, _maxLength );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _password = LuaAPI.lua_tostring(L, 2);
                    char _maskChar = (char)LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    
                        string gen_ret = UnityEngine.GUI.PasswordField( _position, _password, _maskChar, _style );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _password = LuaAPI.lua_tostring(L, 2);
                    char _maskChar = (char)LuaAPI.xlua_tointeger(L, 3);
                    int _maxLength = LuaAPI.xlua_tointeger(L, 4);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        string gen_ret = UnityEngine.GUI.PasswordField( _position, _password, _maskChar, _maxLength, _style );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.PasswordField!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TextArea_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                        string gen_ret = UnityEngine.GUI.TextArea( _position, _text );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    int _maxLength = LuaAPI.xlua_tointeger(L, 3);
                    
                        string gen_ret = UnityEngine.GUI.TextArea( _position, _text, _maxLength );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                        string gen_ret = UnityEngine.GUI.TextArea( _position, _text, _style );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    int _maxLength = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    
                        string gen_ret = UnityEngine.GUI.TextArea( _position, _text, _maxLength, _style );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.TextArea!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Toggle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    bool _value = LuaAPI.lua_toboolean(L, 2);
                    string _text = LuaAPI.lua_tostring(L, 3);
                    
                        bool gen_ret = UnityEngine.GUI.Toggle( _position, _value, _text );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Texture>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    bool _value = LuaAPI.lua_toboolean(L, 2);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 3, typeof(UnityEngine.Texture));
                    
                        bool gen_ret = UnityEngine.GUI.Toggle( _position, _value, _image );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.GUIContent>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    bool _value = LuaAPI.lua_toboolean(L, 2);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 3, typeof(UnityEngine.GUIContent));
                    
                        bool gen_ret = UnityEngine.GUI.Toggle( _position, _value, _content );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    bool _value = LuaAPI.lua_toboolean(L, 2);
                    string _text = LuaAPI.lua_tostring(L, 3);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    
                        bool gen_ret = UnityEngine.GUI.Toggle( _position, _value, _text, _style );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Texture>(L, 3)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    bool _value = LuaAPI.lua_toboolean(L, 2);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 3, typeof(UnityEngine.Texture));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    
                        bool gen_ret = UnityEngine.GUI.Toggle( _position, _value, _image, _style );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.GUIContent>(L, 3)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    bool _value = LuaAPI.lua_toboolean(L, 2);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 3, typeof(UnityEngine.GUIContent));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    
                        bool gen_ret = UnityEngine.GUI.Toggle( _position, _value, _content, _style );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.GUIContent>(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _id = LuaAPI.xlua_tointeger(L, 2);
                    bool _value = LuaAPI.lua_toboolean(L, 3);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 4, typeof(UnityEngine.GUIContent));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        bool gen_ret = UnityEngine.GUI.Toggle( _position, _id, _value, _content, _style );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.Toggle!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Toolbar_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<string[]>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    string[] _texts = (string[])translator.GetObject(L, 3, typeof(string[]));
                    
                        int gen_ret = UnityEngine.GUI.Toolbar( _position, _selected, _texts );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Texture[]>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Texture[] _images = (UnityEngine.Texture[])translator.GetObject(L, 3, typeof(UnityEngine.Texture[]));
                    
                        int gen_ret = UnityEngine.GUI.Toolbar( _position, _selected, _images );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.GUIContent[]>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.GUIContent[] _contents = (UnityEngine.GUIContent[])translator.GetObject(L, 3, typeof(UnityEngine.GUIContent[]));
                    
                        int gen_ret = UnityEngine.GUI.Toolbar( _position, _selected, _contents );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<string[]>(L, 3)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    string[] _texts = (string[])translator.GetObject(L, 3, typeof(string[]));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    
                        int gen_ret = UnityEngine.GUI.Toolbar( _position, _selected, _texts, _style );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Texture[]>(L, 3)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Texture[] _images = (UnityEngine.Texture[])translator.GetObject(L, 3, typeof(UnityEngine.Texture[]));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    
                        int gen_ret = UnityEngine.GUI.Toolbar( _position, _selected, _images, _style );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.GUIContent[]>(L, 3)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.GUIContent[] _contents = (UnityEngine.GUIContent[])translator.GetObject(L, 3, typeof(UnityEngine.GUIContent[]));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    
                        int gen_ret = UnityEngine.GUI.Toolbar( _position, _selected, _contents, _style );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.GUIContent[]>(L, 3)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)&& translator.Assignable<UnityEngine.GUI.ToolbarButtonSize>(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.GUIContent[] _contents = (UnityEngine.GUIContent[])translator.GetObject(L, 3, typeof(UnityEngine.GUIContent[]));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUI.ToolbarButtonSize _buttonSize;translator.Get(L, 5, out _buttonSize);
                    
                        int gen_ret = UnityEngine.GUI.Toolbar( _position, _selected, _contents, _style, _buttonSize );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.Toolbar!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SelectionGrid_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<string[]>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    string[] _texts = (string[])translator.GetObject(L, 3, typeof(string[]));
                    int _xCount = LuaAPI.xlua_tointeger(L, 4);
                    
                        int gen_ret = UnityEngine.GUI.SelectionGrid( _position, _selected, _texts, _xCount );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Texture[]>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Texture[] _images = (UnityEngine.Texture[])translator.GetObject(L, 3, typeof(UnityEngine.Texture[]));
                    int _xCount = LuaAPI.xlua_tointeger(L, 4);
                    
                        int gen_ret = UnityEngine.GUI.SelectionGrid( _position, _selected, _images, _xCount );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.GUIContent[]>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.GUIContent[] _content = (UnityEngine.GUIContent[])translator.GetObject(L, 3, typeof(UnityEngine.GUIContent[]));
                    int _xCount = LuaAPI.xlua_tointeger(L, 4);
                    
                        int gen_ret = UnityEngine.GUI.SelectionGrid( _position, _selected, _content, _xCount );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<string[]>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    string[] _texts = (string[])translator.GetObject(L, 3, typeof(string[]));
                    int _xCount = LuaAPI.xlua_tointeger(L, 4);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        int gen_ret = UnityEngine.GUI.SelectionGrid( _position, _selected, _texts, _xCount, _style );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Texture[]>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Texture[] _images = (UnityEngine.Texture[])translator.GetObject(L, 3, typeof(UnityEngine.Texture[]));
                    int _xCount = LuaAPI.xlua_tointeger(L, 4);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        int gen_ret = UnityEngine.GUI.SelectionGrid( _position, _selected, _images, _xCount, _style );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.GUIContent[]>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    int _selected = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.GUIContent[] _contents = (UnityEngine.GUIContent[])translator.GetObject(L, 3, typeof(UnityEngine.GUIContent[]));
                    int _xCount = LuaAPI.xlua_tointeger(L, 4);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        int gen_ret = UnityEngine.GUI.SelectionGrid( _position, _selected, _contents, _xCount, _style );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.SelectionGrid!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HorizontalSlider_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _leftValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float _rightValue = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        float gen_ret = UnityEngine.GUI.HorizontalSlider( _position, _value, _leftValue, _rightValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)&& translator.Assignable<UnityEngine.GUIStyle>(L, 6)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _leftValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float _rightValue = (float)LuaAPI.lua_tonumber(L, 4);
                    UnityEngine.GUIStyle _slider = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUIStyle _thumb = (UnityEngine.GUIStyle)translator.GetObject(L, 6, typeof(UnityEngine.GUIStyle));
                    
                        float gen_ret = UnityEngine.GUI.HorizontalSlider( _position, _value, _leftValue, _rightValue, _slider, _thumb );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 7&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)&& translator.Assignable<UnityEngine.GUIStyle>(L, 6)&& translator.Assignable<UnityEngine.GUIStyle>(L, 7)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _leftValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float _rightValue = (float)LuaAPI.lua_tonumber(L, 4);
                    UnityEngine.GUIStyle _slider = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUIStyle _thumb = (UnityEngine.GUIStyle)translator.GetObject(L, 6, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUIStyle _thumbExtent = (UnityEngine.GUIStyle)translator.GetObject(L, 7, typeof(UnityEngine.GUIStyle));
                    
                        float gen_ret = UnityEngine.GUI.HorizontalSlider( _position, _value, _leftValue, _rightValue, _slider, _thumb, _thumbExtent );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.HorizontalSlider!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_VerticalSlider_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _topValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float _bottomValue = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        float gen_ret = UnityEngine.GUI.VerticalSlider( _position, _value, _topValue, _bottomValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)&& translator.Assignable<UnityEngine.GUIStyle>(L, 6)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _topValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float _bottomValue = (float)LuaAPI.lua_tonumber(L, 4);
                    UnityEngine.GUIStyle _slider = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUIStyle _thumb = (UnityEngine.GUIStyle)translator.GetObject(L, 6, typeof(UnityEngine.GUIStyle));
                    
                        float gen_ret = UnityEngine.GUI.VerticalSlider( _position, _value, _topValue, _bottomValue, _slider, _thumb );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 7&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)&& translator.Assignable<UnityEngine.GUIStyle>(L, 6)&& translator.Assignable<UnityEngine.GUIStyle>(L, 7)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _topValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float _bottomValue = (float)LuaAPI.lua_tonumber(L, 4);
                    UnityEngine.GUIStyle _slider = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUIStyle _thumb = (UnityEngine.GUIStyle)translator.GetObject(L, 6, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUIStyle _thumbExtent = (UnityEngine.GUIStyle)translator.GetObject(L, 7, typeof(UnityEngine.GUIStyle));
                    
                        float gen_ret = UnityEngine.GUI.VerticalSlider( _position, _value, _topValue, _bottomValue, _slider, _thumb, _thumbExtent );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.VerticalSlider!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Slider_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 10&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.GUIStyle>(L, 6)&& translator.Assignable<UnityEngine.GUIStyle>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)&& translator.Assignable<UnityEngine.GUIStyle>(L, 10)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _size = (float)LuaAPI.lua_tonumber(L, 3);
                    float _start = (float)LuaAPI.lua_tonumber(L, 4);
                    float _end = (float)LuaAPI.lua_tonumber(L, 5);
                    UnityEngine.GUIStyle _slider = (UnityEngine.GUIStyle)translator.GetObject(L, 6, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUIStyle _thumb = (UnityEngine.GUIStyle)translator.GetObject(L, 7, typeof(UnityEngine.GUIStyle));
                    bool _horiz = LuaAPI.lua_toboolean(L, 8);
                    int _id = LuaAPI.xlua_tointeger(L, 9);
                    UnityEngine.GUIStyle _thumbExtent = (UnityEngine.GUIStyle)translator.GetObject(L, 10, typeof(UnityEngine.GUIStyle));
                    
                        float gen_ret = UnityEngine.GUI.Slider( _position, _value, _size, _start, _end, _slider, _thumb, _horiz, _id, _thumbExtent );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 9&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.GUIStyle>(L, 6)&& translator.Assignable<UnityEngine.GUIStyle>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _size = (float)LuaAPI.lua_tonumber(L, 3);
                    float _start = (float)LuaAPI.lua_tonumber(L, 4);
                    float _end = (float)LuaAPI.lua_tonumber(L, 5);
                    UnityEngine.GUIStyle _slider = (UnityEngine.GUIStyle)translator.GetObject(L, 6, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUIStyle _thumb = (UnityEngine.GUIStyle)translator.GetObject(L, 7, typeof(UnityEngine.GUIStyle));
                    bool _horiz = LuaAPI.lua_toboolean(L, 8);
                    int _id = LuaAPI.xlua_tointeger(L, 9);
                    
                        float gen_ret = UnityEngine.GUI.Slider( _position, _value, _size, _start, _end, _slider, _thumb, _horiz, _id );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.Slider!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HorizontalScrollbar_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _size = (float)LuaAPI.lua_tonumber(L, 3);
                    float _leftValue = (float)LuaAPI.lua_tonumber(L, 4);
                    float _rightValue = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        float gen_ret = UnityEngine.GUI.HorizontalScrollbar( _position, _value, _size, _leftValue, _rightValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.GUIStyle>(L, 6)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _size = (float)LuaAPI.lua_tonumber(L, 3);
                    float _leftValue = (float)LuaAPI.lua_tonumber(L, 4);
                    float _rightValue = (float)LuaAPI.lua_tonumber(L, 5);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 6, typeof(UnityEngine.GUIStyle));
                    
                        float gen_ret = UnityEngine.GUI.HorizontalScrollbar( _position, _value, _size, _leftValue, _rightValue, _style );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.HorizontalScrollbar!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_VerticalScrollbar_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _size = (float)LuaAPI.lua_tonumber(L, 3);
                    float _topValue = (float)LuaAPI.lua_tonumber(L, 4);
                    float _bottomValue = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        float gen_ret = UnityEngine.GUI.VerticalScrollbar( _position, _value, _size, _topValue, _bottomValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Rect>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.GUIStyle>(L, 6)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    float _size = (float)LuaAPI.lua_tonumber(L, 3);
                    float _topValue = (float)LuaAPI.lua_tonumber(L, 4);
                    float _bottomValue = (float)LuaAPI.lua_tonumber(L, 5);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 6, typeof(UnityEngine.GUIStyle));
                    
                        float gen_ret = UnityEngine.GUI.VerticalScrollbar( _position, _value, _size, _topValue, _bottomValue, _style );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.VerticalScrollbar!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BeginClip_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.Rect>(L, 1)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    
                    UnityEngine.GUI.BeginClip( _position );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _scrollOffset;translator.Get(L, 2, out _scrollOffset);
                    UnityEngine.Vector2 _renderOffset;translator.Get(L, 3, out _renderOffset);
                    bool _resetOffset = LuaAPI.lua_toboolean(L, 4);
                    
                    UnityEngine.GUI.BeginClip( _position, _scrollOffset, _renderOffset, _resetOffset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.BeginClip!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BeginGroup_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.Rect>(L, 1)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    
                    UnityEngine.GUI.BeginGroup( _position );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                    UnityEngine.GUI.BeginGroup( _position, _text );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    
                    UnityEngine.GUI.BeginGroup( _position, _image );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIContent>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 2, typeof(UnityEngine.GUIContent));
                    
                    UnityEngine.GUI.BeginGroup( _position, _content );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIStyle>(L, 2)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 2, typeof(UnityEngine.GUIStyle));
                    
                    UnityEngine.GUI.BeginGroup( _position, _style );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    string _text = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                    UnityEngine.GUI.BeginGroup( _position, _text, _style );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Texture>(L, 2)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                    UnityEngine.GUI.BeginGroup( _position, _image, _style );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.GUIContent>(L, 2)&& translator.Assignable<UnityEngine.GUIStyle>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 2, typeof(UnityEngine.GUIContent));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 3, typeof(UnityEngine.GUIStyle));
                    
                    UnityEngine.GUI.BeginGroup( _position, _content, _style );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.BeginGroup!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EndGroup_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    UnityEngine.GUI.EndGroup(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EndClip_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    UnityEngine.GUI.EndClip(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BeginScrollView_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<UnityEngine.Rect>(L, 3)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _scrollPosition;translator.Get(L, 2, out _scrollPosition);
                    UnityEngine.Rect _viewRect;translator.Get(L, 3, out _viewRect);
                    
                        UnityEngine.Vector2 gen_ret = UnityEngine.GUI.BeginScrollView( _position, _scrollPosition, _viewRect );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<UnityEngine.Rect>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _scrollPosition;translator.Get(L, 2, out _scrollPosition);
                    UnityEngine.Rect _viewRect;translator.Get(L, 3, out _viewRect);
                    bool _alwaysShowHorizontal = LuaAPI.lua_toboolean(L, 4);
                    bool _alwaysShowVertical = LuaAPI.lua_toboolean(L, 5);
                    
                        UnityEngine.Vector2 gen_ret = UnityEngine.GUI.BeginScrollView( _position, _scrollPosition, _viewRect, _alwaysShowHorizontal, _alwaysShowVertical );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<UnityEngine.Rect>(L, 3)&& translator.Assignable<UnityEngine.GUIStyle>(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _scrollPosition;translator.Get(L, 2, out _scrollPosition);
                    UnityEngine.Rect _viewRect;translator.Get(L, 3, out _viewRect);
                    UnityEngine.GUIStyle _horizontalScrollbar = (UnityEngine.GUIStyle)translator.GetObject(L, 4, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUIStyle _verticalScrollbar = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        UnityEngine.Vector2 gen_ret = UnityEngine.GUI.BeginScrollView( _position, _scrollPosition, _viewRect, _horizontalScrollbar, _verticalScrollbar );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 7&& translator.Assignable<UnityEngine.Rect>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<UnityEngine.Rect>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.GUIStyle>(L, 6)&& translator.Assignable<UnityEngine.GUIStyle>(L, 7)) 
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _scrollPosition;translator.Get(L, 2, out _scrollPosition);
                    UnityEngine.Rect _viewRect;translator.Get(L, 3, out _viewRect);
                    bool _alwaysShowHorizontal = LuaAPI.lua_toboolean(L, 4);
                    bool _alwaysShowVertical = LuaAPI.lua_toboolean(L, 5);
                    UnityEngine.GUIStyle _horizontalScrollbar = (UnityEngine.GUIStyle)translator.GetObject(L, 6, typeof(UnityEngine.GUIStyle));
                    UnityEngine.GUIStyle _verticalScrollbar = (UnityEngine.GUIStyle)translator.GetObject(L, 7, typeof(UnityEngine.GUIStyle));
                    
                        UnityEngine.Vector2 gen_ret = UnityEngine.GUI.BeginScrollView( _position, _scrollPosition, _viewRect, _alwaysShowHorizontal, _alwaysShowVertical, _horizontalScrollbar, _verticalScrollbar );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.BeginScrollView!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EndScrollView_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 0) 
                {
                    
                    UnityEngine.GUI.EndScrollView(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _handleScrollWheel = LuaAPI.lua_toboolean(L, 1);
                    
                    UnityEngine.GUI.EndScrollView( _handleScrollWheel );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.EndScrollView!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScrollTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    
                    UnityEngine.GUI.ScrollTo( _position );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScrollTowards_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Rect _position;translator.Get(L, 1, out _position);
                    float _maxDelta = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        bool gen_ret = UnityEngine.GUI.ScrollTowards( _position, _maxDelta );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Window_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    string _text = LuaAPI.lua_tostring(L, 4);
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.Window( _id, _clientRect, _func, _text );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& translator.Assignable<UnityEngine.Texture>(L, 4)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 4, typeof(UnityEngine.Texture));
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.Window( _id, _clientRect, _func, _image );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& translator.Assignable<UnityEngine.GUIContent>(L, 4)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 4, typeof(UnityEngine.GUIContent));
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.Window( _id, _clientRect, _func, _content );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    string _text = LuaAPI.lua_tostring(L, 4);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.Window( _id, _clientRect, _func, _text, _style );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& translator.Assignable<UnityEngine.Texture>(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 4, typeof(UnityEngine.Texture));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.Window( _id, _clientRect, _func, _image, _style );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& translator.Assignable<UnityEngine.GUIContent>(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    UnityEngine.GUIContent _title = (UnityEngine.GUIContent)translator.GetObject(L, 4, typeof(UnityEngine.GUIContent));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.Window( _id, _clientRect, _func, _title, _style );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.Window!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ModalWindow_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    string _text = LuaAPI.lua_tostring(L, 4);
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.ModalWindow( _id, _clientRect, _func, _text );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& translator.Assignable<UnityEngine.Texture>(L, 4)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 4, typeof(UnityEngine.Texture));
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.ModalWindow( _id, _clientRect, _func, _image );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& translator.Assignable<UnityEngine.GUIContent>(L, 4)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 4, typeof(UnityEngine.GUIContent));
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.ModalWindow( _id, _clientRect, _func, _content );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    string _text = LuaAPI.lua_tostring(L, 4);
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.ModalWindow( _id, _clientRect, _func, _text, _style );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& translator.Assignable<UnityEngine.Texture>(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    UnityEngine.Texture _image = (UnityEngine.Texture)translator.GetObject(L, 4, typeof(UnityEngine.Texture));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.ModalWindow( _id, _clientRect, _func, _image, _style );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<UnityEngine.Rect>(L, 2)&& translator.Assignable<UnityEngine.GUI.WindowFunction>(L, 3)&& translator.Assignable<UnityEngine.GUIContent>(L, 4)&& translator.Assignable<UnityEngine.GUIStyle>(L, 5)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Rect _clientRect;translator.Get(L, 2, out _clientRect);
                    UnityEngine.GUI.WindowFunction _func = translator.GetDelegate<UnityEngine.GUI.WindowFunction>(L, 3);
                    UnityEngine.GUIContent _content = (UnityEngine.GUIContent)translator.GetObject(L, 4, typeof(UnityEngine.GUIContent));
                    UnityEngine.GUIStyle _style = (UnityEngine.GUIStyle)translator.GetObject(L, 5, typeof(UnityEngine.GUIStyle));
                    
                        UnityEngine.Rect gen_ret = UnityEngine.GUI.ModalWindow( _id, _clientRect, _func, _content, _style );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GUI.ModalWindow!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, UnityEngine.GUI.color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_backgroundColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, UnityEngine.GUI.backgroundColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_contentColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, UnityEngine.GUI.contentColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_changed(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.GUI.changed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enabled(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.GUI.enabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_depth(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.GUI.depth);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_skin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.GUI.skin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_matrix(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.GUI.matrix);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tooltip(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, UnityEngine.GUI.tooltip);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.GUI.color = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_backgroundColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.GUI.backgroundColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_contentColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.GUI.contentColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_changed(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.GUI.changed = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enabled(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.GUI.enabled = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_depth(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.GUI.depth = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_skin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    UnityEngine.GUI.skin = (UnityEngine.GUISkin)translator.GetObject(L, 1, typeof(UnityEngine.GUISkin));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_matrix(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Matrix4x4 gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.GUI.matrix = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tooltip(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.GUI.tooltip = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
