using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindurGuardian : Enemy
{
    public override void StatesEnemy()
    {
        //Perseguir al player
        if (targetInRange && !targetInStopDistance)
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
        Debug.Log("Ataque Blindur");
        healthPlayer.Damage(damage);
    }
}
