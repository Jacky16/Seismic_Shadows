using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecretAmetist : MonoBehaviour
{
    TextMeshProUGUI text;
    bool amestistFound;


    GameObject otherText;
    bool otherTextBool;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        amestistFound = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        otherTextBool = otherText.GetComponent<SecretAmetist>().amestistFound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
