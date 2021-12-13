using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable {
  public int health;
  public float speed;
  public float timeBetweenAttacks;
  public int damage;

  [HideInInspector]
  public Transform player;

  public virtual void Start() {
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }

  public void takeDamage(int damageAmount) {
    health -= damageAmount;

    if (health <= 0) {
      Destroy(gameObject);
    }
  }
}
