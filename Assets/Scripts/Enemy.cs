using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable {
  public int health;
  public float speed;
  public float timeBetweenAttacks;
  public int damage;
  public int pickupChance;
  public GameObject[] pickups;

  [HideInInspector]
  public Transform player;

  public virtual void Start() {
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }

  public void takeDamage(int damageAmount) {
    health -= damageAmount;

    if (health <= 0) {
      int randomNumber = Random.Range(0, 101);
      if (randomNumber <= pickupChance) {
        GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
        Instantiate(randomPickup, transform.position, transform.rotation);
      }
      Destroy(gameObject);
    }
  }
}
