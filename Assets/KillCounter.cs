using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour {
  private int count = 0;
  private void Start() {
    updateKillCount();
  }

  public void addKill() {
    count += 1;
    updateKillCount();
  }

  public void updateKillCount() {
    gameObject.GetComponent<TextMeshProUGUI>().text = $"{count}";
  }
}
