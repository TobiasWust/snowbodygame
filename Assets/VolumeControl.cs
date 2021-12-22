using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {
  [SerializeField] AudioMixer audioMixer;
  [SerializeField] Slider musicSlider;
  [SerializeField] Slider sfxSlider;

  private void Start() {
    float musicVolume;
    float sfxVolume;
    audioMixer.GetFloat("MusicVolume", out musicVolume);
    setMusicSlider(musicVolume);
    audioMixer.GetFloat("SfxVolume", out sfxVolume);
    setSfxSlider(sfxVolume);
  }

  public void setMusicVolume(float volume) {
    audioMixer.SetFloat("MusicVolume", floatToDb(volume));
  }

  public void setSfxVolume(float volume) {
    audioMixer.SetFloat("SfxVolume", floatToDb(volume));
  }

  public void setMusicSlider(float dbVolume) {
    musicSlider.value = DbToFloat(dbVolume);

  }
  public void setSfxSlider(float dbVolume) {
    sfxSlider.value = DbToFloat(dbVolume);
  }

  float floatToDb(float volume) {
    float dbVolume = Mathf.Log10(volume) * 60;
    if (volume == 0.0f) {
      dbVolume = -80.0f;
    }
    return dbVolume;
  }

  float DbToFloat(float dbVolume) {
    return Mathf.Pow(10, (dbVolume / 60));
  }
}
