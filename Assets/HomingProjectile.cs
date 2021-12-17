using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : Projectile {
  [SerializeField] Transform target;

  public override void Update() {
    if (target != null) {
      gameObject.GetComponent<FlipRunning>().target = target;
      transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    } else {
      base.Update();
    }
    FindClosest();
  }

  void FindClosest() {
    float distanceToClosestEnemy = Mathf.Infinity;
    GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

    foreach (GameObject currentEnemy in allEnemies) {
      float distanceToEnemy = Vector2.Distance(currentEnemy.transform.position, transform.position);
      if (distanceToEnemy < distanceToClosestEnemy) {
        distanceToClosestEnemy = distanceToEnemy;
        target = currentEnemy.transform;
      }
    }
  }
}
