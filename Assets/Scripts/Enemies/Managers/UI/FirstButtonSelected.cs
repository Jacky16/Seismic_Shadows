using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstButtonSelected : MonoBehaviour
{
    EventSystem eventSystem;
    [SerializeField] GameObject firstGameObjectSelected;
    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        
    }
    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(firstGameObjectSelected);
    }
}
