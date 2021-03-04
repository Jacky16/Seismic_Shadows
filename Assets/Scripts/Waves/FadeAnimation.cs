using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class FadeAnimation : MonoBehaviour
{
    float fadeDuration;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetDurationFade(float num)
    {
        fadeDuration = num;
    }
    public void PlayFadeAnimation(Color color)
    {
        spriteRenderer.color = color;
        Sequence sequence = DOTween.Sequence();
        if (sequence.IsPlaying())
        {
            sequence.Restart();
        }
        sequence.Append(spriteRenderer.DOColor(color, .1f));
        sequence.Append(spriteRenderer.DOFade(0, fadeDuration));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Color color = Color.white;

        if (collision.TryGetComponent(out WaveAnimation wa))
        {
            color = wa.GetSprite().color;
        }
        PlayFadeAnimation(color);
    }
}
