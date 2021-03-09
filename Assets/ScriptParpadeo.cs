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
        if (timer >= 0.05)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 1f);
        }
        if (timer >= 0.1)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.9f);
        }
        if (timer >= 0.15)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.8f);
        }
        if (timer >= 0.2)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.7f);
        }
        if (timer >= 0.25)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.6f);
        }
        if (timer >= 0.3)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.5f);
        }
        if (timer >= 0.35)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.4f);
        }
        if (timer >= 0.4)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.3f);
        }
        if (timer >= 0.45)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.2f);
        }
        if (timer >= 0.5)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.1f);
        }
        if (timer >= 0.55)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0f);
        }
        if (timer >= 0.6)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.1f);
        }
        if (timer >= 0.65)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.2f);
        }
        if (timer >= 0.7)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.3f);
        }
        if (timer >= 0.75)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.4f);
        }
        if (timer >= 0.8)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.5f);
        }
        if (timer >= 0.85)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.6f);
        }
        if (timer >= 0.9)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.7f);
        }
        if (timer >= 0.95)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.8f);
        }
        if (timer >= 1)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0.9f);
            timer = 0;
        }

    }
}
