using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerManager : MonoBehaviour
{
    Vector3 pos;
    HealthPlayer hp;

    private void Awake()
    {
        hp = GetComponent<HealthPlayer>();
    }
    public void Teleport()
    {
        hp.Damage(1);
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
