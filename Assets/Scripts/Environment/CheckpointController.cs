using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    Animator anim;
    Transform saved;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //saved = ;
    }

    void SetPos(Collider2D _col)
    {
        saved.position = new Vector3 (_col.transform.position.x, gameObject.transform.position.y, 0);
    }

    public Transform GetPos()
    {
        return saved;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            anim.SetTrigger("Passed");
            SetPos(collision);
        }
    }
}
