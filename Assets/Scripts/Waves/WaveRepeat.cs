using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRepeat : MonoBehaviour
{
    //Settings Waves
    [Header("Step Wave")]
    [SerializeField] GameObject stepWavePrefab;

    [Header("Stealth Wave")]
    [SerializeField] GameObject stealthWavePrefab;

    [Header("Long Wave")]
    [SerializeField] GameObject longWavePrefab;

    [Header("Interactive Wave")]
    [SerializeField] GameObject interactiveWavePrefab;

    [Header("Push Wave")]
    [SerializeField] GameObject pushWavePrefab;
    bool canSpawnInteractive = true;
    float delay = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string waveName = collision.tag;
        Debug.Log(waveName);
        switch (waveName)
        {
            case "StepWave":
                InstantiateWave(stepWavePrefab);
                break;
            case "StealthWave":
                InstantiateWave(stealthWavePrefab);
                break;
            case "LongWave":
                InstantiateWave(longWavePrefab);
                break;
            case "InteractiveWave":
                if (canSpawnInteractive)
                {
                    InstantiateWave(interactiveWavePrefab);
                    Invoke("ActiveSpawnInteractive", delay);
                    canSpawnInteractive = false;
                }
                break;
            case "PushWave":
                InstantiateWave(pushWavePrefab);
                break;
            default:
                break;
        }
    }
    void ActiveSpawnInteractive()
    {
        canSpawnInteractive = true;
    }
    void InstantiateWave(GameObject g)
    {
        GameObject go = Instantiate(g, transform.position, transform.rotation);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), go.GetComponentInChildren<Collider2D>());
        Destroy(go, 2);
    }
}
