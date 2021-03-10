﻿using System.Collections;
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
            hp.AddMaxLife(1);
            hp.AddLife(999);
            Destroy(gameObject);
        }
    }
}
