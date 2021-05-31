using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : Health
{
    FinalBoss boss;
    AudioManagerEnemies audioManagerEnemies;
    bool haveShield;
    private void Start()
    {
        boss = GetComponent<FinalBoss>();
    }
    public override void Damage(int _damage)
    {
        if (!haveShield)
        {
            life -= _damage;
            if (life <= 0 && !isDead && boss.GetCurrentZombies() == 0)
            {
                life = 0;
                isDead = true;
                OnDead();
            }
            if (!isDead)
            {
                StartCoroutine(AnimationRed());
                OnDamage();
            }
        }
    }
    public override void OnDead()
    {
        anim.SetTrigger("Death");
        //lightEnemy.SetActive(false);
        //audioManagerEnemies.PlayAudioDeath();
    }
    protected override void OnDamage()
    {
        anim.SetTrigger("Hit");
        boss.UpdatePhaseManager(life,maxLife);
        onDamage.Invoke();
    }
    void InstantiateDeathParticles()
    {
        //GetComponent<Enemy>().enabled = false;
        //GetComponent<Collider2D>().isTrigger = true;
        //GetComponent<Rigidbody2D>().simulated = false;
        //audioIdle.enabled = false;

        //Vector2 pos = new Vector2(transform.position.x, transform.position.y - 20);
        //Instantiate(VFX_destroy, pos, Quaternion.identity, null);

        //Destroy(gameObject, 10);
    }
    public void SetShield(bool _b)
    {
        haveShield = _b;
    }
    public bool GetShield()
    {
        return haveShield;
    }


}
