using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {
  [SerializeField] bool destroyOnLoad;
  private GameObject player;
  private void Awake() {
    player = GameObject.FindGameObjectWithTag("Player");
  }
  void Start() {
    if (destroyOnLoad) destroyPlayer();
  }

  public void destroyPlayer() {
    Destroy(player);
  }
}
