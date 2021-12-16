using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleProjectile : MonoBehaviour {
  public int damage;

  void OnParticleCollision(GameObject other) {
    IDamageable damageable = other.GetComponent<IDamageable>();
    if (damageable != null) {
      damageable.takeDamage(damage);
    }
  }
}
