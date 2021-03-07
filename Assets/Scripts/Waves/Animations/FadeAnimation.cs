using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeAnimation : MonoBehaviour
{
    float fadeDuration;
    SpriteRenderer spriteRenderer;
    Color color = Color.white;
    enum Wavetype { INTERACTIVE, PUSH, NONE };
    [SerializeField] Wavetype wavetype = Wavetype.NONE;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetDurationFade(float num)
    {
        fadeDuration = num;
    }

    //Anima todo lo que no sea interactuable o empujable
    void PlayFadeAnimation(Color color)
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

    void PlayInteractiveAnimation()
    {
        spriteRenderer.DOFade(1, 2);       
    }
    public void PlayAnimation()
    {
        switch (wavetype)
        {
            case Wavetype.INTERACTIVE:
                PlayInteractiveAnimation();
                break;

            case Wavetype.PUSH:
                break;

            default:
            PlayFadeAnimation(color);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Obtener el sprite contra lo que colisiona
        if (collision.TryGetComponent(out WaveAnimation wa))
        {
            color = wa.GetSprite().color;
        }
        PlayAnimation();
    }
}
