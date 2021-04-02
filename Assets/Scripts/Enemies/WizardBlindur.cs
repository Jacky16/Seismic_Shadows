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
  

    public override void StatesEnemy()
    {
        if (targetInRange && PlayerInRaycast())
        {
            count += Time.fixedDeltaTime;
            Vector2 dir = (target.position - transform.position).normalized;
           
            if (count >= timeToAttack)
            {
                Attack();
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
    public override Vector2 Path(Vector2 dirEnemy)
    {
        if (followPath && !targetInRange)
        {
            Transform currentWaypoint = wayPoints[nextPoint];

            float distanteToNextWaypoint = Vector2.Distance(transform.position, currentWaypoint.position);

            dirEnemy = currentWaypoint.position - transform.position;

            if (distanteToNextWaypoint <= 40)
            {
                //Pasar al siguiente Waypoint
                countWaypoints += Time.deltaTime;
                canMove = false;
                if (countWaypoints >= timeBetweenWaypoints)
                {
                    NextWaypoint();
                    countWaypoints = 0;
                    canMove = true;
                }
            }
        }

        return dirEnemy;
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
        anim.SetTrigger("Attack"); 
    }
}
