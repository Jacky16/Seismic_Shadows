using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OptionsManager : MonoBehaviour
{
    [SerializeField] GameObject canvasBeforeOptions;
    [SerializeField] GameObject firstButtonSelected;
    EventSystem eventSystem;
    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(firstButtonSelected);
    }
    public void Return()
    {
        canvasBeforeOptions.SetActive(true);
        gameObject.SetActive(false);
    }
}
