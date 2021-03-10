using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int maxLife;
    [SerializeField] TextMeshProUGUI lifeText;
    bool isDead;
    protected int life;
    private void Start()
    {
        life = maxLife;
        lifeText.text = maxLife.ToString();
    }

    public void AddLife(int _life)
    {
        life += _life;
        if(life >= maxLife)
        {
            life = maxLife;
        }
        lifeText.text = life.ToString();
    }
    public void AddMaxLife(int _maxLife)
    {
        maxLife += _maxLife;
    }
    public void Damage(int _damage)
    {
        StartCoroutine(AnimationRed());
        life -= _damage;
        if(life <= 0)
        {
            life = 0;
            Dead();
        }
        lifeText.text = life.ToString();
    }
    public virtual void Dead()
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

    IEnumerator AnimationRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSecondsRealtime(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;

    }
}
