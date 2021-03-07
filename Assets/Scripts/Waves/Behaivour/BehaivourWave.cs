using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaivourWave : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {

    }

    protected virtual void ActionWave(Collider2D col) {; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ActionWave(collision);      
    }
}
