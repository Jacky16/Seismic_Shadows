using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    
    [SerializeField] float speedx;
    Rigidbody2D rb2d;
    InputManager input;
    PlayerMovement pmov;
    float actualSpeedX;
    Transform cpos;
   

    // Start is called before the first frame update
    void Start()
    {
        cpos = GameObject.FindGameObjectWithTag("MainCamera").transform;
        rb2d = GetComponent<Rigidbody2D>();
        pmov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        input = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (input.GetAxis().x == 1 && !pmov.IsWallSliding())
        {
            actualSpeedX = -speedx;
        }
        if (input.GetAxis().x == -1 && !pmov.IsWallSliding())
        {
            actualSpeedX = speedx;
        }
        if (input.GetAxis().x == 0 || pmov.IsWallSliding())
        {
            actualSpeedX = 0;
        }
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(actualSpeedX, 0);
       //if(Camera.main != null)
        transform.position = new Vector3(transform.position.x, cpos.position.y, transform.position.z);
    }
}
