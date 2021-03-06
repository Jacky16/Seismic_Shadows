using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Setting Player")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpWallForce;
    [SerializeField] float forceXJumping;
    [Header("Wall Settings")]
    [SerializeField] float wallSlideTime;
    [SerializeField] float wallSlidingSpeed;
    bool isFacingRight;

    [Header("Checks")]
    [SerializeField] float checkRadius;
    [SerializeField] Transform feetCheckPos;
    [SerializeField] Transform frontCheckPos;
    [SerializeField] LayerMask layerMaskGround;
    bool isGrounded;
    bool isTouchingFront;
    bool wallSliding;
    bool isJumpSliding;
    float counterJumpWall = 0;

    //Componentes
    Rigidbody2D rb2d;
    WaveSpawner waveSpawner;
    //Vectores
    Vector2 axis;
    Vector2 movement;
    Vector2 posBeforeJumping;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        waveSpawner = GetComponent<WaveSpawner>();
    }

    private void Update()
    {
        CheckFlip();

        // Contador para el wallJump
        if (isJumpSliding)
        {
            counterJumpWall += Time.deltaTime;
            if (counterJumpWall >= 1)
            {
                isJumpSliding = false;
                counterJumpWall = 0;
            }       
        }
       
    }

    private void FixedUpdate()
    {
        Movement();
        
        isGrounded = Physics2D.OverlapCircle(feetCheckPos.position, checkRadius,layerMaskGround);
        isTouchingFront= Physics2D.OverlapCircle(frontCheckPos.position, checkRadius, layerMaskGround);
        if (axis.x != 0 && !isTouchingFront)
        {
            waveSpawner.SetWaveToInstantiate(0,true);
        }
        WallSlide();
    }

    private void Movement()
    {
        movement = new Vector2(axis.x * speed * 100, rb2d.velocity.y);
        
        //Si esta saltando entre columnas, se aplican fuerzas opuestas
        if (isJumpSliding && !isGrounded) {
            Vector2 force;
            
            if(transform.position.x > posBeforeJumping.x) //Derecha
            {
                force = Vector2.left * forceXJumping * 100;
            }
            else //Izquierda
            {
                force = Vector2.right * forceXJumping * 100;
            }
            rb2d.velocity = movement + force;
        }
        else
        {
            rb2d.velocity = movement;
        }
    }
    private void WallSlide()
    {
        if (isTouchingFront && !isGrounded && axis != Vector2.zero)
        {
            wallSliding = true;
            isJumpSliding = false;
            counterJumpWall = 0;
        }
        else 
        {    
            Invoke("SetWallSlidingFalse", wallSlideTime);
        }
        
        if (wallSliding)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }
    void SetWallSlidingFalse()
    {
        wallSliding = false;
    }
    public void Jump()
    {
        if (isGrounded)
        {
             rb2d.velocity = (Vector2.up * jumpForce * 100);
        }
        if (wallSliding)
        {
            rb2d.velocity = (Vector2.up * jumpWallForce * 100);
            posBeforeJumping = transform.position;
            isJumpSliding = true;
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
    public bool TouchingFront()
    {
        return isTouchingFront;
    }
    public bool IsMoving()
    {
        return axis.x != 0;
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
