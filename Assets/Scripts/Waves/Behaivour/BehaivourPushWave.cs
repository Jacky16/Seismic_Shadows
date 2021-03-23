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
        rb2d.isKinematic = true;
    }
    private void Update()
    {
        if(rb2d.velocity == Vector2.zero)
        {
            rb2d.isKinematic = true;     
        }
    }
    protected override void ActionOnWave(Collider2D col)
    {
        if (col.CompareTag("PushWave"))
        {
            rb2d.isKinematic = false;
            Vector2 dir = transform.position - col.transform.position;
            rb2d.AddForce(dir.normalized * forcePush, ForceMode2D.Impulse);
        }
    }
}
