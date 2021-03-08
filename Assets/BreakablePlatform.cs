using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    GameObject player;
    private float count;
    [Header("Tiempo para romperse")]
    [SerializeField] int maxTime;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //EXPLICACION
        //Si se destruye una plataforma agrietada con la onda de interaccion
        //en vez de destruir el gameobject, lo desactivamos.
        //Está hecho asi por si en un futuro queremos hacer que pasados X segundos
        //vuelva a aparecer la plataforma.

        if (collision.tag == "InteractiveWave")
        {
            this.gameObject.SetActive(false);
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
      
        if (collision.collider.tag == "Player")
        {
            count += Time.deltaTime;
            if (count >= maxTime)
            {
                this.gameObject.SetActive(false);
                count = 0;
            }
        }
    }
}
