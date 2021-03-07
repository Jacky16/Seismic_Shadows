using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    TPlayerManager tpPlayer;
    private void Awake()
    {
        tpPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<TPlayerManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        tpPlayer.Teleport();
    }
}
