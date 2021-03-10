using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerManager : MonoBehaviour
{
    Vector3 pos;
    HealthPlayer hp;

    private void Awake()
    {
        hp = GetComponent<HealthPlayer>();
    }
    public void Teleport(int damage)
    {
        //EXPLICACION
        //Se llama desde Void.cs, cuando caes al vacio recibes 1 de daño
        //y te teletransportas a la posicion guardada al pasar por el checkpoint.

        hp.Damage(damage);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TP"))
        {
            //EXPLICACION
            //Cuando el player pasa por un checkpoint invisible justo
            //antes de un hoyo, se guarda la posicion en la variable pos.

            pos = collision.transform.position;
        }
    }
}
