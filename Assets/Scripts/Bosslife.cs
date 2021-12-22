using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosslife : MonoBehaviour {
  [SerializeField] GameObject healthEffect;
  Slider slider;

  private void Start() {
    slider = gameObject.GetComponent<Slider>();
  }

  public void setHealth(float health) {
    slider.value = health;
    if (healthEffect) {
      GameObject splash = Instantiate(healthEffect, slider.handleRect.position, Quaternion.Euler(0, 0, -90));
      splash.GetComponentInChildren<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 101;
    }
  }
}
