using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
  public GameObject projectile;
  public Transform[] shotPoints;
  public float timeBetweenShots;

  [SerializeField] Pickup PickupObject;
  [SerializeField] GameObject ShootEffect;
  Animator camAnim;
  float shotTime;

  // for perspective view (for splitscreen)
  // public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
  //   Ray ray = Camera.main.ScreenPointToRay(screenPosition);
  //   Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
  //   float distance;
  //   xy.Raycast(ray, out distance);
  //   return ray.GetPoint(distance);
  // }
  // Vector2 direction = GetWorldPositionOnPlane(Input.mousePosition, 0) - transform.position;
  private void Start() {
    camAnim = GameObject.FindGameObjectWithTag("VCam").GetComponent<Animator>();
  }

  private void Update() {
    // mouse input
    Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    transform.rotation = rotation;


    // controller input
    // if (Input.GetAxis("RightStickVertical") != 0 || Input.GetAxis("RightStickHorizontal") != 0) {
    //   float angle = Mathf.Atan2(-Input.GetAxis("RightStickVertical"), Input.GetAxis("RightStickHorizontal")) * Mathf.Rad2Deg;
    //   Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    //   transform.rotation = rotation;
    // }

    if (Input.GetButton("Fire1") && Time.time >= shotTime) {
      if (camAnim) camAnim.SetTrigger("zoomShake");
      foreach (Transform shotPoint in shotPoints) {
        if (ShootEffect) Instantiate(ShootEffect, shotPoint.position, transform.rotation);
        Projectile bullet = Instantiate(projectile, shotPoint.position, shotPoint.rotation).GetComponent<Projectile>();
        bullet.layer = 6; // player layer to avoid self hitting
      }
      shotTime = Time.time + timeBetweenShots;
    }
  }
}
