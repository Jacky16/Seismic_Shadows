using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindurBerserker : Enemy
{
    [Header("Settings Blindur Berserker")]
    [SerializeField] float timeToCargerAgain;
    [SerializeField] float wallCheckDistance;
    float countCargerAgain = 0;
    bool carger;
    Vector3 toGo;
    bool hasFlipped = false;
    bool firstTime = true;

    protected override void StatesEnemy()
    {
        CheckWall();
        if(targetInRaycast  && !targetInStopDistance && !carger)
        {
            if (firstTime)
            {
                countStartFollow += Time.fixedDeltaTime;
            }
            else
            {
                countCargerAgain += Time.fixedDeltaTime;
            }

            if(countStartFollow >= timeToStartFollow || countCargerAgain >= timeToCargerAgain)
            {
                carger = true;
                toGo = target.position;
                dir = toGo - transform.position;
                hasFlipped = false;
            }
        }
        if(targetInStopDistance && targetInRaycast)
        {
            dir = Vector2.zero;
        }
        FlipManager(dir.normalized.x);
        anim.SetBool("Carger", carger);
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
        if (spawnFlipped && transform.eulerAngles.y != 180)
        {
            Flip();     
        }
    }
    void SetCargerFalse(Collider2D col)
    {
        countCargerAgain = 0;
        countStartFollow = 0;

        carger = false;

        dir = Vector2.zero;
        toGo = Vector2.zero;

        anim.SetBool("Carger", carger);

        firstTime = false;

        if (col.CompareTag("Player"))
        {
            HealthPlayer healthPlayer = col.GetComponent<HealthPlayer>();
            healthPlayer.Damage(damage);
            if(healthPlayer.IsDead())
            StartCoroutine(ResetPos());
        }
        else
        {
            if (!hasFlipped )
            {
                Flip();
                hasFlipped = true;
            }
        }
    }
    protected override void OnCollEnter(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if(!healthEnemie.IsDead())
            col.gameObject.GetComponent<HealthPlayer>().Damage(1);
        }
    }
}
