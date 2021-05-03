using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] float timeToActive;
    AudioSource audioSource;
    Vector3 initialPos;
    bool isBroken;
    float count;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        count = 0;
        initialPos = transform.position;
        isBroken = false;
    }

    private void Update()
    {
        if (isBroken)
        {
            count += Time.deltaTime;
            if (count >= timeToActive)
            {
                transform.position = initialPos;
                EnableComponents();
                isBroken = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Stalagmite")
        {
            DisableComponents();
            isBroken = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lava")
        {
            DisableComponents();
            isBroken = true;
        }
        if (collision.tag == "Void")
        {
            DisableComponents();
            isBroken = true;
        }
    }

    void DisableComponents()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void EnableComponents()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
