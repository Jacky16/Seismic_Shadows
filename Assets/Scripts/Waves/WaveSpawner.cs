using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    PlayerMovement player;
    Animator animPlayer;

    [Header("Enabled Waves")]
    [SerializeField] bool spawnLongWave;
    [SerializeField] bool spawnInteracticeWave;
    [SerializeField] bool spawnPushWave;
    [SerializeField] bool spawnBeaconWave;
    [SerializeField] bool spawnFlashWave;


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

    #region DoPlayerWaves
    public void DoPlayerLongWave()
    {
        if (!spawnLongWave) return;
        animPlayer.SetTrigger("VisionWave");
    }
    public void DoPlayerInteractiveWave()
    {
        if (!spawnInteracticeWave) return;
        animPlayer.SetTrigger("InteractionWave");
    }
    public void DoPlayerPushWave()
    {
        if (!spawnPushWave) return;
        animPlayer.SetTrigger("PushWave");
    }
    #endregion

    #region DoWaves

    //Se ejecuta en la animacion del player
    void DoPushWave()
    {
        animPushWave.SetTrigger("DoWave");
    }
    //Se ejecuta en la animacion del player
    void DoInteractiveWave()
    {
        animInteractiveWave.SetTrigger("DoWave");
    }
    //Se ejecuta en la animacion del player
    void DoLongWave()
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
        if (!spawnBeaconWave) return;
        int sizeNBeacons = GameManager.singletone.GetNBeacons();
        if (sizeNBeacons > 0)
        {
            sizeNBeacons--;
            GameManager.singletone.SetNBeacons(sizeNBeacons);
            GameObject go = Instantiate(beacon, new Vector3(player.transform.position.x, player.transform.position.y - 40, player.transform.position.z), Quaternion.identity, null);
            GameObject go2 = Instantiate(beaconWavePrefab, player.transform.position, Quaternion.identity, null);
            Destroy(go, 30);
            Destroy(go2, 30);

        }
    }
    public void DoFlashWave()
    {
        if (!spawnFlashWave) return;
        int sizeFlashVe = GameManager.singletone.GetFlashWaveCount();
        int maxSizeFlashWave = GameManager.singletone.GetMaxFlashesWaves();
        if (sizeFlashVe > 0)
        {
            animFlashWave.SetTrigger("DoWave");
            GameManager.singletone.UseFlashWave();
        }
    }

    #endregion
}
