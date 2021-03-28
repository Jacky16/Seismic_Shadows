﻿using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    [Header("Settings Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float airMoveSpeed = 10f;
    [SerializeField] float stealthSpeed;
    Vector2 axis;
    Vector2 movementPlayer;
    bool facingRight = true;
    bool isMoving;
    bool isStealthMode;
    bool canMove = true;

    [Header("Settings Jumping")]
    [SerializeField] float jumpForce = 16f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Vector2 groundCheckSize;
    [SerializeField] float wallCheckDistance;
    bool grounded;
    bool canJump;

    [Header("Settings WallSliding")]
    [SerializeField] float wallSlideSpeed;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] Vector2 wallCheckSize;
    bool isTouchingWall;
    bool isWallSliding;

    [Header("Settings WallJumping")]
    [SerializeField] float walljumpforce;
    [SerializeField] Vector2 walljumpAngle;
    float walljumpDirection = -1;

    //Other components
    Rigidbody2D rb2d;
    WaveSpawner waveSpawner;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        waveSpawner = GetComponent<WaveSpawner>();
    }
    private void Start()
    {
        walljumpAngle.Normalize();
    }
    private void Update()
    {
        CheckWorld();

    }
    private void FixedUpdate()
    {
        Movement();
        WallSlide();
    }

    #region Movements
    void Movement()
    {
        //Comprobar si esta moviendo
        if (axis.x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        movementPlayer = new Vector2(axis.x * moveSpeed, rb2d.velocity.y);
        //Si se puede mover aplicas la velocidad al player
        if (canMove)
        {
            rb2d.velocity = movementPlayer;
        }

        //Voltearse izquierda o derecha
        if (axis.x < 0 && facingRight)
        {
            Flip();
        }
        else if (axis.x > 0 && !facingRight)
        {
            Flip();
        }
    }
    void WallSlide()
    {
        if (isTouchingWall && !grounded && rb2d.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
        //Si te estas deslizando por el muro,aplicas la fuerza de deslize
        if (isWallSliding)
        {
            if (rb2d.velocity.y < -wallSlideSpeed)
                rb2d.velocity = new Vector2(rb2d.velocity.x, -wallSlideSpeed);
        }
    }
    public void Jump()
    {
        //Normal Jump
        if (grounded && !isWallSliding)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            print("Jump");
        }
        //WallJump
        
        if (isWallSliding)
        {
            print("WallJump");
            rb2d.velocity = Vector2.zero;
            Vector2 moveTo = new Vector2(walljumpforce * walljumpAngle.x * walljumpDirection , walljumpforce * walljumpAngle.y);
            rb2d.velocity = moveTo;
            Debug.Log(rb2d.velocity);
            StartCoroutine(StopMovement());
        }

    }
    #endregion
    void CheckWorld()
    {
        grounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);
        isTouchingWall = Physics2D.Raycast(transform.position, transform.right, wallCheckDistance, groundLayer);
    }
    void Flip()
    {
        if (!isWallSliding)
        {
            walljumpDirection *= -1;
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);
        }

    }

    IEnumerator StopMovement()
    {
        canMove = false;

        if (transform.localScale.x == 1)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = Vector2.one;
        }

        yield return new WaitForSeconds(.3f);

        transform.localScale = Vector2.one;
        canMove = true;
    }
    IEnumerator WaveGround()
    {
        yield return new WaitForSeconds(0.01f);
        if (grounded)
        {
            waveSpawner.DoGroundWave();
        }
    }

    #region Setters
    public void SetAxis(Vector2 _axis)
    {
        axis = _axis;
    }
    public void SetStealth(bool _b)
    {
        isStealthMode = _b;
    }
    #endregion

    #region Getters
    public bool IsMoving()
    {
        return isMoving;
    }
    public bool IsStealth()
    {
        return isStealthMode;
    }
    public bool TouchingFront()
    {
        return isTouchingWall;
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(WaveGround());
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);
        Gizmos.color = Color.green;
        //Gizmos.DrawCube(wallCheckPoint.position, wallCheckSize);

        if (facingRight)
        {
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance, transform.position.y, 0));
        }
        else
        {
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - wallCheckDistance, transform.position.y, 0));
        }

    }
}
