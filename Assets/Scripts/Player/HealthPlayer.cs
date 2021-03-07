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
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            int dmg = other.GetComponentInParent<Enemy>().Damage();
            Damage(dmg);
        }
    }
}

