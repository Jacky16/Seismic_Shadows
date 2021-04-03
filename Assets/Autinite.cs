using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autinite : MonoBehaviour
{
    [SerializeField] int valor;
    WaveSpawner waveSpawner;
    private void Awake()
    {
        waveSpawner = GameObject.FindGameObjectWithTag("Player").GetComponent<WaveSpawner>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            waveSpawner.AddEnergyBar(valor);
            Destroy(gameObject);
        }
    }
}
