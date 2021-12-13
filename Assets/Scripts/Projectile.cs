using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  public float speed;
  public float lifeTime;
  public GameObject Explosion;
  public int damage;
  public GameObject HitEffect;

  private void Start() {
    Invoke("DestroyProjectile", lifeTime);
  }

  private void Update() {
    transform.Translate(Vector3.up * speed * Time.deltaTime);
  }

  private void OnTriggerEnter2D(Collider2D other) {
    Debug.Log("colliding");
    IDamageable damageable = other.GetComponent<IDamageable>();
    if (damageable != null) {
      damageable.takeDamage(damage);
      if (HitEffect) Instantiate(HitEffect, transform.position, transform.rotation);
      DestroyProjectile();
    }
  }

  void DestroyProjectile() {
    if (Explosion) Instantiate(Explosion, transform.position, transform.rotation);
    Destroy(gameObject);
  }
}
