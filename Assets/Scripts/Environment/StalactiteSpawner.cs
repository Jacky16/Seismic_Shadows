using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteSpawner : MonoBehaviour
{
    [SerializeField] GameObject stalactitePrefab;

    public void InstantiateStalactite()
    {
        Instantiate(stalactitePrefab, transform.position, Quaternion.identity, null);
    }
}
