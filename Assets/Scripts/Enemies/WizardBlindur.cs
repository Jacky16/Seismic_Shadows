using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBlindur : Enemy
{
    [Header("Settings Blindur Berserker")]
    [SerializeField] float timeToAttackAgain;
    [SerializeField] GameObject wavePrefab;
    [SerializeField] Transform waveSpawn;
    float count = float.MaxValue;

    public override void StatesEnemy()
    {
        if (targetInRange)
        {
            count += Time.deltaTime;
            if(count >= timeToAttackAgain)
            {
                Attack();
                count = 0;
            }
        }
    }
    public override void Attack()
    {
        
    }
}
