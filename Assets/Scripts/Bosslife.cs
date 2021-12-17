using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosslife : MonoBehaviour {
  [SerializeField] GameObject healthEffect;

  public void setHealth(float health) {
    Slider slider = gameObject.GetComponent<Slider>();
    slider.value = health;
    if (healthEffect) {
      GameObject splash = Instantiate(healthEffect, slider.handleRect.position, Quaternion.Euler(0, 0, -90));
      splash.GetComponentInChildren<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 101;
    }
  }
}
