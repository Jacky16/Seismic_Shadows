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
    public override void Attack()
    {
        Debug.Log("Ataque Blindur");
        healthPlayer.Damage(damage);
    }

    public override void OnCollEnter(Collision2D col)
    {
        carger = false;
    }
}
