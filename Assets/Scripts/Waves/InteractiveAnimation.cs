using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveAnimation : FadeAnimation
{
    [SerializeField] float durationAnim;
    public override void PlayObjectInteractive()
    {
        spriteRenderer.DOFade(1, durationAnim);
    }
   
}
