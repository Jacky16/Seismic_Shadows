using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextTrigger : MonoBehaviour
{
    TextMeshProUGUI tecla;
    [TextArea]
    [SerializeField] string t_tecla;
    WaveSpawner setBools;
    // Start is called before the first frame update
    void Start()
    {
        setBools = GameObject.FindGameObjectWithTag("Player").GetComponent<WaveSpawner>();
        tecla = GameObject.FindGameObjectWithTag("TextTutorial").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && gameObject.name == "ActivePushWave")
        {
            setBools.SetPushBool(true);
        }

        if (collision.gameObject.tag == "Player" && gameObject.name == "ActiveInteractiveWave")
        {
            setBools.SetInteractiveBool(true);
        }

        if (collision.gameObject.tag == "Player" && gameObject.name == "ActiveFlashWave")
        {
            setBools.SetFlashBool(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tecla.text = t_tecla;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tecla.text = "";
        }
    }
}
