using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SanguineAmatist : MonoBehaviour
{
    HealthPlayer hp;
    [SerializeField] GameObject [] VFX_PickUps;

    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>();
        Animation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hp.AddMaxLife(1);
            hp.AddLife(999);
            GameManager.singletone.SetLifePlayerHUD(hp.GetLife(), hp.GetMaxLife());
            foreach(GameObject go in VFX_PickUps)
            {
                Instantiate(go, collision.transform.position + (Vector3.down * 40), transform.rotation = Quaternion.Euler(-100,0,0) , collision.transform);
            }
            Destroy(gameObject);
        }
    }
    void Animation()
    {
        float posy = transform.position.y;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveY(posy + 20, 2).SetEase(Ease.Linear));

        sequence.Append(transform.DOMoveY(posy,2)).SetEase(Ease.Linear);

        sequence.SetLoops(-1);
    }
}
