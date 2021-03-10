using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PointWaveAnimation : MonoBehaviour
{
    [SerializeField] float scaleTo;
    [SerializeField] float duration;
    [SerializeField] SpriteRenderer sprite;
    float counter;
    private void Start()
    {
        transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(scaleTo, duration));
        sequence.Join(sprite.DOFade(0, duration));
        sequence.SetLoops(-1);
    }  

    public void SetScale(int _scale)
    {
        scaleTo = _scale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FadeAnimation>(out FadeAnimation fa))
        {
            fa.SetDurationFade(counter);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<FadeAnimation>(out FadeAnimation fa))
        {
            fa.SetDurationFade(counter);
        }
    }

}
