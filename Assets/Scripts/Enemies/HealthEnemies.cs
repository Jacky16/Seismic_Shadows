using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemies : Health
{
    public override void OnDead()
    {
        GameManager.singletone.AddNBeacons(1);
        GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.SetActive(false);
        anim.SetTrigger("Death");
    }
    protected override void OnDamage()
    {
        anim.SetTrigger("Hit");
    }
}
