using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BehaivourPushWave : BehaivourWave
{
    Rigidbody2D rb2d;
    [SerializeField] float forcePush;
    private float counter = 0;
    AudioSource audioSource;
    bool hit;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        hit = false;
    }
    private void Update()
    {
        hit = false;
    }
    protected override void ActionOnWave(Collider2D col)
    {
        if (col.CompareTag("PushWave"))
        {
            rb2d.isKinematic = false;
            Vector2 dir = transform.position - col.transform.position;
            rb2d.AddForceAtPosition(dir.normalized * forcePush, transform.position,ForceMode2D.Impulse);
            hit = true;
            audioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (!hit)
            {
                rb2d.velocity = Vector2.zero;
                rb2d.isKinematic = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            rb2d.isKinematic = false;
        }
    }

}
