using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IDamageable {
  public int health;
  public int damage;
  public Enemy[] enemies;
  public GameObject landingEffect;
  int maxHealth;

  Animator camAnim;
  Animator anim;

  void Start() {
    anim = GetComponent<Animator>();
    maxHealth = health;
    camAnim = GameObject.FindGameObjectWithTag("VCam").GetComponent<Animator>();
  }

  public void takeDamage(int damageAmount) {
    health -= damageAmount;

    updateHealthUI(health);

    if (health <= maxHealth * .5f) {
      anim.SetBool("stage2", true);
    }

    if (health <= 0) {
      Debug.Log("Boss dies :)");
      Destroy(gameObject);
    }

    Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
    Instantiate(randomEnemy, transform.position, transform.rotation);
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "Player") {
      other.gameObject.GetComponent<PlayerMover>().takeDamage(damage);
      anim.SetBool("stage2", false);
    }
  }

  void updateHealthUI(int health) {
    Debug.Log("Boss health is " + health);
  }

  public void LandingEvent() {
    camAnim.SetTrigger("shake");
    Instantiate(landingEffect, transform.position, transform.rotation);
  }
}
