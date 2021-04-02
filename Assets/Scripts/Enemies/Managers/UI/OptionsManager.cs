using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class OptionsManager : MonoBehaviour
{
    [Header("Canvas GameObjects")]
    [SerializeField] GameObject canvasBeforeOptions;
    [SerializeField] GameObject canvasOptions;
    [SerializeField] GameObject firstButtonSelected;
    [Header("Audio")]
    [SerializeField] AudioMixer audiomixer;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSounds;
    float volumeMusic;
    float volumeSounds;

    [SerializeField] Toggle fullScreenToogle;
    bool isFullScreen;
    private void Awake()
    {
        InitVolumeSettings();
       
    }
  
    public void Return()
    {
        canvasBeforeOptions.SetActive(true);
        canvasOptions.SetActive(false);
    }

    public void OnChangeMusicVolume()
    {
        audiomixer.SetFloat("musicVolume", sliderMusic.value);
        PlayerPrefs.SetFloat("musicVolume", sliderMusic.value);
    }
    public void OnChangeSoundVolume()
    {
        audiomixer.SetFloat("soundVolume", sliderSounds.value);
        PlayerPrefs.SetFloat("soundVolume", sliderSounds.value);
    }
    void InitVolumeSettings()
    {
        //Music
        volumeMusic = PlayerPrefs.GetFloat("musicVolume", 0);
        sliderMusic.value = volumeMusic;
        //Sounds
        volumeSounds = PlayerPrefs.GetFloat("soundVolume", 0);
        sliderSounds.value = volumeSounds;

    }
    public void FullScreen(bool _b)
    {
        Screen.fullScreen = _b;
    }

}
