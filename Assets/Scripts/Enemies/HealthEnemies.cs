using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemies : Health
{
    [SerializeField] GameObject VFX_destroy;
    AudioManagerEnemies audioManagerEnemies;
    [SerializeField] GameObject lightEnemy;
    private void Start()
    {
        audioManagerEnemies = GetComponent<AudioManagerEnemies>();
    }
    public override void OnDead()
    {
        anim.SetTrigger("Death");
        lightEnemy.SetActive(false);
        audioManagerEnemies.PlayAudioDeath();
    }
    protected override void OnDamage()
    {
        anim.SetTrigger("Hit");
    }
    void InstantiateDeathParticles()
    {
        GetComponent<Enemy>().enabled = false;
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().simulated = false;

        Vector2 pos = new Vector2(transform.position.x, transform.position.y - 20);
        Instantiate(VFX_destroy, pos, Quaternion.identity, null);

        Destroy(gameObject, 10);
    }
}
