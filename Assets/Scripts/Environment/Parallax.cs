using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] float speedx;
    Rigidbody2D backrb2d;
    [SerializeField] Transform cpos;
    InputManager input;
    PlayerMovement pmov;
    float actualSpeedX;

    
    // Start is called before the first frame update
    void Start()
    {
        pmov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        input = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        backrb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetAxis().x == 1 && !pmov.GetWallPos())
        {
            actualSpeedX = -speedx;
        }
        if (input.GetAxis().x == -1 && !pmov.GetWallPos())
        {
            actualSpeedX = speedx;
        }
        if (input.GetAxis().x == 0 || pmov.GetWallPos())
        {
            actualSpeedX = 0;
        }
    }
    private void FixedUpdate()
    {
        backrb2d.velocity = new Vector2(actualSpeedX, 0);
        backrb2d.transform.position = new Vector3(backrb2d.transform.position.x, cpos.position.y, backrb2d.transform.position.z);
    }
}
