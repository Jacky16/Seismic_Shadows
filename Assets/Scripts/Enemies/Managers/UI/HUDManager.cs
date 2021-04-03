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

    public void UpdateLife(float _life,float _maxLife)
    {
        textLife.text = _life.ToString() + "/" + _maxLife.ToString();
        circleImageLife.DOFillAmount(_life / _maxLife, .5f);
    }
    public void UpdateEnergyBar(float _energy)
    {
        energyBar.DOFillAmount(_energy / 100, 0.5f);
        if(energyBar.fillAmount >= 1)
        {
            energyBar.fillAmount = 0;
            UpdateFlashWave(flashes.Length+1, 3);
        }
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
