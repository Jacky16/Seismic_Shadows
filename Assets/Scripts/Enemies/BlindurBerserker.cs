using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindurBerserker : Enemy
{
    [Header("Settings Blindur Berserker")]
    [SerializeField] float timeToCargerAgain;
    [SerializeField] float wallCheckDistance;
    bool carger;
    Vector3 toGo;
    float count = float.MaxValue;

    public override void StatesEnemy()
    {
        if (!carger && targetInRange && !targetInStopDistance && fov.IsInFov() && PlayerInRaycast())
        {
            count += Time.fixedDeltaTime;
            if (timeToCargerAgain <= count)
            {
                toGo = target.position;
                dirEnemy = toGo - transform.position;
                count = 0;
                carger = true;
                anim.SetBool("Carger", carger);
            }
        }
        else if (targetInStopDistance && !fov.IsInFov() && !PlayerInRaycast())
        {
            dirEnemy = Vector2.zero;
        }
        CheckWall();

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
        Collider2D col = Physics2D.OverlapBox(hitAttackPos.position, sizeHitBoxAttack, 0, raycastLayerMask);
        if (col != null)
        {
            if (col.gameObject.CompareTag("Player") && fov.IsInFov())
            {
                healthPlayer.Damage(damage);
                anim.SetTrigger("Attack");
                Debug.Log("Ataque Berserker");


            }
        }
    }

    void CheckWall()
    {
        Collider2D col = Physics2D.OverlapBox(hitAttackPos.position, sizeHitBoxAttack, 0, raycastLayerMask);
        if (col != null)
        {
            SetCargerFalse();
        }
    }
    void SetCargerFalse()
    {
        carger = false;
        anim.SetBool("Carger", carger);
        transform.Rotate(0, 180, 0);
    }
}
