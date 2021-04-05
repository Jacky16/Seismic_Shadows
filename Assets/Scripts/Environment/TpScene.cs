using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TpScene : MonoBehaviour
{
    [SerializeField] int sceneID;
    Animator animFade;

    private void Awake()
    {
        animFade = GameObject.Find("Canvas-Fade").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Invoke("SwitchScene", 2);
            animFade.SetTrigger("FadeIn");
        }
    }
    void SwitchScene()
    {
        SceneManager.LoadScene(sceneID);
    }
}
