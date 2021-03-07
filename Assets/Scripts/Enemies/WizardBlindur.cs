using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBlindur : Enemy
{
    [Header("Settings Blindur Berserker")]
    [SerializeField] ParticleSystem ps;
    float count = float.MaxValue;
    int pos = 0;
    bool canMove;
    protected override void Start()
    {
       
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public override void StatesEnemy()
    {
        if (targetInRange)
        {
            count += Time.fixedDeltaTime;
            if(count >= timeToAttack)
            {
                ps.Play();
                count = 0;
                canMove = true;
            }
            if(count >=  timeToAttack - 0.8f && canMove)
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
    public override void Attack()
    {
        ps.Play();
    }
}
