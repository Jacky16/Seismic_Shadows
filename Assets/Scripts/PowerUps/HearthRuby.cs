using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthRuby : MonoBehaviour
{
    HealthPlayer hp;
    [SerializeField] GameObject VFX_PickUp;

    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>();
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
}
