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

    protected override void StatesEnemy()
    {
        CheckWall();
        if(targetInRadius && targetInFov && !targetInStopDistance && !carger)
        {
            countStartFollow += Time.fixedDeltaTime;

            if(countStartFollow >= timeToStartFollow)
            {
                carger = true;
                toGo = target.position;
                dir = toGo - transform.position;
            }
        }
        if(targetInStopDistance && targetInFov)
        {
            dir = Vector2.zero;
        }
        
    }

    void CheckWall()
    {
        Collider2D col = Physics2D.OverlapBox(hitAttackPos.position, sizeHitBoxAttack, 0, layerMaskEnvironent);
        if (col != null)
        {
            
            SetCargerFalse(col);
        }
    }
    IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(3);
        transform.position = initPos;
        dir = Vector2.zero;
    }
    void SetCargerFalse(Collider2D col)
    {
        countStartFollow = 0;
        carger = false;
        anim.SetBool("Carger", carger);
        if (col.CompareTag("Player"))
        {
            StartCoroutine(ResetPos());
            col.GetComponent<HealthPlayer>().Damage(damage);
        }
        else
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
