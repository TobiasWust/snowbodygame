using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Boss : MonoBehaviour, IDamageable {
  [SerializeField] Enemy[] enemies;
  [SerializeField] GameObject[] CarrotExplosions;
  [SerializeField] GameObject landingEffect;
  [SerializeField] int damage;
  [SerializeField] GameObject HealthBarPrefab;
  [SerializeField] int timeBetweenSpawns;
  [SerializeField] float stageTwoPercent;
  [SerializeField] int carrotExplosionOffset;
  [SerializeField] int health;

  [HideInInspector]
  public int explosions;

  float spawnTime;
  int maxHealth;

  Animator camAnim;
  Animator anim;

  Bosslife Healthbar;

  void Start() {
    anim = GetComponent<Animator>();
    maxHealth = health;
    camAnim = GameObject.FindGameObjectWithTag("VCam").GetComponent<Animator>();

    initializeHealthBar();
  }

  public void takeDamage(int damageAmount) {
    health -= damageAmount;

    hitShaderEffect();
    updateHealthUI(health);

    explosions = Mathf.RoundToInt((1 - ((float)health / maxHealth)) * 10) - carrotExplosionOffset;
    anim.SetInteger("explosions", explosions);

    if (health <= maxHealth * stageTwoPercent) {
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
    if (Healthbar) Healthbar.setHealth((float)health / (float)maxHealth);
  }

  public void LandingEvent() {
    camAnim.SetTrigger("shake");
    Instantiate(landingEffect, transform.position, transform.rotation);
  }

  public void explodeEvent() {
    camAnim.SetTrigger("shake");
    GameObject RandomCarrotExplosion = CarrotExplosions[Random.Range(0, CarrotExplosions.Length)];
    ParticleSystem particles = Instantiate(RandomCarrotExplosion, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))).GetComponentInChildren<ParticleSystem>();
    var collision = particles.collision;
    collision.collidesWith = collision.collidesWith & ~(1 << 7); //magic to toggle layer;

  }

  void hitShaderEffect() {
    SpriteRenderer[] sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();

    for (int i = 0; i < sprites.Length; i++) {
      DOTween.Kill(sprites[i].material);
      sprites[i].material.SetFloat("_HitEffectBlend", 0);
      sprites[i].material.DOFloat(1, "_HitEffectBlend", .1f).SetLoops(2, LoopType.Yoyo).SetId("hit");
    }
  }

  void initializeHealthBar() {
    GameObject _healthBar = Instantiate(HealthBarPrefab);
    Healthbar = _healthBar.GetComponent<Bosslife>();
    Healthbar.transform.SetParent(GameObject.FindGameObjectWithTag("UI").transform, false);
  }
}
