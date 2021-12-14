using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pickup : MonoBehaviour {
  public Weapon WeaponToEquip;

  private void Start() {

  }

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "Player") {
      other.gameObject.GetComponent<PlayerMover>().equipWeapon(WeaponToEquip);
      Destroy(gameObject);
    }
  }
}
