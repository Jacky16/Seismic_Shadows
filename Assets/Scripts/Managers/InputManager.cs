using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] PlayerMovement player;
    [SerializeField] WaveSpawner waveSpawner;
    Vector2 axis;
    
   

    //Funciones que se ejecutan en el inspector
    #region Player
    public void OnMovement(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            axis = ctx.ReadValue<Vector2>();
        }
        if (ctx.canceled)
        {
            axis = Vector2.zero;
        }
        player.SetAxis(axis);
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            player.Jump();
        }
    }
    #endregion

    #region Waves
   
    public void OnSlowWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.DoLongWave();
        }
       
    }
    public void OnInteractiveWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.DoInteractiveWave();
        }
      
    }
    public void OnPushWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.DoPushWave();
        }    
    }
    public void OnStealth(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            player.SetStealth(true);
        }
        if (ctx.canceled)
        {
            player.SetStealth(false);
        }
    }
    public void OnBeaconWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.DoBeaconWave();
        }

    }
    public void OnFlashWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.DoFlashWave();
        }

    }
    #endregion

}
