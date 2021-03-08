using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaivourStalactites : BehaivourWave
{
    protected HealthPlayer playerHealth;
    public bool activated;

    private void Start()
    {
        activated = false;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>();
    }
    protected override void ActionOnWave(Collider2D col)
    {
        if (col.gameObject.CompareTag("InteractiveWave"))
        {
            //Esto se ejecuta cuando una onda interactiva choca con este objeto
            rb2d.gravityScale = 30;
            activated = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.Damage(1);
            if (activated)
            {
                this.gameObject.SetActive(false);
            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }

}
