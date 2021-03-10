using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemies : Health
{
    public override void Dead()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.SetActive(false);
    }


}
