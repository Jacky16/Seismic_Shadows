using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BehaivourPushWave : BehaivourWave
{
    Rigidbody2D rb2d;
    [SerializeField] float forcePush;
    private float counter = 0;
    bool hit;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true;
    }
    private void Update()
    {
        if (hit)
        {
            counter += Time.deltaTime;
            if (counter >= 1 && rb2d.velocity.y == 0)
            {
                rb2d.isKinematic = true;
                hit = false;
                rb2d.velocity = Vector2.zero;
            }
        }
        
    }
    protected override void ActionOnWave(Collider2D col)
    {
        if (col.CompareTag("PushWave"))
        {
            rb2d.isKinematic = false;
            Vector2 dir = transform.position - col.transform.position;
            rb2d.AddForce(dir.normalized * forcePush, ForceMode2D.Impulse);
            counter = 0;
            hit = true;
        }
    }
}
