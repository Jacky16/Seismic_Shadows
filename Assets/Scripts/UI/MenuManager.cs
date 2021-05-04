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
    [Header("Settings Background")]
    [SerializeField] Image image;
    [SerializeField] Image titleSelected;
    [SerializeField] Image titleNotSelected;
    [SerializeField] float speed;
    Material materialBacground;
    [Space]
    [SerializeField] GameObject firstButtonSelected;
    [SerializeField] Animator animFade;
    EventSystem eventSystem;
    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        titleSelected.enabled = false;
    }
    private void Start()
    {
        materialBacground = image.material;
    }
    private void Update()
    {
        Vector2 movement = new Vector2(speed * Time.deltaTime, 0);
        materialBacground.mainTextureOffset += movement;
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
        titleNotSelected.enabled = false;
        titleSelected.enabled = true;
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
        SceneManager.LoadScene("Story_1");
    }
}
