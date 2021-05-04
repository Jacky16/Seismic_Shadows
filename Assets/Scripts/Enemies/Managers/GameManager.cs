using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singletone;
    [Header("Flash Wave Settings")]
    [SerializeField] float energyBar = 0;
    [SerializeField] float speedSpendingEnergy;
    [SerializeField] float speedChargeEnergy;
    [SerializeField] float timeToCharge;
    float count = 0;
    bool isSpendingEnergy;


    float lifePlayerSaved = 3;
    float maxLifePlayerSaved = 3;
    private void Awake()
    {

        //True: Se desactiva en todas las escenas excepto en la 1r
        //False: Se activa en todas las escenas
        EnableOnFirstScene(true);

        if (singletone == null)
        {
            singletone = this;
            DontDestroyOnLoad(this);
        }
    }
    private void Update()
    {
        SpendingEneryManger();
    }

    private void SpendingEneryManger()
    {
        if (isSpendingEnergy && energyBar > 0)
        {
            energyBar -= speedSpendingEnergy * Time.deltaTime;
            if (energyBar <= 0)
            {
                energyBar = 0;
                HUDManager.singletone.SetFlashWaveIcon(0);
                isSpendingEnergy = false;
            }
            count = 0;
        }
        //Cargar la energia
        else
        {
            count += Time.deltaTime;
            if(count >= timeToCharge)
            {
                HUDManager.singletone.SetFlashWaveIcon(1);
                energyBar += speedChargeEnergy * Time.deltaTime;
                if (energyBar >= 100)
                {
                    energyBar = 100;

                }
            }
        }
        HUDManager.singletone.SetEnergyBar(energyBar);

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
 
   public void SetSpending()
    {
        isSpendingEnergy = !isSpendingEnergy;
    }
    public void SetEnergy(float _f)
    {
        energyBar = _f;
        //Actualizar la UI de la barra
        HUDManager.singletone.UpdateEnergyBar(energyBar);

        //Poner a color el icono de la FlashWave
        HUDManager.singletone.SetFlashWaveIcon(1);
    }
    public void AddEnergyBar(float _f)
    {
        energyBar += _f;
        if(energyBar >= 100)
        {
            energyBar = 100;
        }
        //Actualizar la UI de la barra
        HUDManager.singletone.UpdateEnergyBar(energyBar);
    }

    public bool IsSpeendingEnergy()
    {
        return isSpendingEnergy;
    }

    #region Getters
        public float GetLifePlayer()
        {
            return lifePlayerSaved;
        }
        public float GetMaxLifePlayer()
        {
            return maxLifePlayerSaved;
        }
        public float GetEnergy()
        {
            return energyBar;
        }
    #endregion
}
