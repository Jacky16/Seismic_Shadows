using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeAnimation : MonoBehaviour
{
    float fadeDuration;
    SpriteRenderer spriteRenderer;
    bool isAnim;
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
        if (isAnim)
        {
            spriteRenderer.color = color;
            Sequence sequence = DOTween.Sequence();
            if (sequence.IsPlaying())
            {
                sequence.Restart();
            }
            sequence.Append(spriteRenderer.DOColor(color, .1f));
            sequence.Append(spriteRenderer.DOFade(0, fadeDuration));
            sequence.OnComplete(() => isAnim = false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Color color = Color.white;

        if (collision.TryGetComponent(out WaveAnimation sa))
        {
            color = sa.GetSprite().color;
            isAnim = true;
        }
        PlayFadeAnimation(color);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color color = Color.white;

        if (collision.gameObject.TryGetComponent(out WaveAnimation sa))
        {
            color = sa.GetSprite().color;
        }
        PlayFadeAnimation(color);
    }
}
