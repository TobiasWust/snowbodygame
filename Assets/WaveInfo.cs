using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveInfo : MonoBehaviour {
  Animator anim;

  private void Awake() {
    anim = GetComponent<Animator>();
  }

  public void show() {
    anim.SetTrigger("show");
  }
}
