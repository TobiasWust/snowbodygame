using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycleSounds : MonoBehaviour {
  [SerializeField] GameObject spawnSound;
  [SerializeField] GameObject destroySound;

  private void Start() {
    if (spawnSound) Instantiate(spawnSound, transform.position, transform.rotation);
  }
  private void OnDestroy() {
    if (spawnSound) Instantiate(destroySound, transform.position, transform.rotation);
  }
}
