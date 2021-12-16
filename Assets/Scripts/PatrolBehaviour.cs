using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour {

  public float speed;
  // public bool isBursting;
  // public GameObject Burst;

  GameObject[] patrolPoints;
  int randomPoint;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
    randomPoint = Random.Range(0, patrolPoints.Length);
  }

  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    animator.transform.position = Vector2.MoveTowards(animator.transform.position, patrolPoints[randomPoint].transform.position, speed * Time.deltaTime);

    if (Vector2.Distance(animator.transform.position, patrolPoints[randomPoint].transform.position) < .1f) {
      if (animator.GetBool("stage2")) animator.SetTrigger("explode");
      // if (isBursting) Instantiate(Burst, animator.transform.position, animator.transform.rotation);
      randomPoint = Random.Range(0, patrolPoints.Length);
    }
  }

  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

  }
}
