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
    bool isBroken;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isBroken = false;
        
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
            StartCoroutine(SpawnPlatformAgain(0));
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            count += Time.deltaTime;
            if(count >= maxTime)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                count = 0;
                isBroken = true;
            }

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isBroken)
        {
            count += Time.deltaTime;

            if (count >= respawnTime)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = true;
                isBroken = false;

            }
        }
    }

    IEnumerator SpawnPlatformAgain(int num)
    {
        if (num == 1)
        {
            yield return new WaitForSecondsRealtime(maxTime);
        }

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;


        yield return new WaitForSecondsRealtime(respawnTime);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
