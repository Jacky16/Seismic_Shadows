using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerManager : MonoBehaviour
{
    Vector3 pos;  
   public void Teleport()
    {
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TP"))
        {
            pos = collision.transform.position;
        }
    }
}
