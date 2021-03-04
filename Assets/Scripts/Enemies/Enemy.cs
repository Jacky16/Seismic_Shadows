using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] protected float radius;
    [SerializeField] protected float speed;
    protected float currentSpeed;
    protected bool targetInRange;
    protected bool isInitPos;
    protected Transform target;
    protected Vector2 initPosition;
    protected Vector2 dirEnemy;

    [Header("Attack Settings")]
    [SerializeField] protected float timeToAttack;
    [SerializeField] protected int damage;
    [SerializeField] protected float stopDistance; 
    protected bool targetInStopDistance;
    float countAttack = float.MaxValue;

    [Header("WayPoint Settings")]
    [SerializeField] protected bool followPath;
    [SerializeField] protected float timeBetweenWaypoints;
    [SerializeField] protected Transform[] wayPoints;
    int sizeWayPoints;
    int nextPoint = 0;
    protected float distanceToTarget;
    float countWaypoints = 0;


    //Componentes
    protected Rigidbody2D rb2d;
    protected HealthPlayer healthPlayer;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        sizeWayPoints = wayPoints.Length;
        currentSpeed = speed;
        initPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        healthPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>();
    }

    void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, target.position);
        
        //Si el player esta en el rango
        targetInRange = radius >= distanceToTarget;

        //Si el player esta en la stopDistance
        targetInStopDistance = stopDistance >= distanceToTarget;

        //Si el Enemigo esta en su posicion inicial
        isInitPos = Vector2.Distance(transform.position, initPosition) <= 0;

        
    }
    void FixedUpdate()
    {
        //Vector2 dirEnemy = Vector2.zero;

        StatesEnemy();

        //Seguir el Path si no esta el player en el rango
        dirEnemy = Path(dirEnemy);

        Flip();

        rb2d.velocity = new Vector2(dirEnemy.normalized.x * currentSpeed * 100, rb2d.velocity.y);
    }

    private Vector2 Path(Vector2 dirEnemy)
    {
        if (followPath && !targetInRange)
        {
            Transform currentWaypoint = wayPoints[nextPoint];

            float distanteToNextWaypoint = Vector2.Distance(transform.position, currentWaypoint.position);

            dirEnemy = currentWaypoint.position - transform.position;

            rb2d.velocity = (dirEnemy.normalized * currentSpeed * 100);

            if (distanteToNextWaypoint <= 20)
            {
                //Pasar al siguiente Waypoint
                countWaypoints += Time.fixedDeltaTime;
                if (countWaypoints >= timeBetweenWaypoints)
                {
                    NextWaypoint();
                    countWaypoints = 0;
                }
            }
        }

        return dirEnemy;
    }

    public virtual void StatesEnemy()
    {
       
    }
    public virtual void OnCollEnter(Collision2D col) {;}
    public virtual void OnTrigEnter(Collider2D col) {;}
    public virtual void OnTrigStay(Collider2D col) {;}
    public virtual void Attack() {;}
    private void NextWaypoint()
    {
        currentSpeed = 0;
        nextPoint++;
        if (nextPoint >= sizeWayPoints)
        {
            nextPoint = 0;
        }
        currentSpeed = speed;
    }
    private void Flip()
    {
        if (rb2d.velocity.normalized.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }     
        else if(rb2d.velocity.normalized.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            countAttack += Time.fixedDeltaTime;
            if(countAttack >= timeToAttack)
            {
                Attack();
                countAttack = 0;
            }              
        }
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

private void OnDrawGizmos()
    {
        if (targetInRange)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, stopDistance);

    }
}
