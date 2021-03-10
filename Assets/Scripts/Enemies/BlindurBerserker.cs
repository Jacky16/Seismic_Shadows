using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindurBerserker : Enemy
{
    [Header("Settings Blindur Berserker")]
    [SerializeField] float timeToCargerAgain;
    bool carger;
    Vector3 toGo;
    float count = float.MaxValue;

    public override void StatesEnemy()
    {
        if (!carger && targetInRange && !targetInStopDistance)
        {
            count += Time.fixedDeltaTime;
            if (timeToCargerAgain <= count)
            {
                toGo = target.position;
                dirEnemy = toGo - transform.position;
                count = 0;
                carger = true;
            }
        }else if (targetInStopDistance)
        {
            dirEnemy = Vector2.zero;
        }
    }
    public override Vector2 Path(Vector2 dirEnemy)
    {
        if (followPath && !targetInRange && !carger)
        {
            Transform currentWaypoint = wayPoints[nextPoint];

            float distanteToNextWaypoint = Vector2.Distance(transform.position, currentWaypoint.position);

            dirEnemy = currentWaypoint.position - transform.position;

            rb2d.velocity = (dirEnemy.normalized * currentSpeed * 100);

            if (distanteToNextWaypoint <= 20)
            {
                //Pasar al siguiente Waypoint
                countWaypoints += Time.fixedDeltaTime;
                if (countWaypoints >= timeBetweenWaypoints)
                {
                    NextWaypoint();
                    countWaypoints = 0;
                }
            }
        }

        return dirEnemy;
    }

    public override void Attack()
    {
        Debug.Log("Ataque Blindur");
        healthPlayer.Damage(damage);
    }

    public override void OnCollEnter(Collision2D col)
    {
        Invoke("SetCargerFalse", 1);
    }
    void SetCargerFalse()
    {
        carger = false;
    }
}
