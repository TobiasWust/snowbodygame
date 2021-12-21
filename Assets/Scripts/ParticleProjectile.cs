using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleProjectile : MonoBehaviour {
  [SerializeField] int damage;
  [SerializeField] bool doScreenShake;

  Animator camAnim;

  private void Start() {
    if (doScreenShake) {

      camAnim = GameObject.FindGameObjectWithTag("VCam")?.GetComponent<Animator>();
      camAnim?.SetTrigger("shake");
    }
  }

  void OnParticleCollision(GameObject other) {
    IDamageable damageable = other.GetComponent<IDamageable>();
    if (damageable != null) {
      damageable.takeDamage(damage);
    }
  }
}
