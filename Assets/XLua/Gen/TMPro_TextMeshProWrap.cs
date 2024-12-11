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
    public class TMProTextMeshProWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(TMPro.TextMeshPro);
			Utils.BeginObjectRegister(type, L, translator, 0, 17, 8, 4);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMask", _m_SetMask);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetVerticesDirty", _m_SetVerticesDirty);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetLayoutDirty", _m_SetLayoutDirty);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMaterialDirty", _m_SetMaterialDirty);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAllDirty", _m_SetAllDirty);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Rebuild", _m_Rebuild);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateMeshPadding", _m_UpdateMeshPadding);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ForceMeshUpdate", _m_ForceMeshUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTextInfo", _m_GetTextInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearMesh", _m_ClearMesh);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateGeometry", _m_UpdateGeometry);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateVertexData", _m_UpdateVertexData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateFontAsset", _m_UpdateFontAsset);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateLayoutInputHorizontal", _m_CalculateLayoutInputHorizontal);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateLayoutInputVertical", _m_CalculateLayoutInputVertical);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ComputeMarginSize", _m_ComputeMarginSize);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPreRenderText", _e_OnPreRenderText);
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "sortingLayerID", _g_get_sortingLayerID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sortingOrder", _g_get_sortingOrder);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "autoSizeTextContainer", _g_get_autoSizeTextContainer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "transform", _g_get_transform);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "renderer", _g_get_renderer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mesh", _g_get_mesh);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "meshFilter", _g_get_meshFilter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maskType", _g_get_maskType);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "sortingLayerID", _s_set_sortingLayerID);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "sortingOrder", _s_set_sortingOrder);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "autoSizeTextContainer", _s_set_autoSizeTextContainer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maskType", _s_set_maskType);
            
			
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
					
					var gen_ret = new TMPro.TextMeshPro();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to TMPro.TextMeshPro constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMask(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<TMPro.MaskingTypes>(L, 2)&& translator.Assignable<UnityEngine.Vector4>(L, 3)) 
                {
                    TMPro.MaskingTypes _type;translator.Get(L, 2, out _type);
                    UnityEngine.Vector4 _maskCoords;translator.Get(L, 3, out _maskCoords);
                    
                    gen_to_be_invoked.SetMask( _type, _maskCoords );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<TMPro.MaskingTypes>(L, 2)&& translator.Assignable<UnityEngine.Vector4>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    TMPro.MaskingTypes _type;translator.Get(L, 2, out _type);
                    UnityEngine.Vector4 _maskCoords;translator.Get(L, 3, out _maskCoords);
                    float _softnessX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _softnessY = (float)LuaAPI.lua_tonumber(L, 5);
                    
                    gen_to_be_invoked.SetMask( _type, _maskCoords, _softnessX, _softnessY );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to TMPro.TextMeshPro.SetMask!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetVerticesDirty(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SetVerticesDirty(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayoutDirty(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SetLayoutDirty(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMaterialDirty(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SetMaterialDirty(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAllDirty(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SetAllDirty(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Rebuild(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.UI.CanvasUpdate _update;translator.Get(L, 2, out _update);
                    
                    gen_to_be_invoked.Rebuild( _update );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateMeshPadding(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateMeshPadding(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceMeshUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    bool _ignoreActiveState = LuaAPI.lua_toboolean(L, 2);
                    bool _forceTextReparsing = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.ForceMeshUpdate( _ignoreActiveState, _forceTextReparsing );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _ignoreActiveState = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.ForceMeshUpdate( _ignoreActiveState );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.ForceMeshUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to TMPro.TextMeshPro.ForceMeshUpdate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTextInfo( _text );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearMesh(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _updateMesh = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.ClearMesh( _updateMesh );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateGeometry(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Mesh _mesh = (UnityEngine.Mesh)translator.GetObject(L, 2, typeof(UnityEngine.Mesh));
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.UpdateGeometry( _mesh, _index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateVertexData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.UpdateVertexData(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<TMPro.TMP_VertexDataUpdateFlags>(L, 2)) 
                {
                    TMPro.TMP_VertexDataUpdateFlags _flags;translator.Get(L, 2, out _flags);
                    
                    gen_to_be_invoked.UpdateVertexData( _flags );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to TMPro.TextMeshPro.UpdateVertexData!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateFontAsset(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateFontAsset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateLayoutInputHorizontal(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.CalculateLayoutInputVertical(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ComputeMarginSize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ComputeMarginSize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sortingLayerID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.sortingLayerID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sortingOrder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.sortingOrder);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_autoSizeTextContainer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.autoSizeTextContainer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_transform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.transform);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_renderer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.renderer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mesh(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mesh);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_meshFilter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.meshFilter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maskType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.maskType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sortingLayerID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.sortingLayerID = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sortingOrder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.sortingOrder = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_autoSizeTextContainer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.autoSizeTextContainer = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maskType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                TMPro.MaskingTypes gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.maskType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnPreRenderText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			TMPro.TextMeshPro gen_to_be_invoked = (TMPro.TextMeshPro)translator.FastGetCSObj(L, 1);
                System.Action<TMPro.TMP_TextInfo> gen_delegate = translator.GetDelegate<System.Action<TMPro.TMP_TextInfo>>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action<TMPro.TMP_TextInfo>!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnPreRenderText += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnPreRenderText -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to TMPro.TextMeshPro.OnPreRenderText!");
            return 0;
        }
        
		
		
    }
}
