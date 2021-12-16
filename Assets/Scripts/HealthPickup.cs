using UnityEngine;

public class HealthPickup : MonoBehaviour {
  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "Player") {
      other.gameObject.GetComponent<PlayerMover>().addHealth(1);
      Destroy(gameObject);
    }
  }
}
