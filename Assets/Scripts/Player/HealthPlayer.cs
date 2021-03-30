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

    [SerializeField]TPlayerManager tpPlayer;
    [SerializeField] PlayerMovement player;


    public override void OnDead()
    {
        anim.SetTrigger("Dead");
        StartCoroutine(DeadAnimation());
    }
    protected override void OnDamage()
    {
        anim.SetTrigger("Hit");
    }

    IEnumerator DeadAnimation()
    {
        player.SetCanMove(false);
        imageTransition.DOFade(1, transitionDuration);
        yield return new WaitForSeconds(betweenTimeTransition);
        tpPlayer.TeleportToCheckpoint();
        yield return new WaitForSeconds(.5f);
        player.SetCanMove(true);
        ResetLife();
        imageTransition.DOFade(0, transitionDuration);
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

