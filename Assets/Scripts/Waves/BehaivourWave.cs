using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaivourWave : MonoBehaviour
{
    enum Wavetype { INTERACTIVE, PUSH, NONE };
    [SerializeField] Wavetype wavetype = Wavetype.NONE;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractiveWave"))
        {

            //Aqui entra cuando colisiona con un onda interactiva

        }
    }
}
