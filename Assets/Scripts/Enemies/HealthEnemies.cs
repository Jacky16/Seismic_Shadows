using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemies : Health
{
    public override void OnDead()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.SetActive(false);
    }


}
