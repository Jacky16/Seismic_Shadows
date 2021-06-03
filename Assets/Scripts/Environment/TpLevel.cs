using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpLevel : MonoBehaviour
{
    Transform player;
    [SerializeField] Transform posToGo;
    [SerializeField] int posX;
    [SerializeField] int posY;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        //Se que es una guarrada :)
        anim = GameObject.Find("Canvas_FadeLevels").GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(ChangeLevel());
        }
    }
    IEnumerator ChangeLevel()
    {
        anim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.3f);
        anim.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);

        player.position = posToGo.position;

    }
}
