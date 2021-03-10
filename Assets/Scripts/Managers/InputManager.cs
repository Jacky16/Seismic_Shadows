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
    public void OnCheckWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.SetWaveToInstantiate(5,true);
        }
        if (ctx.canceled)
        {
            waveSpawner.SetWaveToInstantiate(5, false);
        }
    }
    public void OnSlowWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.SetWaveToInstantiate(1,true);
        }
        if (ctx.canceled)
        {
            waveSpawner.SetWaveToInstantiate(1, false);
        }
    }
    public void OnQuickWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.SetWaveToInstantiate(2, true);
        }
        if (ctx.canceled)
        {
            waveSpawner.SetWaveToInstantiate(2, false);
        }
    }
    public void OnInteractiveWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.SetWaveToInstantiate(3, true);
        }
        if (ctx.canceled)
        {
            waveSpawner.SetWaveToInstantiate(3, false);
        }
    }
    public void OnPushWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.SetWaveToInstantiate(4, true);
        }
        if (ctx.canceled)
        {
            waveSpawner.SetWaveToInstantiate(4, false);
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
    #endregion

}
