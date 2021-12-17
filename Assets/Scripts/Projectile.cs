using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  public float speed;
  public float lifeTime;
  public GameObject Explosion;
  public int damage;
  public GameObject HitEffect;
  public int layer;

  private void Start() {
    Invoke("DestroyProjectile", lifeTime);
    gameObject.layer = layer;
  }

  public virtual void Update() {
    transform.Translate(Vector3.up * speed * Time.deltaTime);
  }

  private void OnTriggerEnter2D(Collider2D other) {
    IDamageable damageable = other.GetComponent<IDamageable>();
    if (damageable != null) {
      damageable.takeDamage(damage);
      if (HitEffect) Instantiate(HitEffect, transform.position, transform.rotation);
      DestroyProjectile();
    }
  }

  void DestroyProjectile() {
    if (Explosion) {
      ParticleSystem particles = Instantiate(Explosion, transform.position, transform.rotation).GetComponentInChildren<ParticleSystem>();
      var collision = particles.collision;
      collision.collidesWith = collision.collidesWith & ~(1 << layer); //magic to toggle layer;
    }
    Destroy(gameObject);
  }
}
