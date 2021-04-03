using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerManager : MonoBehaviour
{
    Vector3 posTpVoid;
    Vector3 posCheckPoint;
    HealthPlayer hp;
    WaveSpawner beacons;
    int currentBeacons;
    int beaconsRest;

    private void Awake()
    {
        hp = GetComponent<HealthPlayer>();
        beacons = GetComponent<WaveSpawner>();
    }
    private void Start()
    {
        posCheckPoint = transform.position;
        posTpVoid = transform.position;
    }
    public void TeleportToTPVoid(int damage)
    {
        //EXPLICACION
        //Se llama desde Void.cs, cuando caes al vacio recibes 1 de daño
        //y te teletransportas a la posicion guardada al pasar por el checkpoint.

        hp.Damage(damage);
        transform.position = posTpVoid;
    }
    public void TeleportToCheckpoint()
    {
        transform.position = posCheckPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TP"))
        {
            //EXPLICACION
            //Cuando el player pasa por un checkpoint invisible justo
            //antes de un hoyo, se guarda la posicion en la variable pos.

            posTpVoid = collision.transform.position;
        }
        else if (collision.CompareTag("Checkpoint"))
        {
            if(beacons.GetNBeacons() < 1)
            {
                currentBeacons = beacons.GetNBeacons();
                beaconsRest = 1 - currentBeacons;
                beacons.SetNBeacons(beaconsRest);
                HUDManager.singletone.UpdateBeacon(beacons.GetNBeacons());
            }
            collision.GetComponent<Animator>().SetTrigger("Passed");
            posCheckPoint = collision.transform.position;
        }
    }
}
