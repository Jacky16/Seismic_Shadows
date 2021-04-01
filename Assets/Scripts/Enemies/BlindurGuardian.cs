using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindurGuardian : Enemy
{
    public override void StatesEnemy()
    {
        //Perseguir al player
        if (targetInRange && !targetInStopDistance || fov.IsInFov() && !targetInStopDistance)
        {
            dirEnemy = target.position - transform.position;
        }
        //Enemigo al lado del player
        else if (targetInRange && targetInStopDistance)
        {
            dirEnemy = Vector2.zero;
        }
        else
        {
            //Volver a la posicion inicial si no sigue la ruta
            if (!followPath)
            {
                dirEnemy = (Vector3)initPosition - transform.position;
            }
        }
    }
    public override void Attack()
    {
         
        Collider2D  col = Physics2D.OverlapBox(hitAttackPos.position, sizeHitBoxAttack,0);
        if(col.gameObject != null)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                healthPlayer.Damage(damage);
                anim.SetTrigger("Attack");
                Debug.Log("Ataque Blindur");

            }
        }
    }


}
