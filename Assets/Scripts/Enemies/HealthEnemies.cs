using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemies : Health
{
    [SerializeField] GameObject VFX_destroy;
    [SerializeField] AudioManagerEnemies audioManagerEnemies;
    
    public override void OnDead()
    {
        anim.SetTrigger("Death");
        audioManagerEnemies.PlayAudioDeath();
    }
    protected override void OnDamage()
    {
        anim.SetTrigger("Hit");
    }
    void InstantiateDeathParticles()
    {
        Destroy(gameObject,1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y - 20);
        Instantiate(VFX_destroy, pos, Quaternion.identity, null);
    }
}
