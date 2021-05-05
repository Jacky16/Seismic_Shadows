using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanguineAmatist : MonoBehaviour
{
    HealthPlayer hp;
    [SerializeField] GameObject [] VFX_PickUps;

    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hp.AddMaxLife(1);
            hp.AddLife(999);
            GameManager.singletone.SetLifePlayerHUD(hp.GetLife(), hp.GetMaxLife());
            foreach(GameObject go in VFX_PickUps)
            {
                Instantiate(go, collision.transform.position + (Vector3.down * 40), transform.rotation = Quaternion.Euler(-100,0,0) , collision.transform);
            }
            Destroy(gameObject);
        }
    }
}
