using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Setting Player")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask layerMaskGround;
    [SerializeField] Transform feetPos;
    bool isGrounded;

    //Componentes
    Rigidbody2D rb2d;
    //Vectores
    Vector2 axis;
    Vector2 movement;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Movement();
        isGrounded = Physics2D.OverlapCircle(feetPos.position, 0.2f, layerMaskGround);
    }

    private void Movement()
    {
        movement = new Vector2(axis.x * speed * 100, rb2d.velocity.y);
        rb2d.velocity = movement;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb2d.velocity = (Vector2.up * jumpForce * 100);
        }
    }
    public void SetAxis(Vector2 _axis)
    {
        axis = _axis;
    }
}
