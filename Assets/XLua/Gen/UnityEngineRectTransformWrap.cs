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
    public class UnityEngineRectTransformWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.RectTransform);
			Utils.BeginObjectRegister(type, L, translator, 0, 21, 9, 8);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ForceUpdateRectTransforms", _m_ForceUpdateRectTransforms);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLocalCorners", _m_GetLocalCorners);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetWorldCorners", _m_GetWorldCorners);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetInsetAndSizeFromParentEdge", _m_SetInsetAndSizeFromParentEdge);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSizeWithCurrentAnchors", _m_SetSizeWithCurrentAnchors);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOAnchorPos", _m_DOAnchorPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOAnchorPosX", _m_DOAnchorPosX);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOAnchorPosY", _m_DOAnchorPosY);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOAnchorPos3D", _m_DOAnchorPos3D);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOAnchorPos3DX", _m_DOAnchorPos3DX);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOAnchorPos3DY", _m_DOAnchorPos3DY);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOAnchorPos3DZ", _m_DOAnchorPos3DZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOAnchorMax", _m_DOAnchorMax);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOAnchorMin", _m_DOAnchorMin);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPivot", _m_DOPivot);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPivotX", _m_DOPivotX);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPivotY", _m_DOPivotY);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOSizeDelta", _m_DOSizeDelta);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOPunchAnchorPos", _m_DOPunchAnchorPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOShakeAnchorPos", _m_DOShakeAnchorPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DOJumpAnchorPos", _m_DOJumpAnchorPos);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "rect", _g_get_rect);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "anchorMin", _g_get_anchorMin);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "anchorMax", _g_get_anchorMax);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "anchoredPosition", _g_get_anchoredPosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sizeDelta", _g_get_sizeDelta);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pivot", _g_get_pivot);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "anchoredPosition3D", _g_get_anchoredPosition3D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "offsetMin", _g_get_offsetMin);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "offsetMax", _g_get_offsetMax);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "anchorMin", _s_set_anchorMin);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "anchorMax", _s_set_anchorMax);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "anchoredPosition", _s_set_anchoredPosition);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "sizeDelta", _s_set_sizeDelta);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pivot", _s_set_pivot);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "anchoredPosition3D", _s_set_anchoredPosition3D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "offsetMin", _s_set_offsetMin);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "offsetMax", _s_set_offsetMax);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			
			Utils.RegisterFunc(L, Utils.CLS_IDX, "reapplyDrivenProperties", _e_reapplyDrivenProperties);
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.RectTransform gen_ret = new UnityEngine.RectTransform();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceUpdateRectTransforms(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ForceUpdateRectTransforms(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLocalCorners(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3[] _fourCornersArray = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    
                    gen_to_be_invoked.GetLocalCorners( _fourCornersArray );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWorldCorners(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3[] _fourCornersArray = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    
                    gen_to_be_invoked.GetWorldCorners( _fourCornersArray );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetInsetAndSizeFromParentEdge(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.RectTransform.Edge _edge;translator.Get(L, 2, out _edge);
                    float _inset = (float)LuaAPI.lua_tonumber(L, 3);
                    float _size = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.SetInsetAndSizeFromParentEdge( _edge, _inset, _size );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSizeWithCurrentAnchors(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.RectTransform.Axis _axis;translator.Get(L, 2, out _axis);
                    float _size = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.SetSizeWithCurrentAnchors( _axis, _size );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPos( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPos( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOAnchorPos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPosX(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPosX( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPosX( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOAnchorPosX!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPosY(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPosY( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPosY( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOAnchorPosY!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPos3D(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPos3D( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPos3D( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOAnchorPos3D!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPos3DX(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPos3DX( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPos3DX( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOAnchorPos3DX!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPos3DY(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPos3DY( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPos3DY( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOAnchorPos3DY!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPos3DZ(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPos3DZ( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorPos3DZ( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOAnchorPos3DZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorMax(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorMax( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorMax( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOAnchorMax!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorMin(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorMin( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOAnchorMin( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOAnchorMin!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPivot(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOPivot( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPivotX(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOPivotX( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPivotY(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _endValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOPivotY( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOSizeDelta(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _snapping = LuaAPI.lua_toboolean(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOSizeDelta( _endValue, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> gen_ret = gen_to_be_invoked.DOSizeDelta( _endValue, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOSizeDelta!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPunchAnchorPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.Vector2 _punch;translator.Get(L, 2, out _punch);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    float _elasticity = (float)LuaAPI.lua_tonumber(L, 5);
                    bool _snapping = LuaAPI.lua_toboolean(L, 6);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOPunchAnchorPos( _punch, _duration, _vibrato, _elasticity, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Vector2 _punch;translator.Get(L, 2, out _punch);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    float _elasticity = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOPunchAnchorPos( _punch, _duration, _vibrato, _elasticity );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector2 _punch;translator.Get(L, 2, out _punch);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOPunchAnchorPos( _punch, _duration, _vibrato );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _punch;translator.Get(L, 2, out _punch);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOPunchAnchorPos( _punch, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOPunchAnchorPos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOShakeAnchorPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    float _strength = (float)LuaAPI.lua_tonumber(L, 3);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    float _randomness = (float)LuaAPI.lua_tonumber(L, 5);
                    bool _snapping = LuaAPI.lua_toboolean(L, 6);
                    bool _fadeOut = LuaAPI.lua_toboolean(L, 7);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration, _strength, _vibrato, _randomness, _snapping, _fadeOut );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    float _strength = (float)LuaAPI.lua_tonumber(L, 3);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    float _randomness = (float)LuaAPI.lua_tonumber(L, 5);
                    bool _snapping = LuaAPI.lua_toboolean(L, 6);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration, _strength, _vibrato, _randomness, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    float _strength = (float)LuaAPI.lua_tonumber(L, 3);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    float _randomness = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration, _strength, _vibrato, _randomness );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    float _strength = (float)LuaAPI.lua_tonumber(L, 3);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration, _strength, _vibrato );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    float _strength = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration, _strength );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector2 _strength;translator.Get(L, 3, out _strength);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    float _randomness = (float)LuaAPI.lua_tonumber(L, 5);
                    bool _snapping = LuaAPI.lua_toboolean(L, 6);
                    bool _fadeOut = LuaAPI.lua_toboolean(L, 7);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration, _strength, _vibrato, _randomness, _snapping, _fadeOut );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector2 _strength;translator.Get(L, 3, out _strength);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    float _randomness = (float)LuaAPI.lua_tonumber(L, 5);
                    bool _snapping = LuaAPI.lua_toboolean(L, 6);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration, _strength, _vibrato, _randomness, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector2 _strength;translator.Get(L, 3, out _strength);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    float _randomness = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration, _strength, _vibrato, _randomness );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector2 _strength;translator.Get(L, 3, out _strength);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 4);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration, _strength, _vibrato );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector2 _strength;translator.Get(L, 3, out _strength);
                    
                        DG.Tweening.Tweener gen_ret = gen_to_be_invoked.DOShakeAnchorPos( _duration, _strength );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOShakeAnchorPos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOJumpAnchorPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _jumpPower = (float)LuaAPI.lua_tonumber(L, 3);
                    int _numJumps = LuaAPI.xlua_tointeger(L, 4);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    bool _snapping = LuaAPI.lua_toboolean(L, 6);
                    
                        DG.Tweening.Sequence gen_ret = gen_to_be_invoked.DOJumpAnchorPos( _endValue, _jumpPower, _numJumps, _duration, _snapping );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Vector2 _endValue;translator.Get(L, 2, out _endValue);
                    float _jumpPower = (float)LuaAPI.lua_tonumber(L, 3);
                    int _numJumps = LuaAPI.xlua_tointeger(L, 4);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        DG.Tweening.Sequence gen_ret = gen_to_be_invoked.DOJumpAnchorPos( _endValue, _jumpPower, _numJumps, _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.DOJumpAnchorPos!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.rect);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anchorMin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.anchorMin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anchorMax(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.anchorMax);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anchoredPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.anchoredPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sizeDelta(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.sizeDelta);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pivot(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.pivot);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anchoredPosition3D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.anchoredPosition3D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_offsetMin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.offsetMin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_offsetMax(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.offsetMax);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anchorMin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.anchorMin = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anchorMax(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.anchorMax = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anchoredPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.anchoredPosition = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sizeDelta(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.sizeDelta = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pivot(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.pivot = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anchoredPosition3D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.anchoredPosition3D = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_offsetMin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.offsetMin = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_offsetMax(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RectTransform gen_to_be_invoked = (UnityEngine.RectTransform)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.offsetMax = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_reapplyDrivenProperties(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
                UnityEngine.RectTransform.ReapplyDrivenProperties gen_delegate = translator.GetDelegate<UnityEngine.RectTransform.ReapplyDrivenProperties>(L, 2);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#2 need UnityEngine.RectTransform.ReapplyDrivenProperties!");
                }
                
				
				if (gen_param_count == 2 && LuaAPI.xlua_is_eq_str(L, 1, "+")) {
					UnityEngine.RectTransform.reapplyDrivenProperties += gen_delegate;
					return 0;
				} 
				
				
				if (gen_param_count == 2 && LuaAPI.xlua_is_eq_str(L, 1, "-")) {
					UnityEngine.RectTransform.reapplyDrivenProperties -= gen_delegate;
					return 0;
				} 
				
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RectTransform.reapplyDrivenProperties!");
        }
        
    }
}
