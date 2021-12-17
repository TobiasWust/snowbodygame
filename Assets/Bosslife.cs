using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosslife : MonoBehaviour {
  [SerializeField] GameObject healthEffect;

  public void setHealth(float health) {
    Slider slider = gameObject.GetComponent<Slider>();
    slider.value = health;
    if (healthEffect) Instantiate(healthEffect, slider.handleRect.position, Quaternion.identity);
  }
}
