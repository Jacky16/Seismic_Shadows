using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBlindur : Enemy
{
    [Header("Settings Blindur Berserker")]
    [SerializeField]  ParticleSystem ps;
    float count = float.MaxValue;
    int pos = 0;
    bool canMove;


    protected override void StatesEnemy()
    {
        if (targetInRadius && targetInRaycast)
        {
            count += Time.fixedDeltaTime;

            if (count >= timeToAttack)
            {
                Attack();
                count = 0;
                canMove = true;
            }
            if (count >= timeToAttack - 0.8f && canMove)
            {
                SwitchPosition();
                canMove = false;
            }
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
