﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] float speed;
    [SerializeField] protected LayerMask layerMaskEnvironent;
    [SerializeField] protected float timeToStartFollow;
    [SerializeField] protected bool spawnFlipped = false;
    protected float countStartFollow = 0;
    protected Vector2 dir;
    protected Transform target;
    protected bool facingRight;
    protected Vector3 initPos;
    protected bool canMove = true;
   
    [Header("Attack Settings")]
    [SerializeField] protected float radius;
    [SerializeField] protected float stopDistance;
    [SerializeField] protected int damage;
    [SerializeField] protected float timeToAttack;
    protected float countAttack = float.MaxValue;

    [Header("Hit box Attack")]
    [SerializeField] protected Vector2 sizeHitBoxAttack;
    [SerializeField] protected Transform hitAttackPos;

    [Header("WayPoint Settings")]
    [SerializeField] protected bool followPath;
    [SerializeField] protected Transform[] wayPoints;
    [SerializeField] protected float timeInWayPoint;
    protected float countWaypoint = 0;
    protected int sizeWayPoints;
    protected int nextPoint = 0;
    protected float countWaypoints = 0;

    //Checkers
    protected bool targetInRadius;
    protected bool targetInStopDistance;
    protected bool targetInRaycast;
    protected float distanceToTarget;

    [Header("Other components")]
    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected HealthEnemies healthEnemie;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        healthEnemie = GetComponent<HealthEnemies>();
    }
    private void Start()
    {
        if (wayPoints.Length == 0) followPath = false;
        initPos = transform.position;
        if(spawnFlipped)
        Flip();
    }
    private void Update()
    {
        Checkers();

        //Para el juego final esto fuera
        if (targetInRadius && Input.GetKeyDown(KeyCode.Backspace))
        {
            healthEnemie.Damage(999);
        }
    }

    private void FixedUpdate()
    {
        if (!healthEnemie.IsDead())
        {
            if (targetInRadius)
            {
                CheckPlayerInRaycast();
            }
            else
            {
                targetInRaycast = false;
            }

            StatesEnemy();

            Path();

            anim.SetFloat("SpeedX", Mathf.Abs(rb2d.velocity.normalized.x));

        }
        else
        {
            dir.x = 0;
        }
        if (canMove)
            rb2d.velocity = new Vector2(dir.normalized.x * speed, rb2d.velocity.y);
    }

    protected void FlipManager(float velocityX)
    {
        if (velocityX < 0 && !facingRight)
        {
            Flip();
        }
        else if (velocityX > 0 && facingRight)
        {
            Flip();
        }
    }

    protected void CheckPlayerInRaycast()
    {        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position - transform.position,radius, layerMaskEnvironent);
        
        Debug.DrawRay(transform.position, target.position - transform.position);

        if(hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                targetInRaycast = true;
            }
            else
            {
                targetInRaycast =  false;
            }
        }
    }
    protected virtual void Path() {;}
    protected virtual void StatesEnemy()
    {
       
    }
    private void Checkers()
    {
        targetInRadius = Vector2.Distance(transform.position, target.position) < radius;
        targetInStopDistance = Vector2.Distance(transform.position, target.position) < stopDistance;
    }
    protected void NextWayPoint()
    {
        nextPoint++;
        if(nextPoint >= wayPoints.Length)
        {
            nextPoint = 0;
        }
       
    }
    public int Damage()
    {
        return damage;
    }
    protected virtual void OnCollEnter(Collision2D col) {;}
    protected virtual void OnTrigEnter(Collider2D col) {;}
    protected virtual void OnTrigStay(Collider2D col) {;}
    protected virtual void OnCollStay(Collision2D col) {; }
    protected virtual void Attack() {;}
    protected void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {     
        OnTrigStay(collision); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigEnter(collision);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollEnter(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        OnCollStay(collision);
    }
    private void OnDrawGizmos()
    {
        if (targetInRadius && targetInRaycast)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, stopDistance);

        Gizmos.color = Color.blue;
        if(hitAttackPos!= null)
        Gizmos.DrawWireCube(hitAttackPos.position, sizeHitBoxAttack);

    }
}
