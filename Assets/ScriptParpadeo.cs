using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScriptParpadeo : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.2)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 1f);
        }
        if (timer >= 0.4)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.9f);
        }
        if (timer >= 0.6)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.8f);
        }
        if (timer >= 0.8)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.7f);
        }
        if (timer >= 1)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.6f);
        }
        if (timer >= 1.2)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.5f);
        }
        if (timer >= 1.4)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.4f);
        }
        if (timer >= 1.6)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.3f);
        }
        if (timer >= 1.8)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.2f);
        }
        if (timer >= 2)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.1f);
        }
        if (timer >= 2.2)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0f);
        }
        if (timer >= 2.4)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.1f);
        }
        if (timer >= 2.6)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.2f);
        }
        if (timer >= 2.8)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.3f);
        }
        if (timer >= 3)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.4f);
        }
        if (timer >= 3.2)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.5f);
        }
        if (timer >= 3.4)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.6f);
        }
        if (timer >= 3.6)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.7f);
        }
        if (timer >= 3.8)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.8f);
        }
        if (timer >= 4)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.9f);
            timer = 0;
        }

    }
}
