using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] float speed;
    Rigidbody2D backrb2d;
    Transform ppos;
    InputManager input;
    PlayerMovement pmov;
    
    // Start is called before the first frame update
    void Start()
    {
        pmov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        input = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        backrb2d = gameObject.GetComponent<Rigidbody2D>();
        ppos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, ppos.position.y, this.gameObject.transform.position.z);

        if(input.GetAxis().x == 1 && !pmov.GetWallPos())
        {
            backrb2d.velocity = new Vector3(-speed, 0, 0);
        }
        if (input.GetAxis().x == -1 && !pmov.GetWallPos())
        {
            backrb2d.velocity = new Vector3(speed, 0, 0);
        }
        if (input.GetAxis().x == 0 || pmov.GetWallPos())
        {
            backrb2d.velocity = new Vector3(0, 0, 0);
        }
    }
}
