using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

public class AnimationMainMenuUI : MonoBehaviour
{
    [Header("Tween options")]
    [SerializeField] float time;
    [SerializeField] Ease easeIn;
    [SerializeField] Ease easeOut;
    [SerializeField] float timeBetweenTween;

    [Header("Rect TransformComponents")]
    [SerializeField] RectTransform[] recTransforms;
    [SerializeField] Vector2[] initPositions;

    [SerializeField] UnityEvent OnButtonsDefault;


    private void Start()
    {
        for(int i = 0; i < recTransforms.Length; i++)
        {
            initPositions[i] = recTransforms[i].anchoredPosition;
        }
    }
    private void OnEnable()
    {
        PlayAnimationIn();

    }
    public void PlayAnimationIn()
    {
        StartCoroutine(CoroutineAnimationIn());
    }
    public void PlayAnimationOut()
    {
        StartCoroutine(CoroutineAnimationOut());
    }
    IEnumerator CoroutineAnimationIn()
    {
        foreach(RectTransform rt in recTransforms)
        {
            rt.DOAnchorPos(Vector2.zero, time).SetEase(easeIn);
            yield return new WaitForSeconds(timeBetweenTween);
        }
        OnButtonsDefault.Invoke();
    }
    IEnumerator CoroutineAnimationOut()
    {
        for(int i = 0; i < recTransforms.Length; i++)
        {
            recTransforms[i].DOAnchorPos(initPositions[i], time).SetEase(easeOut);
            yield return new WaitForSeconds(timeBetweenTween);
        }
    }
}

