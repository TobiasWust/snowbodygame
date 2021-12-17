using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipRunning : MonoBehaviour {

  public Transform target;

  void Update() {
    if (target != null) {
      Vector2 direction = transform.position - target.position;
      if (direction.x < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
      else transform.rotation = Quaternion.Euler(0, 0, 0);
    }
  }
}
