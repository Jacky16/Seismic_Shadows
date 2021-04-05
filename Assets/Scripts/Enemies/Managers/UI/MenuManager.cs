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
    EventSystem eventSystem;
    [SerializeField] GameObject firstButtonSelected;
    [SerializeField] Animator animFade;
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
        //audioSource.PlayOneShot(audioClipButtonClick);
        canvasOptions.SetActive(true);
        canvasMainMenu.SetActive(false);
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
