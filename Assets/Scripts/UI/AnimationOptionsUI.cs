using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AnimationOptionsUI : MonoBehaviour
{
    [SerializeField] GameObject canvasOptions;
    [Header("Tween options")]
    [SerializeField] float time;
    [SerializeField] Ease easeIn;
    [SerializeField] Ease easeOut;
    [Space]
    [SerializeField] RectTransform recTransfromMarco;
    [SerializeField] Image background;
    Vector2 initMarcoPos;
    private void Start()
    {
        initMarcoPos = recTransfromMarco.anchoredPosition;
    }
    private void OnEnable()
    {
        //PlayAnimationIn();
    }

    public void PlayAnimationIn()
    {
        background.DOFade(.5f, time);
        recTransfromMarco.DOAnchorPosX(0, time).SetEase(easeIn);
    }
    public void PlayAnimationOut()
    {
        recTransfromMarco.DOAnchorPosX(initMarcoPos.x, time).SetEase(easeOut).OnComplete(() => canvasOptions.SetActive(false));
        background.DOFade(0, time);
    }
}

