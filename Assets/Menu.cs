using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Menu : MonoBehaviour {
  [SerializeField] AudioMixer audioMixer;

  public void setVolume(float volume) {
    print("getting here");
    float dbVolume = Mathf.Log10(volume) * 20;
    if (volume == 0.0f) {
      dbVolume = -80.0f;
    }
    audioMixer.SetFloat("MusicVolume", dbVolume);
  }
}