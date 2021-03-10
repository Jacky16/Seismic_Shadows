using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BehaivourPushWave : BehaivourWave
{
    Rigidbody2D rb2d;
    [SerializeField] float forcePush;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    protected override void ActionOnWave(Collider2D col)
    {
        if (col.CompareTag("PushWave"))
        {
            Vector2 dir = transform.position - col.transform.position;
            rb2d.AddForce(dir.normalized * forcePush, ForceMode2D.Impulse);
        }
    }
}
