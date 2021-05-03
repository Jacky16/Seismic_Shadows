using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaivourStalactites : BehaivourWave
{
    [SerializeField] int gravityScale;
    [SerializeField] GameObject VFX_pinchoFall;
    [SerializeField] GameObject VFX_destroy;
    HealthPlayer playerHealth;
    bool activated;
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
            rb2d.gravityScale = gravityScale;
            activated = true;
            Instantiate(VFX_pinchoFall, transform.position, Quaternion.identity, null);
            GetComponent<SpriteRenderer>().sortingLayerName = "AlwaysVisible";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y - 50);
        Instantiate(VFX_destroy, pos, Quaternion.identity, null);
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.Damage(1);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {

            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(collision.gameObject.TryGetComponent(out HealthEnemies h))
            {
                h.Damage(3);
            }
            gameObject.SetActive(false);
        }
        Destroy(gameObject, 1);
    }
}
