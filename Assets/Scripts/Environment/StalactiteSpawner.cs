using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteSpawner : MonoBehaviour
{
    [SerializeField] float timeToSpawn;
    [SerializeField] GameObject stalactitePrefab;

    public void InstantiateStalactite(Vector2 _pos)
    {
        StartCoroutine(DelaySpawn(_pos));
    }
    IEnumerator DelaySpawn(Vector2 _pos)
    {
        yield return new WaitForSeconds(timeToSpawn);
        Instantiate(stalactitePrefab, _pos, Quaternion.identity, null);

    }
}
