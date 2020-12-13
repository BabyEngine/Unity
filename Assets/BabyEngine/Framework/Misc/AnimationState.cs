using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using XLua;
[LuaCallCSharp]
public class AnimationState : StateMachineBehaviour {
    public LuaFunction onStateEnter;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { onStateEnter?.Call(animator, stateInfo, layerIndex); }
    public LuaFunction onStateEnter2;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { onStateEnter2?.Call(animator, stateInfo, layerIndex, controller); }
    public LuaFunction onStateExit;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { onStateExit?.Call(animator, stateInfo, layerIndex); }
    public LuaFunction onStateExit2;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { onStateExit2?.Call(animator, stateInfo, layerIndex, controller); }
    public LuaFunction onStateIK;
    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { onStateIK?.Call(animator, stateInfo, layerIndex); }
    public LuaFunction onStateIK2;
    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { onStateIK2?.Call(animator, stateInfo, layerIndex, controller); }
    public LuaFunction onStateMachineEnter;
    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash) { onStateMachineEnter?.Call(animator, stateMachinePathHash); }
    public LuaFunction onStateMachineEnter2;
    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash, AnimatorControllerPlayable controller) { onStateMachineEnter2?.Call(animator, stateMachinePathHash, controller); }
    public LuaFunction onStateMachineExit;
    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash) { onStateMachineExit?.Call(animator, stateMachinePathHash); }
    public LuaFunction onStateMachineExit2;
    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash, AnimatorControllerPlayable controller) { onStateMachineExit2?.Call(animator, stateMachinePathHash, controller); }
    public LuaFunction onStateMove;
    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { onStateMove?.Call(animator, stateInfo, layerIndex); }
    public LuaFunction onStateMove2;
    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { onStateMove2?.Call(animator, stateInfo, layerIndex, controller); }
    public LuaFunction onStateUpdate;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { onStateUpdate?.Call(animator, stateInfo, layerIndex); }
    public LuaFunction onStateUpdate2;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { onStateUpdate2?.Call(animator, stateInfo, layerIndex, controller); }
}
