using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCleanUp : MonoBehaviour {
  public GameObject root;
  private void OnDestroy() {
    Destroy(root);
  }
}
