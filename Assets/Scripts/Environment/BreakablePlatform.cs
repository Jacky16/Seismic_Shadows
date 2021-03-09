using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : BehaivourWave
{
    GameObject player;
    private float count;
    [Header("Tiempo para romperse")]
    [SerializeField] int maxTime;
    [SerializeField] int respawnTime;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    protected override void ActionOnWave(Collider2D col)
    {
        //EXPLICACION
        //Si se destruye una plataforma agrietada con la onda de interaccion
        //en vez de destruir el gameobject, lo desactivamos.
        //Está hecho asi por si en un futuro queremos hacer que pasados X segundos
        //vuelva a aparecer la plataforma.

        if (col.tag == "InteractiveWave")
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpawnPlatformAgain());

        }
    }

    IEnumerator SpawnPlatformAgain()
    {
        yield return new WaitForSecondsRealtime(maxTime);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSecondsRealtime(respawnTime);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
