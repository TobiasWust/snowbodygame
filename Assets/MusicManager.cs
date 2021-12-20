using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
  private static MusicManager instance;

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

  public void setVolume(float volume) {
    audioSource.volume = volume;
  }
}
