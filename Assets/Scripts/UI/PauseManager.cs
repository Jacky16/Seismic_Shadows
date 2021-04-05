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
    EventSystem eventSystem;
    bool isPause;

    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
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

            canvasPause.SetActive(true);
            Time.timeScale = 0;
            canvasDeadPlayer.SetActive(false);
            animationPause.PlayAnimationInit();
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
        animationPause.PlayAnimationOut();
        animationOptions.PlayAnimationIn();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        canvasDeadPlayer.SetActive(true);
        canvasOptions.SetActive(false);
        //Desaparece el raton y se bloquea
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animationPause.PlayAnimationOut();
        animationOptions.PlayAnimationOut();
        isPause = false;
    }
    public void Exit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
