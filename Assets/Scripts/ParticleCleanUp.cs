using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCleanUp : MonoBehaviour {
  public GameObject root;
  public int delay = 0;
  private void OnDestroy() {
    if (root == null) root = gameObject;
    Destroy(root, delay);
  }
}
