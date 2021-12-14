using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeleeEnemy : Enemy {
  public float stopDistance;
  public float attackDuration;

  private float attackTime;

  private void Update() {
    if (player != null) {
      if (Vector2.Distance(transform.position, player.position) > stopDistance) {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
      } else {
        if (Time.time >= attackTime) {
          transform.DOPunchPosition(player.position - transform.position, attackDuration, 1);
          attackTime = Time.time + timeBetweenAttacks;
        }
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "Player") {
      player.GetComponent<PlayerMover>().takeDamage(damage);
    }
  }

  private void OnDestroy() {
    DOTween.Kill(transform);
  }
}
