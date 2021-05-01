using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : BehaivourWave
{
    [SerializeField] float timeToDisable;
    [SerializeField] float timeToActive;
    [SerializeField] GameObject VFX_destroy;
    AudioSource audioSource;
    float count;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
            DisableComponents();
            Invoke("ActiveComponents", timeToActive);
        }
    }

    void DisableComponents()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(VFX_destroy, transform.position, Quaternion.identity, null);
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
            audioSource.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
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
