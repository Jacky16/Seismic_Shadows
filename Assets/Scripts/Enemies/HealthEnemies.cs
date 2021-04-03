using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemies : Health
{
    WaveSpawner beacons;

    private void Start()
    {
        beacons = GameObject.FindGameObjectWithTag("Player").GetComponent<WaveSpawner>();    
    }

    public override void OnDead()
    {
        beacons.SetNBeacons(1);
        HUDManager.singletone.UpdateBeacon(beacons.GetNBeacons());
        GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.SetActive(false);
        anim.SetTrigger("Death");
    }
    protected override void OnDamage()
    {
        anim.SetTrigger("Hit");
    }
}
