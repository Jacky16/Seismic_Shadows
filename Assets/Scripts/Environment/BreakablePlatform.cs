using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : BehaivourWave
{
    GameObject player;
    private float count;
    [Header("Tiempo para romperse")]
    [SerializeField] int maxTime;
    bool playerInPlattform;
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
    private void Update()
    {
        if (playerInPlattform)
        {
            count += Time.deltaTime;
            print(count);
            if (count >= maxTime)
            {
                this.gameObject.SetActive(false);              
            }
            
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //VARIABLES
        //count: contador de cuanto lleva encima de la plataforma.
        //maxTime: se le asigna valor desde el inspector, maximo tiempo
        //que el jugador puede estar encima de la plataforma sin que se rompa.

        //EXPLICACION
        //Si el player está más de maxTime encima de la plataforma,
        //esta se romperá.
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInPlattform = true;
        }

    }
}
