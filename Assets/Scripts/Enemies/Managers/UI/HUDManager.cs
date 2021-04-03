using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class HUDManager : MonoBehaviour
{
    [Header("Health UI")]
    [SerializeField]Image circleImageLife;
    [SerializeField] TextMeshProUGUI textLife;
    [Header("Flash UI")]
    [SerializeField] GameObject[] flashes;
    [SerializeField] Image energyBar;
    [Header("Beacon UI")]
    [SerializeField] TextMeshProUGUI textBeacon;
    public static HUDManager singletone;
    WaveSpawner waveSpawner;

    private void Awake()
    {
        if(singletone == null)
        {
            singletone = this;
        }
        waveSpawner = GameObject.FindGameObjectWithTag("Player").GetComponent<WaveSpawner>();
    }

    public void UpdateLife(float _life,float _maxLife)
    {
        textLife.text = _life.ToString() + "/" + _maxLife.ToString();
        circleImageLife.DOFillAmount(_life / _maxLife, .5f);
    }
    public void UpdateEnergyBar(float _energy)
    {  
        energyBar.DOFillAmount(waveSpawner.GetEnergy()/ 100, 1f);   
    }
    public void UpdateFlashWave(int _size,int _maxSize)
    {
        for(int i = 0; i < _maxSize; i++)
        {
            if(i < _size)
            {
                flashes[i].SetActive(true);
            }
            else
            {
                flashes[i].SetActive(false);
            }
        }
    }

    public void UpdateBeacon(int _nbeacons)
    {
        textBeacon.text = "x" + _nbeacons.ToString();
    }

}
