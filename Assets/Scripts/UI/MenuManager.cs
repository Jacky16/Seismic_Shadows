using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] GameObject canvasMainMenu;
    [SerializeField] GameObject canvasOptions;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClipButtonClick;

    [Header("Animation Components")]
    [SerializeField] AnimationMainMenuUI AnimationMainMenu;
    [SerializeField] AnimationOptionsUI animationOptions;
    [Space]
    [SerializeField] GameObject firstButtonSelected;
    [SerializeField] Animator animFade;
    EventSystem eventSystem;
    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }
    private void OnEnable()
    {
        canvasOptions.SetActive(false);
        eventSystem.SetSelectedGameObject(firstButtonSelected);

    }
    public void ContinueGame()
    {
        
    }

    public void NewGame()
    {
        Invoke("LoadFirstLevel", 2);
        animFade.SetTrigger("FadeIn");
    }
    public void Options()
    {
        canvasOptions.SetActive(true);
        audioSource.PlayOneShot(audioClipButtonClick);

        //Reproducir Tweens de ambos canvas

        //Desaparece
        AnimationMainMenu.PlayAnimationOut();
        //Aparece
        animationOptions.PlayAnimationIn();
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    void LoadFirstLevel()
    {
        SceneManager.LoadScene("1_UpperMantle");
    }
}
