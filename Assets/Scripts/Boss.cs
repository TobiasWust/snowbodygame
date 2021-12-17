using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Boss : MonoBehaviour, IDamageable {
  public int health;
  public int damage;
  public Enemy[] enemies;
  public GameObject landingEffect;
  public GameObject Explosion;
  public Slider HealthBar;

  [HideInInspector]
  public int explosions;

  [SerializeField] int timeBetweenSpawns;
  float spawnTime;
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

    explosions = Mathf.RoundToInt((1 - ((float)health / maxHealth)) * 10);
    anim.SetInteger("explosions", explosions);

    if (health <= maxHealth * .5f) {
      anim.SetBool("stage2", true);
    }

    if (health <= 0) {
      Debug.Log("Boss dies :)");
      Destroy(gameObject);
    }

    if (Time.time > spawnTime) {
      Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
      Instantiate(randomEnemy, transform.position, transform.rotation);
      spawnTime = Time.time + timeBetweenSpawns;
    }
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "Player") {
      anim.SetBool("stage2", false);
      other.gameObject.GetComponent<PlayerMover>().takeDamage(damage);
    }
  }

  void updateHealthUI(int health) {
    HealthBar.GetComponent<Bosslife>().setHealth((float)health / (float)maxHealth);
  }

  public void LandingEvent() {
    camAnim.SetTrigger("shake");
    Instantiate(landingEffect, transform.position, transform.rotation);
  }

  public void explodeEvent() {
    camAnim.SetTrigger("shake");
    Instantiate(Explosion, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
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
