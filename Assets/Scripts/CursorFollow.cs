using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorFollow : MonoBehaviour {
  //   public Sprite crossHair;
  private void Start() {
    Cursor.visible = false;
    // Cursor.SetCursor(crossHair.texture, Vector2.zero, CursorMode.Auto);

  }
  void Update() {
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
  }
}
