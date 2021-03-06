using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
  private static Music instance;

  private AudioSource audioSource;

  private void Awake() {
    if (instance == null) {
      instance = this;
      DontDestroyOnLoad(transform.gameObject);
      audioSource = GetComponent<AudioSource>();
    } else Destroy(gameObject);
  }

  public void PlayMusic() {
    if (audioSource.isPlaying) return;
    audioSource.Play();
  }

  public void StopMusic() {
    audioSource.Stop();
  }
}
