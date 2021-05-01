using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AscendentPillar : BehaivourWave
{
    [SerializeField] Transform moveTo;
    [SerializeField] float duration;
    [SerializeField] Ease ease;
    [SerializeField] ParticleSystem ps_Moving;
    AudioSource audioSource;
    Rigidbody2D rb2d2;
    Vector3 initialPos;
    bool isGrown;

    private void Awake()
    {
        rb2d2 = gameObject.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        initialPos = transform.position;
        isGrown = false;
    }

    protected override void ActionOnWave(Collider2D col)
    {
        if(col.tag == "InteractiveWave")
        {      
            if (!isGrown)
            {
                transform.DOMove(moveTo.position, audioSource.clip.length).SetEase(ease).OnStart(() => { ps_Moving.Play(); audioSource.Play(); }).OnComplete(() => { isGrown = true; ps_Moving.Stop();}).SetUpdate(UpdateType.Fixed,false);
            }
            else
            {
                transform.DOMove(initialPos, audioSource.clip.length).SetEase(ease).OnStart(() => { ps_Moving.Play(); audioSource.Play(); }).OnComplete(() => { isGrown = false; ps_Moving.Stop(); });

            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}
