using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject canvasDeadPlayer;
    [SerializeField] GameObject canvasOptions;
    [SerializeField] GameObject canvasPause;
    [SerializeField] GameObject firstButtonSelect;
    [SerializeField] AnimationOptionsUI animationOptions;
    AnimationPauseUI animationPause;
    PlayerMovement playerMovement;
    EventSystem eventSystem;
    bool isPause;

    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        animationPause = GetComponent<AnimationPauseUI>();
    }
    private void Start()
    {
        canvasPause.SetActive(false);
    }
    private void OnEnable()
    {
        canvasDeadPlayer.SetActive(false);
        eventSystem.SetSelectedGameObject(firstButtonSelect);
        firstButtonSelect.GetComponent<Button>().Select();
    }
    public void Pause()
    {
        isPause = !isPause;
        if (isPause) { 

            Time.timeScale = 0;
            //Canvas
            canvasPause.SetActive(true);
            canvasDeadPlayer.SetActive(false);

            //Tweens Animation
            animationPause.PlayAnimationInit();

            //Player Movement
            playerMovement.SetCanMove(false);

            //Aparece el raton y se desbloquea
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Resume();
        }
    }
    public void Options()
    {
        canvasOptions.SetActive(true);

        //Tweens Animations
        animationPause.PlayAnimationOut();
        animationOptions.PlayAnimationIn();
    }
    public void Resume()
    {
        Time.timeScale = 1;

        //Canvas
        canvasDeadPlayer.SetActive(true);
        canvasOptions.SetActive(false);

        //Tweens Animation
        animationPause.PlayAnimationOut();
        animationOptions.PlayAnimationOut();

        //Player Movement
        playerMovement.SetCanMove(false);

        //Desaparece el raton y se bloquea
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        isPause = false;
    }
    public void Exit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
