using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBlindur : Enemy
{
    [Header("Settings Blindur Berserker")]
    [SerializeField] float timeToTP;
    [SerializeField]  ParticleSystem ps;
    float countTP = 0;
    int pos = 0;
   

    protected override void StatesEnemy()
    {
        if (targetInRaycast)
        {
            countAttack += Time.fixedDeltaTime;
            countTP += Time.fixedDeltaTime;

            if (countAttack >= timeToAttack)
            {
                Attack();
                
                countAttack = 0;
            }
            if (countTP >= timeToTP) 
            {
                SwitchPosition();
                countTP = 0;
            }
        }
        else
        {
            countAttack = 0;
            countTP = 0;
        }
    }
   
    void SwitchPosition()
    {
        pos++;
        if(pos >= wayPoints.Length)
        {
            pos = 0;
        }
        transform.position = wayPoints[pos].position;
    }
    protected override void Attack()
    {
        ps.Play();
        anim.SetTrigger("Attack"); 
    }
}
