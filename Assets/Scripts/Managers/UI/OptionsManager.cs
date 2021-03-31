using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OptionsManager : MonoBehaviour
{
    [SerializeField] GameObject canvasBeforeOptions;
    [SerializeField] GameObject firstButtonSelected;
    [SerializeField] EventSystem eventSystem;

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
