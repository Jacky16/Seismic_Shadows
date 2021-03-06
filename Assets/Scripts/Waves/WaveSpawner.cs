using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    
    [SerializeField] Transform spawnPos;
    PlayerMovement player;
     //Settings Waves

    [Header("Generic Wave")]
    [SerializeField] GameObject genericWave;
    [SerializeField] float timeGenericWave;
    bool canSpawnGW;
    float countGW = float.MaxValue;

    [Header("Onda Lenta")]
    [SerializeField] GameObject slowWave;
    [SerializeField] float timeSlowWave;
    bool canSpawnSW;
    float countSW = float.MaxValue;

    [Header("Onda Rapida")]
    [SerializeField] GameObject quickWave;
    [SerializeField] float timeQuickWave;
    bool canSpawnQW;
    float countQW = float.MaxValue;

    [Header("Onda Interactiva")]
    [SerializeField] GameObject interactiveWave;
    [SerializeField] float timeInteractiveWave;
    bool canSpawnIW;
    float countIW = float.MaxValue;
    [Header("Onda de Empuje")]
    [SerializeField] GameObject pushWave;
    [SerializeField] float timePushWave;
    bool canSpawnPW;
    float countPW = float.MaxValue;

    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        WavesManager();
    }

    private void WavesManager()
    {
        //General wave
        if (player.IsMoving() && !player.TouchingFront())
        {
            countGW += Time.deltaTime;
            if (countGW >= timeGenericWave)
            {
                InstantiateWave(genericWave);
                canSpawnGW = false;
                countGW = 0;
            }
        }
        else
        {
            countGW = float.MaxValue;
        }

        //Slow wave
        if (countSW >= timeSlowWave && canSpawnSW)
        {
            InstantiateWave(slowWave);
            countSW = 0;
        }
        else
        {
            countSW += Time.deltaTime;
        }

        //Quick wave
        if (countQW >= timeQuickWave && canSpawnQW)
        {
            InstantiateWave(quickWave);
            countQW = 0;
        }
        else
        {
            countQW += Time.deltaTime;
        }

        //Interactive Wave
        if (countIW >= timeQuickWave && canSpawnIW)
        {
            InstantiateWave(interactiveWave);
            countIW = 0;
        }
        else
        {
            countIW += Time.deltaTime;
        }

        //Push Wave
        if (countPW >= timePushWave && canSpawnPW)
        {
            InstantiateWave(pushWave);
            countPW = 0;
        }
        else
        {
            countPW += Time.deltaTime;
        }
    }

    public void SetWaveToInstantiate(int _selectWave,bool _can)
    {
        switch (_selectWave)
        {
            case 0:
                canSpawnGW = _can;
                break;
            case 1:
                canSpawnSW = _can;
                break;
            case 2:
                canSpawnQW = _can;
                break;
            case 3:
                canSpawnIW = _can;
                break;
            case 4:
                canSpawnPW = _can;
                break;
            default:
                Debug.LogError("Error Select Wave");
                break;

        }
    }
    void InstantiateWave(GameObject _waveGO)
    {
        GameObject go = Instantiate(_waveGO);
        go.transform.position = spawnPos.position;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(spawnPos.position, 5);

    }
}
