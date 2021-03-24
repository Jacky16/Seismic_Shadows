using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    PlayerMovement player;
    
    //Settings Waves
    [Header("Step Wave")]
    [SerializeField] Animator animStepWave;

    [Header("Stealth Wave")]
    [SerializeField] Animator animStealthWave;

    [Header("Long Wave")]
    [SerializeField] Animator animLongWave;

    [Header("Interactive Wave")]
    [SerializeField] Animator animInteractiveWave;

    [Header("Push Wave")]
    [SerializeField] Animator animPushWave;

    [Header("Ground Wave")]
    [SerializeField] GameObject groundWavePrefab;

    [Header("Beacon Wave")]
    [SerializeField] GameObject beaconWavePrefab;

    [Header("Flash Wave")]
    [SerializeField] Animator animFlashWave;


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
    public void DoGroundWave()
    {
        GameObject go = Instantiate(groundWavePrefab, player.transform.position, Quaternion.identity, null);
        Destroy(go, 1);
    }
    public void DoBeaconWave()
    {
        GameObject go = Instantiate(beaconWavePrefab, player.transform.position, Quaternion.identity, null);
        Destroy(go,30);
    }
    public void DoFlashWave()
    {
        animFlashWave.SetTrigger("DoWave");
    }


}
