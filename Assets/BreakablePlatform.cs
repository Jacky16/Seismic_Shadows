using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    GameObject player;
    private float count;
    [Header("Tiempo para romperse")]
    [SerializeField] int maxTime;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InteractiveWave")
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            count += Time.deltaTime;
            if (count >= maxTime)
            {
                this.gameObject.SetActive(false);
                count = 0;
            }
        }
    }
}
