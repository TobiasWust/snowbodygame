using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pickup : MonoBehaviour {
  public Weapon WeaponToEquip;
  public GameObject pickUpEffect;

  private void OnCollisionEnter2D(Collision2D other) {
    Debug.Log("name:" + WeaponToEquip.name);
    Debug.Log("firespeed:" + WeaponToEquip.timeBetweenShots);
    Debug.Log("damage:" + WeaponToEquip.projectile.GetComponent<Projectile>().damage);
    if (other.gameObject.tag == "Player") {
      if (pickUpEffect) Instantiate(pickUpEffect, transform.position, Quaternion.identity);
      other.gameObject.GetComponent<PlayerMover>().equipWeapon(WeaponToEquip);
      Destroy(gameObject);
    }
  }
}
