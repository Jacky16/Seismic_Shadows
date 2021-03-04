using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindurGuardian : Enemy
{
   public override void Attack()
    {
        Debug.Log("Ataque Blindur");
        healthPlayer.Damage(damage);
    }
}
