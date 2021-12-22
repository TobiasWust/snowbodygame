using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
  [SerializeField] GameObject pauseMenuUi;
  public static bool gameIsPaused;

  private void Update() {
    if (!Input.GetKeyDown(KeyCode.Escape)) return;
    if (gameIsPaused) {
      resumeGame();
    } else {
      pauseGame();
    }
  }

  void pauseGame() {
    Time.timeScale = 0;
    gameIsPaused = true;
    pauseMenuUi.SetActive(true);
  }

  void resumeGame() {
    Time.timeScale = 1;
    gameIsPaused = false;
    pauseMenuUi.SetActive(false);
  }

}
