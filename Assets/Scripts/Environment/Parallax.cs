using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Rigidbody2D player;
    [SerializeField] float speed;
    Rigidbody2D prb2d;
    Rigidbody2D backrb2d;
    Transform ppos;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        backrb2d = gameObject.GetComponent<Rigidbody2D>();
        ppos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, ppos.position.y, gameObject.transform.position.z);

        if (player.velocity.x > 0)
        {
            backrb2d.velocity = new Vector3(-speed, 0,0);
        }
        else if (player.velocity.x < 0)
        {
            backrb2d.velocity = new Vector3(speed, 0, 0);
        }

        if (player.velocity.x == 0)
        {
            backrb2d.velocity = Vector3.zero;
        }
    }
}
