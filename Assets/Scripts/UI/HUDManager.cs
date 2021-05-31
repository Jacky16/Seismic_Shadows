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

    [Header("FlashWave UI")]
    [SerializeField] Image flashImageBar;

    [Header("Wave icons")]
    [SerializeField] Image interactiveWaveIconImage;
    [SerializeField] Image pushWaveIconImage;
    [SerializeField] Image flashWaveIconImage;
    
    //Variables para el HUD de las ondas
    [Header("Sprites Controllers")]
    [SerializeField] Image image_FlashWave;
    [SerializeField] Image image_InteractiveWave;
    [SerializeField] Image image_PushWave;
    [Header("PC")]
    [SerializeField] Sprite spritePC_FlashWave;
    [SerializeField] Sprite spritePC_InteractiveWave;
    [SerializeField] Sprite spritePC_PushWave;

    [Header("Xbox")]
    [SerializeField] Sprite spriteXbox_FlashWave;
    [SerializeField] Sprite spriteXbox_InteractiveWave;
    [SerializeField] Sprite spriteXbox_PushWave;

    [Header("PS4")]
    [SerializeField] Sprite spritePS4_FlashWave;
    [SerializeField] Sprite spritePS4_InteractiveWave;
    [SerializeField] Sprite spritePS4_PushWave;

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
    #region Icons Waves
    public void UpdateControlsSprites(string controlScheme)
    {
        switch (controlScheme)
        {
            case "Keyboard&Mouse":
                image_InteractiveWave.sprite = spritePC_InteractiveWave;
                image_FlashWave.sprite = spritePC_FlashWave;
                image_PushWave.sprite = spritePC_PushWave;
                break;
            case "PS4":
                image_InteractiveWave.sprite = spritePS4_InteractiveWave;
                image_FlashWave.sprite = spritePS4_FlashWave;
                image_PushWave.sprite = spritePS4_PushWave;
                break;
            case "Xbox":
                image_InteractiveWave.sprite = spriteXbox_InteractiveWave;
                image_FlashWave.sprite = spriteXbox_FlashWave;
                image_PushWave.sprite = spriteXbox_PushWave;
                break;
            default:
                Debug.LogWarning("Controller desconocido");
                break;
        }
    }

    #endregion
    public void UpdateLife(float _life,float _maxLife)
    {
        textLife.text = _life.ToString() + "/" + _maxLife.ToString();
        circleImageLife.DOFillAmount(_life / _maxLife, .5f);
    }
    public void UpdateEnergyBar(float _energy)
    {
        float currentEnergy = GameManager.singletone.GetEnergy();
        flashImageBar.DOFillAmount(currentEnergy / 100, 1f);   
    }
    public void SetEnergyBar(float _energy)
    {
        flashImageBar.fillAmount = _energy / 100;
    }
   
    public void SetInteractiveWaveIcon(float _value,float _maxValue)
    {
        interactiveWaveIconImage.fillAmount = _value / _maxValue;
    }
    public void SetPushWaveIcon(float _value, float _maxValue)
    {
        pushWaveIconImage.fillAmount = _value / _maxValue;
    }

    public void SetFlashWaveIcon(float _value)
    {
        flashWaveIconImage.fillAmount = _value;
    }
    void InitHUD()
    {
        float sizeEnergyBar = GameManager.singletone.GetEnergy();
        float lifePlayer = GameManager.singletone.GetLifePlayer();
        float maxLifePlayer = GameManager.singletone.GetMaxLifePlayer();
        UpdateEnergyBar(sizeEnergyBar);
        UpdateLife(lifePlayer, maxLifePlayer);
    }

}
