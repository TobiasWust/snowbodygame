using UnityEngine;

public class HealthPickup : MonoBehaviour {
  [SerializeField] GameObject pickUpEffect;
  [SerializeField] GameObject pickUpSound;

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "Player") {
      if (pickUpEffect) Instantiate(pickUpEffect, transform.position, Quaternion.identity);
      if (pickUpSound) Instantiate(pickUpSound, transform.position, Quaternion.identity);
      other.gameObject.GetComponent<PlayerMover>().addHealth(1);
      Destroy(gameObject);
    }
  }
}
