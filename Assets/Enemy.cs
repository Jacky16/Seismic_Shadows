using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("General Settings")]

    [SerializeField] protected float radius;
    [SerializeField] protected float stopDistance;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    protected float currentSpeed;
    protected bool targetInRange;
    protected bool targetInStopDistance;
    protected bool isInitPos;
    protected Transform target;
    protected Vector2 initPosition;

    [Header("WayPoint Settings")]
    [SerializeField] protected bool followPath;
    [SerializeField] protected float timeBetweenWaypoints;
    [SerializeField] protected Transform[] wayPoints;
    protected int sizeWayPoints;
    protected int nextPoint = 0;
    protected float distanceToTarget;


    //enum EnemyStates { IDLE,CHASE,FOLLOW_PATH,ATTACK,DEAD};
    //EnemyStates enemyStates;

    //Componentes
    Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    protected void Start()
    {
        sizeWayPoints = wayPoints.Length;
        currentSpeed = speed;
        initPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, target.position);
        
        //Si el player esta en el rango
        targetInRange = radius >= distanceToTarget;

        //Si el player esta en la stopDistance
        targetInStopDistance = stopDistance >= distanceToTarget;

        //Si el Enemigo esta en su posicion inicial
        isInitPos = Vector2.Distance(transform.position, initPosition) <= 0;
    }
    protected void FixedUpdate()
    {
        Vector2 dirEnemy = Vector2.zero;

        //Perseguir al player
        if (targetInRange && !targetInStopDistance)
        {         
             dirEnemy = target.position - transform.position;
        }
        //Enemigo al lado del player
        else if(targetInRange && targetInStopDistance)
        {
            dirEnemy = Vector2.zero;
        }
        //Volver a la posicion inicial si no sigue la ruta
        else
        {
            if (!followPath)
            {
                dirEnemy = (Vector3)initPosition - transform.position;
            }
        }

        rb2d.velocity = new Vector2(dirEnemy.normalized.x * currentSpeed * 100, rb2d.velocity.y);
        
        //Seguir el Path si no esta el player en el rango
        if (followPath && !targetInRange)
        {
            Transform currentWaypoint = wayPoints[nextPoint];

            float distanteToNextWaypoint = Vector2.Distance(transform.position ,currentWaypoint.position);

            Vector2 dirWayPoint = currentWaypoint.position - transform.position;

            rb2d.velocity = (dirWayPoint.normalized * currentSpeed * 100);
     
            if (distanteToNextWaypoint  <= 20)
            {
                //Pasar al siguiente Waypoint
                StartCoroutine(NextWaypoint(timeBetweenWaypoints));                   
            }                       
        }
    }

    IEnumerator NextWaypoint(float time)
    {
        currentSpeed = 0;
        nextPoint++;
        if (nextPoint >= sizeWayPoints)
        {
            nextPoint = 0;
        }
        yield return new WaitForSecondsRealtime(time);
        currentSpeed = speed;
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
