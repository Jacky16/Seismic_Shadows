using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidDemon : Enemy
{
    GameObject player;
    HealthPlayer hpp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hpp = player.GetComponent<HealthPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = (target.position - transform.position).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Stalactite")
        {
            healthEnemie.Damage(1);
        }
        if (collision.collider.tag == "Player")
        {
            hpp.Damage(1);
        }
    }
}
