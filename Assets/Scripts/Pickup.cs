using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pickup : MonoBehaviour {
  public Weapon WeaponToEquip;
  public GameObject pickUpEffect;
  public GameObject pickUpSound;

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "Player") {
      if (pickUpEffect) Instantiate(pickUpEffect, transform.position, Quaternion.identity);
      if (pickUpSound) Instantiate(pickUpSound, transform.position, Quaternion.identity);
      other.gameObject.GetComponent<PlayerMover>().equipWeapon(WeaponToEquip);
      Destroy(gameObject);
    }
  }
}
