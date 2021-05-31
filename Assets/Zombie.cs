using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    FinalBoss finalBoss;
    protected override void StatesEnemy()
    {
        if (targetInStopDistance)
        {
            countAttack += Time.deltaTime;
            if (countAttack >= timeToAttack)
            {
                anim.SetTrigger("Attack");
                countAttack = 0;
            }
            dir = Vector2.zero;
        }
        else
        {
            dir = (target.position - transform.position).normalized;
        }
        FlipManager(rb2d.velocity.normalized.x);
    }
    //Se ejecuta en un evento de la animacion
    protected override void Attack()
    {
        Collider2D col2D = Physics2D.OverlapBox(hitAttackPos.position, sizeHitBoxAttack, 0);
        if (col2D != null)
        {
            if (col2D.CompareTag("Player"))
            {
                col2D.GetComponent<HealthPlayer>().Damage(damage);
            }
        }
    }
}