using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autinite : MonoBehaviour
{
    [SerializeField] int valor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HUDManager.singletone.UpdateEnergyBar(valor);
            Destroy(gameObject);
        }
    }
}
