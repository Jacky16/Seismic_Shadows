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
    EventSystem eventSystem;
    bool isPause = true;

    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
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
        isPause =! isPause;
        if (!isPause) { 
            Time.timeScale = 0;
            canvasPause.SetActive(true);
            canvasDeadPlayer.SetActive(false);

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
        canvasPause.SetActive(false);
    }
    public void Resume()
    {
        canvasPause.SetActive(false);
        canvasDeadPlayer.SetActive(true);
        canvasOptions.SetActive(false);
        Time.timeScale = 1;
        
        //Desaparece el raton y se bloquea
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Exit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
