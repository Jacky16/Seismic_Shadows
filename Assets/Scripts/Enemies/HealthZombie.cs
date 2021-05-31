using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZombie : Health
{
    AudioManagerEnemies audioManagerEnemies;
    [SerializeField] GameObject VFX_destroy;
    FinalBoss finalBoss;


    private void Start()
    {
        audioManagerEnemies = GetComponent<AudioManagerEnemies>();
        finalBoss = GameObject.FindGameObjectWithTag("FinalBoss").GetComponent<FinalBoss>();
    }
    public override void OnDead()
    {
        finalBoss.DeathAZombie();

        anim.SetTrigger("Death");
        //audioManagerEnemies.PlayAudioDeath();

    }
   
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
