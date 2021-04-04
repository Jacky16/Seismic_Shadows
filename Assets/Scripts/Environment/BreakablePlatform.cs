using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : BehaivourWave
{

    [SerializeField] float timeToDisable;
    [SerializeField] float timeToActive;
    float count;
   
    protected override void ActionOnWave(Collider2D col)
    {
        //EXPLICACION
        //Si se destruye una plataforma agrietada con la onda de interaccion
        //en vez de destruir el gameobject, lo desactivamos.
        //Está hecho asi por si en un futuro queremos hacer que pasados X segundos
        //vuelva a aparecer la plataforma.

        if (col.tag == "InteractiveWave")
        {
            DisableComponents();
            Invoke("ActiveComponents", timeToActive);
        }
    }

    void DisableComponents()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void ActiveComponents()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            count = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            count += Time.deltaTime;
            if(count >= timeToDisable)
            {
                DisableComponents();
                Invoke("ActiveComponents", timeToActive);
            }
        }
    }
  
}
