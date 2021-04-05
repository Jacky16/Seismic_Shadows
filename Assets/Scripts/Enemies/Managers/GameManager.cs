using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singletone;
    [Header("Flash Wave Settings")]
    [SerializeField] int sizeFlashWave = 3;
    [SerializeField] int maxSizeFlashWave = 3;
    [SerializeField] float energyBar = 0;

    [Header("Beacon Wave Settings")]
    [SerializeField] int nBeacons = 0;

    
    float lifePlayerSaved = 3;
    float maxLifePlayerSaved = 3;
    private void Awake()
    {
        //Se desactiva el GameManager en todas las escenas excepto en la 1r si esta true
        EnableOnFirstScene(true);

        if(singletone == null)
        {
            singletone = this;
            DontDestroyOnLoad(this);
        }

    }
    
    void EnableOnFirstScene(bool _b)
    {
        //Se desactiva el GameManager en todas las escenas excepto en la 1r si esta true
        if (_b)
        {
            int indexFirstScene = SceneManager.GetActiveScene().buildIndex;
            if (indexFirstScene != 4)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    public void UpdateHUDLife()
    {
        HUDManager.singletone.UpdateLife(lifePlayerSaved, maxLifePlayerSaved);
    }
    public void SetLifePlayerHUD(float _life,float _maxLife)
    {
        lifePlayerSaved = _life;
        maxLifePlayerSaved = _maxLife;
        HUDManager.singletone.UpdateLife(lifePlayerSaved, maxLifePlayerSaved);

    }
 
   
    public void AddEnergyBar(float _f)
    {
        float sum = energyBar + _f;
        if (sum >= 100)
        {
            energyBar = 0;
            sizeFlashWave++;
            HUDManager.singletone.UpdateFlashWave(sizeFlashWave, maxSizeFlashWave);
        }
        else
        {
            energyBar = sum;
        }
        HUDManager.singletone.UpdateEnergyBar(energyBar);
    }
    public void UseFlashWave()
    {
        sizeFlashWave--;
        if(sizeFlashWave <= 0)
        {
            sizeFlashWave = 0;
        }
        HUDManager.singletone.UpdateFlashWave(sizeFlashWave, maxSizeFlashWave);
    }
    public void AddNBeacons(int _nBeacons)
    {
        nBeacons += _nBeacons;
        HUDManager.singletone.UpdateBeacon(nBeacons);
    }
    public void SetNBeacons(int _nBeacons)
    {
        nBeacons = _nBeacons;
        HUDManager.singletone.UpdateBeacon(nBeacons);
    }
    public float GetLifePlayer()
    {
        return lifePlayerSaved;
    }
    public float GetMazLifePlayer()
    {
        return maxLifePlayerSaved;
    }
    public int GetNBeacons()
    {
        return nBeacons;
    }
    public int GetFlashWaveCount()
    {
        return sizeFlashWave;
    }
    public int GetMaxFlashesWaves()
    {
        return maxSizeFlashWave;
    }
    public float GetEnergy()
    {
        return energyBar;
    }
}
