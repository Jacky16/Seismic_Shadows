using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthPlayer : Health
{
    [Header("UI Settings")]
    [SerializeField] Image imageTransition;
    [SerializeField] float transitionDuration;
    [SerializeField] float betweenTimeTransition;

    [SerializeField] TPlayerManager tpPlayer;
    [SerializeField] PlayerMovement player;

    private void Start()
    {
        life = GameManager.singletone.GetLifePlayer();
        maxLife = GameManager.singletone.GetMaxLifePlayer();
        GameManager.singletone.UpdateHUDLife();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            AddMaxLife(9999);
            AddLife(9999);
            HUDManager.singletone.UpdateLife(life, maxLife);
        }
    }
    public override void OnDead()
    {
        anim.SetTrigger("Dead");
        GameManager.singletone.SetLifePlayerHUD(life, maxLife);
        StartCoroutine(DeadAnimation());
    }
    protected override void OnDamage()
    {
        anim.SetTrigger("Hit");
        GameManager.singletone.SetLifePlayerHUD(life, maxLife);
        StartCoroutine(Damage());
    }



    public void SetLife(int _life , int _maxLife)
    {
        life = _life;
        maxLife = _maxLife;
    }

    IEnumerator DeadAnimation()
    {
        player.SetCanMove(false);
        int currentLayer = gameObject.layer;
        gameObject.layer = 1;
        imageTransition.DOFade(1, transitionDuration);
        yield return new WaitForSeconds(betweenTimeTransition);
        tpPlayer.TeleportToCheckpoint();
        yield return new WaitForSeconds(.5f);
        player.SetCanMove(true);
        ResetLife();
        imageTransition.DOFade(0, transitionDuration);
        gameObject.layer = currentLayer;

    }
    IEnumerator Damage()
    {
        int currentLayer = gameObject.layer;
        gameObject.layer = 1;
        yield return new WaitForSeconds(2);
        gameObject.layer = currentLayer;
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

