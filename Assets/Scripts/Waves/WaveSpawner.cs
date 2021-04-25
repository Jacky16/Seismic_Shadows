using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    PlayerMovement player;
    Animator animPlayer;


    [Header("Enabled Waves")]
    [SerializeField] bool spawnInteracticeWave;
    [SerializeField] bool spawnPushWave;
    [SerializeField] bool spawnFlashWave;


    [Header("Step Wave")]
    [SerializeField] Animator animStepWave;

    [Header("Flash Wave")]
    [SerializeField] Animator animFlashWave;

    [Header("Interactive Wave")]
    [SerializeField] Animator animInteractiveWave;

    [Header("Push Wave")]
    [SerializeField] Animator animPushWave;

    [Header("Ground Wave")]
    [SerializeField] GameObject groundWavePrefab;


    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
        animPlayer = GetComponent<Animator>();

    }
    private void Update()
    {
        AnimControllers();
    }

    private void AnimControllers()
    {
        animStepWave.SetBool("IsMoving", player.IsMoving() && !player.TouchingFront() && !player.IsStealth());
        animStepWave.SetFloat("Speed", player.CurrentVelocityX());
        animFlashWave.SetBool("Spending", GameManager.singletone.IsSpeendingEnergy());
    }

    #region DoPlayerWaves
    public void DoPlayerFlashWave()
    {
        if (!spawnFlashWave) return;
        if (GameManager.singletone.GetEnergy() > 0)
        {
            animPlayer.SetTrigger("FlashWave");
            
        }
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
    void DoFlashWave()
    {
        GameManager.singletone.SetSpending();
    }

    public void DoGroundWave()
    {
        GameObject go = Instantiate(groundWavePrefab, player.transform.position, Quaternion.identity, null);
        Destroy(go, 1);
    }

    #endregion
}
