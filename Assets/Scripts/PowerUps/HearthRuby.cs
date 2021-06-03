using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HearthRuby : MonoBehaviour
{
    HealthPlayer hp;
    [SerializeField] GameObject VFX_PickUp;

    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>();

        Animation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (hp.GetLife() != hp.GetMaxLife())
            {
                hp.AddLife(1);
                HUDManager.singletone.UpdateLife(hp.GetLife(), hp.GetMaxLife());
                Instantiate(VFX_PickUp, collision.transform.position, Quaternion.identity, collision.transform);
                Destroy(gameObject);
            }
        }
    }
    void Animation()
    {
        float posy = transform.position.y;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveY(posy + 20, 2).SetEase(Ease.Linear));

        sequence.Append(transform.DOMoveY(posy, 2)).SetEase(Ease.Linear);

        sequence.SetLoops(-1);
    }
}
