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

    private void Awake()
    {
        if(singletone == null)
        {
            singletone = this;
        }
    }
    private void Start()
    {
        InitHUD();
    }

    public void UpdateLife(float _life,float _maxLife)
    {
        textLife.text = _life.ToString() + "/" + _maxLife.ToString();
        circleImageLife.DOFillAmount(_life / _maxLife, .5f);
    }
    public void UpdateEnergyBar(float _energy)
    {
        float currentEnergy = GameManager.singletone.GetEnergy();
        energyBar.DOFillAmount(currentEnergy / 100, 1f);   
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

    void InitHUD()
    {
        int sizeNbeacons = GameManager.singletone.GetNBeacons();
        float sizeEnergyBar = GameManager.singletone.GetEnergy();
        int sizeFlashWave = GameManager.singletone.GetFlashWaveCount();
        int maxFlashwaves = GameManager.singletone.GetMaxFlashesWaves();
        float lifePlayer = GameManager.singletone.GetLifePlayer();
        float maxLifePlayer = GameManager.singletone.GetMazLifePlayer();
        UpdateBeacon(sizeNbeacons);
        UpdateEnergyBar(sizeEnergyBar);
        UpdateFlashWave(sizeFlashWave, maxFlashwaves);
        UpdateLife(lifePlayer, maxLifePlayer);
    }

}
