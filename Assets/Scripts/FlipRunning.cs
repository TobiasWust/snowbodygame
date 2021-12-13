using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipRunning : MonoBehaviour {

  Transform player;
  private void Start() {
    player = GameObject.FindGameObjectWithTag("Player").transform;

  }

  void Update() {
    if (player != null) {
      Vector2 direction = transform.position - player.position;
      if (direction.x < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
      else transform.rotation = Quaternion.Euler(0, 0, 0);
    }
  }
}
