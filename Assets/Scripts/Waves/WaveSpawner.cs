using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{


    PlayerMovement player;
    //[Header("Point Wave")]


    //Settings Waves
    [Header("Step Wave")]
    [SerializeField] Animator animStepWave;

    [Header("Stealth Wave")]
    [SerializeField] Animator animStealthWave;


    [Header("Long Wave")]
    [SerializeField] Animator animLongWave;


    //[Header("Onda Rapida")]


    [Header("Interactive Wave")]
    [SerializeField] Animator animInteractiveWave;


    [Header("Push Wave")]
    [SerializeField] Animator animPushWave;


    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        animStepWave.SetBool("IsMoving", player.IsMoving() && !player.TouchingFront() && !player.IsStealth());
        animStealthWave.SetBool("IsStealthMode", player.IsMoving() && !player.TouchingFront() && player.IsStealth());
    }

    public void DoPushWave()
    {
        animPushWave.SetTrigger("DoWave");
    }
    public void DoInteractiveWave()
    {
        animInteractiveWave.SetTrigger("DoWave");
    }
    public void DoLongWave()
    {
        animLongWave.SetTrigger("DoWave");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(spawnPos.position, .3f);
    }
}
