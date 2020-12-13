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
    public class PhysicsColliderHandlerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PhysicsColliderHandler);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 12, 12);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerEnter", _g_get_onTriggerEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerExit", _g_get_onTriggerExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerStay", _g_get_onTriggerStay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerEnter2D", _g_get_onTriggerEnter2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerExit2D", _g_get_onTriggerExit2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerStay2D", _g_get_onTriggerStay2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionEnter", _g_get_onCollisionEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionExit", _g_get_onCollisionExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionStay", _g_get_onCollisionStay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionEnter2D", _g_get_onCollisionEnter2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionExit2D", _g_get_onCollisionExit2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionStay2D", _g_get_onCollisionStay2D);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerEnter", _s_set_onTriggerEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerExit", _s_set_onTriggerExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerStay", _s_set_onTriggerStay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerEnter2D", _s_set_onTriggerEnter2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerExit2D", _s_set_onTriggerExit2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerStay2D", _s_set_onTriggerStay2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionEnter", _s_set_onCollisionEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionExit", _s_set_onCollisionExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionStay", _s_set_onCollisionStay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionEnter2D", _s_set_onCollisionEnter2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionExit2D", _s_set_onCollisionExit2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionStay2D", _s_set_onCollisionStay2D);
            
			
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
					
					PhysicsColliderHandler gen_ret = new PhysicsColliderHandler();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PhysicsColliderHandler constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerStay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerEnter2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerEnter2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerExit2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerExit2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerStay2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerStay2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionStay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionEnter2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionEnter2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionExit2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionExit2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionStay2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionStay2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerEnter = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerExit = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerStay = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerEnter2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerEnter2D = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerExit2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerExit2D = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerStay2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerStay2D = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionEnter = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionExit = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionStay = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionEnter2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionEnter2D = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionExit2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionExit2D = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionStay2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PhysicsColliderHandler gen_to_be_invoked = (PhysicsColliderHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionStay2D = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
