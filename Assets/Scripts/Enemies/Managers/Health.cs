using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]protected int life;
    [SerializeField] int maxLife;
    bool isDead;
    protected Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        life = maxLife;    
    }

    public void AddLife(int _life)
    {
        life += _life;
        if(life >= maxLife)
        {
            life = maxLife;
        }
       
    }
    public void AddMaxLife(int _maxLife)
    {
        maxLife += _maxLife;
    }
    public void Damage(int _damage)
    {
        life -= _damage;
        if(life <= 0 && !isDead)
        {
            life = 0;
            isDead = true;
            OnDead();
        }
        if (!isDead)
        {
            StartCoroutine(AnimationRed());
            OnDamage();
        }
     
    }
    protected virtual void OnDamage() {}
    public virtual void OnDead()
    {
        Debug.Log("Dead");
    }
    public bool IsDead()
    {
        return isDead;
    }
    public int GetLife()
    {
        return life;
    }
    public int GetMaxLife()
    {
        return maxLife;
    }
    protected void ResetLife()
    {
        life = maxLife;
        isDead = false;
    }

    IEnumerator AnimationRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSecondsRealtime(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;

    }
}
