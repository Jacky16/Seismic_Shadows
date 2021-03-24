using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreakeableManager : MonoBehaviour
{
    [SerializeField]GameObject platform;
    [SerializeField] int maxTime;
    [Header("Tiempo para romperse")]
    [SerializeField] int respawnTime;
    private float counPlayer = 0, countPlatform = 0;

    public void ActivePlattform()
    {
        StartCoroutine(AP());
    }
    public void DisablePlattform()
    {

    }
    public void WaveInteractive()
    {
        StartCoroutine(WI());
    }
    IEnumerator WI()
    {       
        platform.SetActive(false);
        yield return new WaitForSecondsRealtime(respawnTime);
        platform.SetActive(true);
    }
    IEnumerator AP()
    {
        yield return new WaitForSecondsRealtime(maxTime);
        platform.SetActive(false);
        yield return new WaitForSecondsRealtime(respawnTime);
        platform.SetActive(true);

    }
}
