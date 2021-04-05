using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class AnimationPauseUI : MonoBehaviour
{
    [SerializeField] GameObject canvasPause;
    [Header("Tween options")]
    [SerializeField] float time;
    [SerializeField] Ease easeIn;
    [SerializeField] Ease easeOut;
    [Space]
    [SerializeField] RectTransform recTransfromMarco;
    [SerializeField] RectTransform rectTransformTitle;
    [SerializeField] Image background;

    Vector2 initMarcoPos;
    Vector2 initTitlePos;
    private void Start()
    {
        initMarcoPos = recTransfromMarco.anchoredPosition;
        initTitlePos = rectTransformTitle.anchoredPosition;
    }
    private void OnEnable()
    {
        
    }
    public void PlayAnimationInit()
    {
        background.DOFade(.75f, time);
        recTransfromMarco.DOAnchorPos(Vector2.zero, time).SetEase(easeIn);
        rectTransformTitle.DOAnchorPosY(0, time).SetEase(easeIn);
    }
    public void PlayAnimationOut()
    {
        recTransfromMarco.DOAnchorPosX(initMarcoPos.x, time).SetEase(easeOut).OnComplete(() => canvasPause.SetActive(false));
        rectTransformTitle.DOAnchorPosY(initTitlePos.y, time).SetEase(easeOut);
        background.DOFade(0, time);
    }
}
