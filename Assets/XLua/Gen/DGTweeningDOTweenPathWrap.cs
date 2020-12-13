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
    public class DGTweeningDOTweenPathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DG.Tweening.DOTweenPath);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 39, 39);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPlay", _m_DOPlay);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPlayById", _m_DOPlayById);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPlayAllById", _m_DOPlayAllById);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPlayBackwards", _m_DOPlayBackwards);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPlayForward", _m_DOPlayForward);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPause", _m_DOPause);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOTogglePause", _m_DOTogglePause);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DORewind", _m_DORewind);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DORestart", _m_DORestart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOComplete", _m_DOComplete);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOKill", _m_DOKill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTween", _m_GetTween);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDrawPoints", _m_GetDrawPoints);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "delay", _g_get_delay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "duration", _g_get_duration);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "easeType", _g_get_easeType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "easeCurve", _g_get_easeCurve);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "loops", _g_get_loops);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "id", _g_get_id);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "loopType", _g_get_loopType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "orientType", _g_get_orientType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lookAtTransform", _g_get_lookAtTransform);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lookAtPosition", _g_get_lookAtPosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lookAhead", _g_get_lookAhead);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "autoPlay", _g_get_autoPlay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "autoKill", _g_get_autoKill);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "relative", _g_get_relative);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isLocal", _g_get_isLocal);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isClosedPath", _g_get_isClosedPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathResolution", _g_get_pathResolution);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathMode", _g_get_pathMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lockRotation", _g_get_lockRotation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "assignForwardAndUp", _g_get_assignForwardAndUp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "forwardDirection", _g_get_forwardDirection);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "upDirection", _g_get_upDirection);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tweenRigidbody", _g_get_tweenRigidbody);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "wps", _g_get_wps);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fullWps", _g_get_fullWps);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "path", _g_get_path);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "inspectorMode", _g_get_inspectorMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathType", _g_get_pathType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "handlesType", _g_get_handlesType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "livePreview", _g_get_livePreview);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "handlesDrawMode", _g_get_handlesDrawMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "perspectiveHandleSize", _g_get_perspectiveHandleSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showIndexes", _g_get_showIndexes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showWpLength", _g_get_showWpLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathColor", _g_get_pathColor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lastSrcPosition", _g_get_lastSrcPosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lastSrcRotation", _g_get_lastSrcRotation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "wpsDropdown", _g_get_wpsDropdown);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dropToFloorOffset", _g_get_dropToFloorOffset);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "delay", _s_set_delay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "duration", _s_set_duration);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "easeType", _s_set_easeType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "easeCurve", _s_set_easeCurve);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "loops", _s_set_loops);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "id", _s_set_id);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "loopType", _s_set_loopType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "orientType", _s_set_orientType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lookAtTransform", _s_set_lookAtTransform);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lookAtPosition", _s_set_lookAtPosition);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lookAhead", _s_set_lookAhead);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "autoPlay", _s_set_autoPlay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "autoKill", _s_set_autoKill);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "relative", _s_set_relative);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "isLocal", _s_set_isLocal);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "isClosedPath", _s_set_isClosedPath);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pathResolution", _s_set_pathResolution);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pathMode", _s_set_pathMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lockRotation", _s_set_lockRotation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "assignForwardAndUp", _s_set_assignForwardAndUp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "forwardDirection", _s_set_forwardDirection);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "upDirection", _s_set_upDirection);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tweenRigidbody", _s_set_tweenRigidbody);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "wps", _s_set_wps);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fullWps", _s_set_fullWps);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "path", _s_set_path);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "inspectorMode", _s_set_inspectorMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pathType", _s_set_pathType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "handlesType", _s_set_handlesType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "livePreview", _s_set_livePreview);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "handlesDrawMode", _s_set_handlesDrawMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "perspectiveHandleSize", _s_set_perspectiveHandleSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showIndexes", _s_set_showIndexes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showWpLength", _s_set_showWpLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pathColor", _s_set_pathColor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lastSrcPosition", _s_set_lastSrcPosition);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lastSrcRotation", _s_set_lastSrcRotation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "wpsDropdown", _s_set_wpsDropdown);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dropToFloorOffset", _s_set_dropToFloorOffset);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			
			Utils.RegisterFunc(L, Utils.CLS_IDX, "OnReset", _e_OnReset);
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DG.Tweening.DOTweenPath gen_ret = new DG.Tweening.DOTweenPath();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTweenPath constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPlay(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DOPlay(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPlayById(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _id = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.DOPlayById( _id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPlayAllById(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _id = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.DOPlayAllById( _id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPlayBackwards(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DOPlayBackwards(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPlayForward(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DOPlayForward(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPause(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DOPause(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOTogglePause(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DOTogglePause(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DORewind(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DORewind(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DORestart(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.DORestart(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _fromHere = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.DORestart( _fromHere );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTweenPath.DORestart!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOComplete(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DOComplete(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOKill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DOKill(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTween(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        DG.Tweening.Tween gen_ret = gen_to_be_invoked.GetTween(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDrawPoints(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3[] gen_ret = gen_to_be_invoked.GetDrawPoints(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_delay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.delay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_duration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.duration);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_easeType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushDGTweeningEase(L, gen_to_be_invoked.easeType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_easeCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.easeCurve);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_loops(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.loops);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.id);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_loopType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushDGTweeningLoopType(L, gen_to_be_invoked.loopType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_orientType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.orientType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lookAtTransform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.lookAtTransform);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lookAtPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.lookAtPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lookAhead(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.lookAhead);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_autoPlay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.autoPlay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_autoKill(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.autoKill);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_relative(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.relative);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isLocal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isLocal);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isClosedPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isClosedPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathResolution(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.pathResolution);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushDGTweeningPathMode(L, gen_to_be_invoked.pathMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lockRotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushDGTweeningAxisConstraint(L, gen_to_be_invoked.lockRotation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_assignForwardAndUp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.assignForwardAndUp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_forwardDirection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.forwardDirection);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_upDirection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.upDirection);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tweenRigidbody(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.tweenRigidbody);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wps(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.wps);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fullWps(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.fullWps);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_path(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.path);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_inspectorMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.inspectorMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushDGTweeningPathType(L, gen_to_be_invoked.pathType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_handlesType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.handlesType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_livePreview(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.livePreview);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_handlesDrawMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.handlesDrawMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_perspectiveHandleSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.perspectiveHandleSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showIndexes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showIndexes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showWpLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showWpLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.pathColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lastSrcPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.lastSrcPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lastSrcRotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineQuaternion(L, gen_to_be_invoked.lastSrcRotation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wpsDropdown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.wpsDropdown);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dropToFloorOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.dropToFloorOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_delay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.delay = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_duration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.duration = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_easeType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                DG.Tweening.Ease gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.easeType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_easeCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.easeCurve = (UnityEngine.AnimationCurve)translator.GetObject(L, 2, typeof(UnityEngine.AnimationCurve));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_loops(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.loops = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.id = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_loopType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                DG.Tweening.LoopType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.loopType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_orientType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                DG.Tweening.Plugins.Options.OrientType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.orientType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lookAtTransform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.lookAtTransform = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lookAtPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.lookAtPosition = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lookAhead(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.lookAhead = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_autoPlay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.autoPlay = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_autoKill(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.autoKill = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_relative(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.relative = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isLocal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.isLocal = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isClosedPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.isClosedPath = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pathResolution(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pathResolution = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pathMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                DG.Tweening.PathMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.pathMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lockRotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                DG.Tweening.AxisConstraint gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.lockRotation = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_assignForwardAndUp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.assignForwardAndUp = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_forwardDirection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.forwardDirection = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_upDirection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.upDirection = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tweenRigidbody(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tweenRigidbody = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wps(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.wps = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fullWps(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.fullWps = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_path(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.path = (DG.Tweening.Plugins.Core.PathCore.Path)translator.GetObject(L, 2, typeof(DG.Tweening.Plugins.Core.PathCore.Path));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_inspectorMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                DG.Tweening.DOTweenInspectorMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.inspectorMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pathType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                DG.Tweening.PathType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.pathType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_handlesType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                DG.Tweening.HandlesType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.handlesType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_livePreview(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.livePreview = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_handlesDrawMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                DG.Tweening.HandlesDrawMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.handlesDrawMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_perspectiveHandleSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.perspectiveHandleSize = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showIndexes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showIndexes = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showWpLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showWpLength = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pathColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.pathColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lastSrcPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.lastSrcPosition = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lastSrcRotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Quaternion gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.lastSrcRotation = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wpsDropdown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.wpsDropdown = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dropToFloorOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DG.Tweening.DOTweenPath gen_to_be_invoked = (DG.Tweening.DOTweenPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dropToFloorOffset = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnReset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
                System.Action<DG.Tweening.DOTweenPath> gen_delegate = translator.GetDelegate<System.Action<DG.Tweening.DOTweenPath>>(L, 2);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#2 need System.Action<DG.Tweening.DOTweenPath>!");
                }
                
				
				if (gen_param_count == 2 && LuaAPI.xlua_is_eq_str(L, 1, "+")) {
					DG.Tweening.DOTweenPath.OnReset += gen_delegate;
					return 0;
				} 
				
				
				if (gen_param_count == 2 && LuaAPI.xlua_is_eq_str(L, 1, "-")) {
					DG.Tweening.DOTweenPath.OnReset -= gen_delegate;
					return 0;
				} 
				
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTweenPath.OnReset!");
        }
        
    }
}
