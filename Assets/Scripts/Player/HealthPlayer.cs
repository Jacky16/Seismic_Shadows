using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : Health
{  
    public override void Dead()
    {
        Debug.Log("Player is Dead");
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}

