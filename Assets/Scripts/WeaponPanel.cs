using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponPanel : MonoBehaviour {
  public TextMeshProUGUI WeaponName;
  public TextMeshProUGUI WeaponSpeed;
  public TextMeshProUGUI WeaponDamage;
  public Image WeaponSprite;

  public void setName(string name) {
    WeaponName.SetText(name);
  }
  public void setSpeed(float speed) {
    WeaponSpeed.SetText((speed * 10).ToString());
  }
  public void setDamage(float damage) {
    WeaponDamage.SetText(damage.ToString());
  }
  public void setSprite(Sprite sprite) {
    WeaponSprite.sprite = sprite;
  }
}
