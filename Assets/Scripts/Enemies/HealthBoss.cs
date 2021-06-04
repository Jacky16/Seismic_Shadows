using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class HealthBoss : Health
{
    [SerializeField] Image lifeBar;
    FinalBoss boss;
    AudioManagerEnemies audioManagerEnemies;
    [SerializeField] Image fadeImage;
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
        GetComponent<SpriteRenderer>().DOFade(0, 1);
        fadeImage.DOFade(1, 1).OnComplete(() => SceneManager.LoadScene("Final"));
        //lightEnemy.SetActive(false);
        audioManagerEnemies.PlayAudioDeath();
    }
    protected override void OnDamage()
    {
        lifeBar.DOFillAmount(life / maxLife, .5f);
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
