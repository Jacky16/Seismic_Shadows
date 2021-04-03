using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindurGuardian : Enemy
{
    bool followPlayer;
    public override void StatesEnemy()
    {
        //Perseguir al player
        if (fov.IsInFov() && playerInRaycast || followPlayer)
        {        
            dirEnemy = target.position - transform.position;
            followPlayer = true;
        }

        //Enemigo al lado del player
        if (targetInRange && targetInStopDistance)
        {
            dirEnemy = Vector2.zero;
        }

        //Si se sale del rango ya no persigue al player
        if(!targetInRange)
        {
            //Volver a la posicion inicial si no sigue la ruta
            followPlayer = false;
            if (!followPath)
            {
                dirEnemy = (Vector3)initPosition - transform.position;
            }
        }
    }
    public override Vector2 Path(Vector2 dirEnemy)
    {
       
        if (followPath && !followPlayer)
        {
            Transform currentWaypoint = wayPoints[nextPoint];

            float distanteToNextWaypoint = Vector2.Distance(transform.position, currentWaypoint.position);

            dirEnemy = currentWaypoint.position - transform.position;

            if (distanteToNextWaypoint <= 40)
            {
                //Pasar al siguiente Waypoint
                countWaypoints += Time.deltaTime;
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
         
        Collider2D  col = Physics2D.OverlapBox(hitAttackPos.position, sizeHitBoxAttack,0,raycastLayerMask);
        if(col != null)
        {
            if (col.gameObject.CompareTag("Player") && fov.IsInFov())
            {
                healthPlayer.Damage(damage);
                anim.SetTrigger("Attack");
                Debug.Log("Ataque Blindur");

            }
        }
    }


}
