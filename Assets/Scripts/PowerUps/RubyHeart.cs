using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyHeart : MonoBehaviour
{
    HealthPlayer hp;

    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(hp.GetLife() != hp.GetMaxLife())
            {
                hp.AddLife(1);
                HUDManager.singletone.UpdateLife(hp.GetLife(), hp.GetMaxLife());
                Destroy(gameObject);
            }
        }
    }
}
