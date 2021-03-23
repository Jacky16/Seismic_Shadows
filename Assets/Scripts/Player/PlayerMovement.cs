using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    [Header("Settings Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float airMoveSpeed = 10f;
    [SerializeField] float stealthSpeed;
    Vector2 axis;
    bool facingRight = true;
    bool isMoving;
    bool isStealthMode;

    [Header("Settings Jumping")]
    [SerializeField] float jumpForce = 16f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Vector2 groundCheckSize;
    bool grounded;
    bool canJump;

    [Header("Settings WallSliding")]
    [SerializeField] float wallSlideSpeed;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] Vector2 wallCheckSize;
    bool isTouchingWall;
    bool isWallSliding;

    [Header("Settings WallJumping")]
    [SerializeField] float walljumpforce;
    [SerializeField] Vector2 walljumpAngle;
    float walljumpDirection = -1;
   
    //Other components
    Rigidbody2D rb;
    WaveSpawner waveSpawner;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        
        if (axis.x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

       
        if (grounded && !isStealthMode)
        {
            rb.velocity = new Vector2(axis.x * moveSpeed, rb.velocity.y);

        }else if(grounded && isStealthMode)
        {         
            rb.velocity = new Vector2(axis.x * stealthSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(airMoveSpeed * axis.x, rb.velocity.y);
        }


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
        if (isTouchingWall && !grounded && rb.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }
    }
    void WallJump()
    {
        if ((isWallSliding) && canJump)
        {
            rb.AddForce(new Vector2(walljumpforce * walljumpAngle.x * walljumpDirection, walljumpforce * walljumpAngle.y), ForceMode2D.Impulse);
            Flip();
            canJump = false;

        }
    }
    public void Jump()
    {
        canJump = true;

        if (canJump && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false;
        }
        WallJump();
    }
    #endregion
    void CheckWorld()
    {
        grounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);
        isTouchingWall = Physics2D.OverlapBox(wallCheckPoint.position, wallCheckSize, 0, wallLayer);
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
        Gizmos.DrawCube(wallCheckPoint.position, wallCheckSize);

    }
}
