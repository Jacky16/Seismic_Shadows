using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject wavePrefab;
    [SerializeField] Transform spawnPos;
    [SerializeField] float timeSpawn;
    float count = float.MaxValue;

    private void Awake()
    {
        
    }
    public void Spawn()
    {
        count += Time.deltaTime;
        if (count >= timeSpawn)
        {
            GameObject go = Instantiate(wavePrefab);
            go.transform.position = spawnPos.position;
            count = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(spawnPos.position, 5);

    }
}
