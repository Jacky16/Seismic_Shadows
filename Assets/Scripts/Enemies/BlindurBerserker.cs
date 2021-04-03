using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindurBerserker : Enemy
{
    [Header("Settings Blindur Berserker")]
    [SerializeField] float timeToCargerAgain;
    [SerializeField] float wallCheckDistance;
    bool carger;
    Vector3 toGo;
    float count = float.MaxValue;


    void CheckWall()
    {
        Collider2D col = Physics2D.OverlapBox(hitAttackPos.position, sizeHitBoxAttack, 0, layerMaskEnvironent);
        if (col != null)
        {
            SetCargerFalse();
        }
    }
    void SetCargerFalse()
    {
        carger = false;
        anim.SetBool("Carger", carger);
        transform.Rotate(0, 180, 0);
    }
}
