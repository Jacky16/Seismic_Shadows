using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    [SerializeField] GameObject cc;
    Rigidbody2D prb2d;
    Rigidbody2D backrb2d;
    Transform cpos;
    
    // Start is called before the first frame update
    void Start()
    {
        cpos = cc.GetComponent<Transform>();
        prb2d = player.GetComponent<Rigidbody2D>();
        backrb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, cpos.position.y, gameObject.transform.position.z);

        if (prb2d.velocity.x > 0)
        {
            backrb2d.velocity = new Vector3(-speed, 0,0);
        }
        else if (prb2d.velocity.x < 0)
        {
            backrb2d.velocity = new Vector3(speed, 0, 0);
        }

        if (prb2d.velocity.x == 0)
        {
            backrb2d.velocity = Vector3.zero;
        }
    }
}
