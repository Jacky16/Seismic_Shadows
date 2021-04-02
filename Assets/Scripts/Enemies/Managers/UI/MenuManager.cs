using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject firstButtonSelected;
    [SerializeField] GameObject canvasMainMenu;
    [SerializeField] GameObject canvasOptions;
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
        Invoke("LoadFirstLevel", 3);
    }
    public void Options()
    {
        canvasOptions.SetActive(true);
        canvasMainMenu.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    void LoadFirstLevel()
    {
        SceneManager.LoadScene("Upper Mantle");
    }
}
