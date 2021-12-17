using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBehaviour : StateMachineBehaviour {
  int explosions;
  // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    explosions = animator.GetInteger("explosions");
    explosions--;
    animator.SetInteger("explosions", explosions);
  }

  // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

  }

  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    int maxExplosions = animator.gameObject.GetComponent<Boss>().explosions;
    if (explosions > 0) animator.SetTrigger("explode");
    else animator.SetInteger("explosions", maxExplosions);
  }
}
