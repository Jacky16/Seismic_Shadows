using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    PlayerMovement player;
    [HideInInspector]public Animator animPlayer;
    [Header("Flash Wave Settings")]
    [SerializeField] int sizeFlashWave = 3;
    [SerializeField] int maxSizeFlashWave = 3;
    [SerializeField] float energyBar = 0;

    [Header("Beacon Wave Settings")]
    [SerializeField] int nBeacons = 3;

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
    [SerializeField] GameObject beacon;

    [Header("Flash Wave")]
    [SerializeField] Animator animFlashWave;


    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
        animPlayer = GetComponent<Animator>();

    }
    private void Update()
    {
        animStepWave.SetBool("IsMoving", player.IsMoving() && !player.TouchingFront() && !player.IsStealth());
        animStealthWave.SetBool("IsStealthMode", player.IsMoving() && !player.TouchingFront() && player.IsStealth());
    }
    #region DoWaves

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
        if (nBeacons > 0)
        {
            nBeacons--;
            HUDManager.singletone.UpdateBeacon(nBeacons);
            GameObject go = Instantiate(beacon, new Vector3(player.transform.position.x, player.transform.position.y - 40, player.transform.position.z), Quaternion.identity, null);
            GameObject go2 = Instantiate(beaconWavePrefab, player.transform.position, Quaternion.identity, null);
            Destroy(go, 30);
            Destroy(go2, 30);
        }
    }
    public void DoFlashWave()
    {
        if(sizeFlashWave <= 3 && sizeFlashWave > 0)
        {
            animFlashWave.SetTrigger("DoWave");
            sizeFlashWave--;
            HUDManager.singletone.UpdateFlashWave(sizeFlashWave, maxSizeFlashWave);
        }
    }
    #endregion
    public void AddEnergyBar(float _f)
    {
        float sum = energyBar + _f;
        if (sum >= 100)
        {
            energyBar = 0;
            sizeFlashWave++;
            HUDManager.singletone.UpdateFlashWave(sizeFlashWave,maxSizeFlashWave);
        }
        else
        {
            energyBar = sum;
        }
        HUDManager.singletone.UpdateEnergyBar(energyBar);
    }
    public int GetFlashWaveCount()
    {
        return sizeFlashWave;
    }
    public int GetMaxFlashesWaves()
    {
        return maxSizeFlashWave;
    }
    public float GetEnergy()
    {
        return energyBar;
    }
}
