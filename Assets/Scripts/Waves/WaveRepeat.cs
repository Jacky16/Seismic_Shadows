using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRepeat : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<WaveAnimation>(out WaveAnimation wa))
        {
            GameObject go = Instantiate(collision.gameObject);
            go.transform.position = transform.position;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), go.GetComponent<Collider2D>());
        }
    }  
}
