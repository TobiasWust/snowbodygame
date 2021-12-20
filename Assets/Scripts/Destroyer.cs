using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
  [SerializeField] GameObject root;
  [SerializeField] bool autoDestroy;
  [SerializeField] int delay = 0;

  private void Start() {
    if (autoDestroy) Invoke("handleDestroy", delay);
  }

  private void handleDestroy() {
    Destroy(gameObject);
  }

  private void OnDestroy() {
    if (root != null && root != gameObject) Destroy(root);
  }
}
