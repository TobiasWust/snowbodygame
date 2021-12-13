using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
  public GameObject projectile;
  public Transform shotPoint;
  public float timeBetweenShots;
  public Pickup PickupObject;

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

  private void Update() {
    Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

    transform.rotation = rotation;

    if (Input.GetMouseButton(0)) {
      if (Time.time >= shotTime) {
        GameObject bullet = Instantiate(projectile, shotPoint.position, transform.rotation);
        bullet.layer = 6; // player layer to avoid self hitting
        shotTime = Time.time + timeBetweenShots;
      }
    }
  }
}
