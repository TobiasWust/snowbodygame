using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Version : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {
    gameObject.GetComponent<TextMeshProUGUI>().text = $"v{Application.version}";
  }
}
