using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class WaveAnimation : MonoBehaviour
{
    [SerializeField] float scaleTo;
    [SerializeField] float duration;
    [SerializeField] float durationFadeCollisions;
    [SerializeField] SpriteRenderer sprite;
    float counter;
     enum Wavetype {INTERACTIVE, PUSH,NONE };
    [SerializeField] Wavetype wavetype = Wavetype.NONE;
    private void Start()
    {
        DoWaveAnimation();
        counter = duration;
    }
    private void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0) counter = 0;
    }
    public void DoWaveAnimation()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(scaleTo, duration);
        sprite.DOFade(0, duration).OnComplete(() => Destroy(gameObject));
    }
    public SpriteRenderer GetSprite()
    {
        return sprite;
    }
    public float GetDuration()
    {
        return duration;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FadeAnimation>(out FadeAnimation fa))
        {
            if (!collision.CompareTag("ObjectInteractive"))
            {
                fa.SetDurationFade(counter);
            }
        }       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<FadeAnimation>(out FadeAnimation fa))
        {
            switch (wavetype)
            {
                case Wavetype.INTERACTIVE:
                    fa.PlayObjectInteractive();
                    break;

                case Wavetype.PUSH:
                    break;

                default:
                    
                    break;

            }
        }
    }
}
