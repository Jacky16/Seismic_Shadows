using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    [Header("Point Wave")]
    [SerializeField] GameObject enemyWave;
    [SerializeField] float timeEnWave;
    [SerializeField] Transform spawnWave;
    Enemy enemy;
    bool canSpawnEnWave;
    float countEnW = float.MaxValue;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        if (enemy.IsMoving())
        {
            countEnW += Time.deltaTime;
            if(countEnW >= timeEnWave)
            {
                GameObject go = Instantiate(enemyWave);
                go.transform.position = spawnWave.position;
                countEnW = 0;
            }
            
        }
        else
        {
            countEnW = float.MaxValue;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(spawnWave.position, 5);

    }
}
