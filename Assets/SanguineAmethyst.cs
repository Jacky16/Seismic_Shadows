using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanguineAmethyst : MonoBehaviour
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
            hp.AddLife(1);
            Destroy(gameObject);
        }
    }
}
