using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextTrigger : MonoBehaviour
{
    TextMeshProUGUI tecla;
    [TextArea]
    [SerializeField] string t_tecla;
    // Start is called before the first frame update
    void Start()
    {
        tecla = GameObject.FindGameObjectWithTag("TextTutorial").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
