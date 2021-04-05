using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class FirstButtonSelected : MonoBehaviour
{
    EventSystem eventSystem;
    [SerializeField] GameObject firstGameObjectSelected;
    [SerializeField] UnityEvent OnEn;
    [SerializeField] UnityEvent OnDis;
    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        
    }
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        SetSelectedButton();
        OnEn.Invoke();
    }
    private void OnDisable()
    {
        OnDis.Invoke();
    }

    public void SetSelectedButton()
    {
        eventSystem.SetSelectedGameObject(firstGameObjectSelected);
    }
}
