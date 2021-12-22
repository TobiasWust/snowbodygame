using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveInfo : MonoBehaviour {
  Animator anim;

  private void Start() {
    anim = GetComponent<Animator>();
  }

  public void show() {
    anim.SetTrigger("show");
  }
}
