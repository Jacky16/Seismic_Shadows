using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] PlayerMovement player;
    [SerializeField] WaveSpawner waveSpawner;
    [SerializeField] PauseManager pauseManager;
    Vector2 axis;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(4);
        }
    }
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
            waveSpawner.animPlayer.SetTrigger("VisionWave");
        }
       
    }
    public void OnInteractiveWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.animPlayer.SetTrigger("InteractionWave");

        }

    }
    public void OnPushWave(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            waveSpawner.animPlayer.SetTrigger("PushWave");
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

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            pauseManager.Pause();
        }

    }

}
