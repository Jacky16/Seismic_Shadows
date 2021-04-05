using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.Events;

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
    AnimationOptionsUI animationOptions;

    [SerializeField] UnityEvent OnReturn;
    bool isFullScreen;
    private void Awake()
    {
        animationOptions = GetComponent<AnimationOptionsUI>();
    }
    private void Start()
    {
        LoadValuesAudio();
        LoadSliders();
    }

    public void Return()
    {
        canvasBeforeOptions.SetActive(true);

        //Se desactiva el canvas cuando acaba la animacion
        animationOptions.PlayAnimationOut();

        SaveValuesAudio();

        //Se Llama a las animaciones Init del canvasBefore
        OnReturn.Invoke();
    }
    public void SaveValuesAudio()
    {
        PlayerPrefs.SetFloat("audioMusicValue", volumeMusic);
        PlayerPrefs.SetFloat("audioSoundValue", volumeSounds);
    }
    public void LoadValuesAudio()
    {
        volumeMusic = PlayerPrefs.GetFloat("audioMusicValue",0.75f);
        volumeSounds = PlayerPrefs.GetFloat("audioSoundValue", 0.75f);

        audiomixer.SetFloat("musicVolume", volumeMusic);
        audiomixer.SetFloat("soundVolume", volumeSounds);
    }

    public void LoadSliders()
    {
        sliderMusic.value = volumeMusic;
        sliderSounds.value = volumeSounds;
    }

    public void OnChangeMusicVolume(float _sliderValue)
    {
        audiomixer.SetFloat("musicVolume", Mathf.Log10(_sliderValue) * 20);
        volumeMusic = _sliderValue;
    }
    public void OnChangeSoundVolume(float _sliderValue)
    {
        audiomixer.SetFloat("soundVolume", Mathf.Log10(_sliderValue) * 20);
        volumeSounds = _sliderValue;
    }
   
    public void FullScreen(bool _b)
    {
        Screen.fullScreen = _b;
    }

}
