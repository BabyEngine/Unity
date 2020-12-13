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
    public class AnimationStateWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(AnimationState);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 14, 14);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStateEnter", _m_OnStateEnter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStateExit", _m_OnStateExit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStateIK", _m_OnStateIK);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStateMachineEnter", _m_OnStateMachineEnter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStateMachineExit", _m_OnStateMachineExit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStateMove", _m_OnStateMove);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnStateUpdate", _m_OnStateUpdate);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateEnter", _g_get_onStateEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateEnter2", _g_get_onStateEnter2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateExit", _g_get_onStateExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateExit2", _g_get_onStateExit2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateIK", _g_get_onStateIK);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateIK2", _g_get_onStateIK2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateMachineEnter", _g_get_onStateMachineEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateMachineEnter2", _g_get_onStateMachineEnter2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateMachineExit", _g_get_onStateMachineExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateMachineExit2", _g_get_onStateMachineExit2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateMove", _g_get_onStateMove);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateMove2", _g_get_onStateMove2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateUpdate", _g_get_onStateUpdate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStateUpdate2", _g_get_onStateUpdate2);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateEnter", _s_set_onStateEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateEnter2", _s_set_onStateEnter2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateExit", _s_set_onStateExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateExit2", _s_set_onStateExit2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateIK", _s_set_onStateIK);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateIK2", _s_set_onStateIK2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateMachineEnter", _s_set_onStateMachineEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateMachineEnter2", _s_set_onStateMachineEnter2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateMachineExit", _s_set_onStateMachineExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateMachineExit2", _s_set_onStateMachineExit2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateMove", _s_set_onStateMove);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateMove2", _s_set_onStateMove2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateUpdate", _s_set_onStateUpdate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStateUpdate2", _s_set_onStateUpdate2);
            
			
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
					
					AnimationState gen_ret = new AnimationState();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationState constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStateEnter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Animator>(L, 2)&& translator.Assignable<UnityEngine.AnimatorStateInfo>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    UnityEngine.AnimatorStateInfo _stateInfo;translator.Get(L, 3, out _stateInfo);
                    int _layerIndex = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.OnStateEnter( _animator, _stateInfo, _layerIndex );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Animator>(L, 2)&& translator.Assignable<UnityEngine.AnimatorStateInfo>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.Animations.AnimatorControllerPlayable>(L, 5)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    UnityEngine.AnimatorStateInfo _stateInfo;translator.Get(L, 3, out _stateInfo);
                    int _layerIndex = LuaAPI.xlua_tointeger(L, 4);
                    UnityEngine.Animations.AnimatorControllerPlayable _controller;translator.Get(L, 5, out _controller);
                    
                    gen_to_be_invoked.OnStateEnter( _animator, _stateInfo, _layerIndex, _controller );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationState.OnStateEnter!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStateExit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Animator>(L, 2)&& translator.Assignable<UnityEngine.AnimatorStateInfo>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    UnityEngine.AnimatorStateInfo _stateInfo;translator.Get(L, 3, out _stateInfo);
                    int _layerIndex = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.OnStateExit( _animator, _stateInfo, _layerIndex );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Animator>(L, 2)&& translator.Assignable<UnityEngine.AnimatorStateInfo>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.Animations.AnimatorControllerPlayable>(L, 5)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    UnityEngine.AnimatorStateInfo _stateInfo;translator.Get(L, 3, out _stateInfo);
                    int _layerIndex = LuaAPI.xlua_tointeger(L, 4);
                    UnityEngine.Animations.AnimatorControllerPlayable _controller;translator.Get(L, 5, out _controller);
                    
                    gen_to_be_invoked.OnStateExit( _animator, _stateInfo, _layerIndex, _controller );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationState.OnStateExit!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStateIK(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Animator>(L, 2)&& translator.Assignable<UnityEngine.AnimatorStateInfo>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    UnityEngine.AnimatorStateInfo _stateInfo;translator.Get(L, 3, out _stateInfo);
                    int _layerIndex = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.OnStateIK( _animator, _stateInfo, _layerIndex );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Animator>(L, 2)&& translator.Assignable<UnityEngine.AnimatorStateInfo>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.Animations.AnimatorControllerPlayable>(L, 5)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    UnityEngine.AnimatorStateInfo _stateInfo;translator.Get(L, 3, out _stateInfo);
                    int _layerIndex = LuaAPI.xlua_tointeger(L, 4);
                    UnityEngine.Animations.AnimatorControllerPlayable _controller;translator.Get(L, 5, out _controller);
                    
                    gen_to_be_invoked.OnStateIK( _animator, _stateInfo, _layerIndex, _controller );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationState.OnStateIK!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStateMachineEnter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Animator>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    int _stateMachinePathHash = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.OnStateMachineEnter( _animator, _stateMachinePathHash );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Animator>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Animations.AnimatorControllerPlayable>(L, 4)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    int _stateMachinePathHash = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.Animations.AnimatorControllerPlayable _controller;translator.Get(L, 4, out _controller);
                    
                    gen_to_be_invoked.OnStateMachineEnter( _animator, _stateMachinePathHash, _controller );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationState.OnStateMachineEnter!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStateMachineExit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Animator>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    int _stateMachinePathHash = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.OnStateMachineExit( _animator, _stateMachinePathHash );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Animator>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Animations.AnimatorControllerPlayable>(L, 4)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    int _stateMachinePathHash = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.Animations.AnimatorControllerPlayable _controller;translator.Get(L, 4, out _controller);
                    
                    gen_to_be_invoked.OnStateMachineExit( _animator, _stateMachinePathHash, _controller );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationState.OnStateMachineExit!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStateMove(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Animator>(L, 2)&& translator.Assignable<UnityEngine.AnimatorStateInfo>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    UnityEngine.AnimatorStateInfo _stateInfo;translator.Get(L, 3, out _stateInfo);
                    int _layerIndex = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.OnStateMove( _animator, _stateInfo, _layerIndex );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Animator>(L, 2)&& translator.Assignable<UnityEngine.AnimatorStateInfo>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.Animations.AnimatorControllerPlayable>(L, 5)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    UnityEngine.AnimatorStateInfo _stateInfo;translator.Get(L, 3, out _stateInfo);
                    int _layerIndex = LuaAPI.xlua_tointeger(L, 4);
                    UnityEngine.Animations.AnimatorControllerPlayable _controller;translator.Get(L, 5, out _controller);
                    
                    gen_to_be_invoked.OnStateMove( _animator, _stateInfo, _layerIndex, _controller );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationState.OnStateMove!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStateUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Animator>(L, 2)&& translator.Assignable<UnityEngine.AnimatorStateInfo>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    UnityEngine.AnimatorStateInfo _stateInfo;translator.Get(L, 3, out _stateInfo);
                    int _layerIndex = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.OnStateUpdate( _animator, _stateInfo, _layerIndex );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Animator>(L, 2)&& translator.Assignable<UnityEngine.AnimatorStateInfo>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<UnityEngine.Animations.AnimatorControllerPlayable>(L, 5)) 
                {
                    UnityEngine.Animator _animator = (UnityEngine.Animator)translator.GetObject(L, 2, typeof(UnityEngine.Animator));
                    UnityEngine.AnimatorStateInfo _stateInfo;translator.Get(L, 3, out _stateInfo);
                    int _layerIndex = LuaAPI.xlua_tointeger(L, 4);
                    UnityEngine.Animations.AnimatorControllerPlayable _controller;translator.Get(L, 5, out _controller);
                    
                    gen_to_be_invoked.OnStateUpdate( _animator, _stateInfo, _layerIndex, _controller );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationState.OnStateUpdate!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateEnter2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateEnter2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateExit2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateExit2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateIK(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateIK);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateIK2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateIK2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateMachineEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateMachineEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateMachineEnter2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateMachineEnter2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateMachineExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateMachineExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateMachineExit2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateMachineExit2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateMove);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateMove2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateMove2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStateUpdate2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStateUpdate2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateEnter = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateEnter2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateEnter2 = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateExit = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateExit2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateExit2 = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateIK(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateIK = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateIK2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateIK2 = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateMachineEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateMachineEnter = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateMachineEnter2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateMachineEnter2 = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateMachineExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateMachineExit = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateMachineExit2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateMachineExit2 = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateMove = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateMove2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateMove2 = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateUpdate = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStateUpdate2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AnimationState gen_to_be_invoked = (AnimationState)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStateUpdate2 = (XLua.LuaFunction)translator.GetObject(L, 2, typeof(XLua.LuaFunction));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
