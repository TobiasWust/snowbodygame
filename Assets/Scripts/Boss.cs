using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boss : MonoBehaviour, IDamageable {
  public int health;
  public int damage;
  public Enemy[] enemies;
  public GameObject landingEffect;
  public GameObject Explosion;
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

    hitShaderEffect();
    updateHealthUI(health);


    if (health <= maxHealth * .3f) {
      anim.SetBool("exploding", true);
    }

    if (health <= maxHealth * .6f) {
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

  public void explodeEvent() {
    camAnim.SetTrigger("shake");
    Instantiate(Explosion, transform.position, transform.rotation);
  }

  void hitShaderEffect() {
    SpriteRenderer[] sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();

    for (int i = 0; i < sprites.Length; i++) {
      DOTween.Kill(sprites[i].material);
      sprites[i].material.SetFloat("_HitEffectBlend", 0);
      sprites[i].material.DOFloat(1, "_HitEffectBlend", .1f).SetLoops(2, LoopType.Yoyo).SetId("hit");
    }
  }
}
