using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Setting Player")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [Header("Wall Settings")]
    [SerializeField] Vector2 wallForce;
    [SerializeField] float wallJumpTime;
    [SerializeField] float wallSlidingSpeed;
    float jumpTime;
    bool isFacingRight;

    [Header("Checks")]
    [SerializeField] float checkRadius;
    [SerializeField] Transform feetCheckPos;
    [SerializeField] Transform frontCheckPos;
    [SerializeField] LayerMask layerMaskGround;
    bool isGrounded;
    bool isTouchingFront;
    bool wallSliding;
    bool wallJumping;

    //Componentes
    Rigidbody2D rb2d;
    //Vectores
    Vector2 axis;
    Vector2 movement;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckFlip();
    }

    private void FixedUpdate()
    {
        Movement();
        
        isGrounded = Physics2D.OverlapCircle(feetCheckPos.position, checkRadius,layerMaskGround);
        isTouchingFront= Physics2D.OverlapCircle(frontCheckPos.position, checkRadius, layerMaskGround);

        WallSlide();

        if (wallJumping)
        {
            rb2d.velocity = new Vector2(wallForce.x * -axis.x, wallForce.y);
        }
    }
    
    private void Movement()
    {
        movement = new Vector2(axis.x * speed * 100, rb2d.velocity.y);
        rb2d.velocity = movement;
    }
    private void WallSlide()
    {
        if (isTouchingFront && !isGrounded && axis.x != 0)
        {
            wallSliding = true;
            jumpTime += Time.time + wallJumpTime;
        }else if(jumpTime <= Time.time)
        {
            wallSliding = false;
            jumpTime = 0;
        }else if (!isTouchingFront)
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }
    public void Jump()
    {
        if (isGrounded || wallSliding)
        {
             rb2d.velocity = (Vector2.up * jumpForce * 100);
        }
    }
    private void CheckFlip()
    {
        if (isFacingRight && axis.x > 0)
        {
            Flip();
        }
        else if (!isFacingRight && axis.x < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        isFacingRight =! isFacingRight;
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
    public void SetAxis(Vector2 _axis)
    {
        axis = _axis;
    }
    private void OnDrawGizmos()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(feetCheckPos.position,checkRadius);
        if (isTouchingFront)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(frontCheckPos.position, checkRadius);

    }
}
