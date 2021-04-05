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
            int sizeFlashWave = GameManager.singletone.GetFlashWaveCount();
            int maxSizeFlashWave = GameManager.singletone.GetMaxFlashesWaves();
            if(sizeFlashWave < maxSizeFlashWave)
            {
                GameManager.singletone.AddEnergyBar(valor);
                Destroy(gameObject);
            }
        }
    }
}
