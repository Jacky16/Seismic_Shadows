using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitApplication : MonoBehaviour
{
    [SerializeField] InputActionAsset inputAction;
    public void Exit()
    {
        Application.Quit();
    }
}
