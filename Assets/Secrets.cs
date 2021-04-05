using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secrets : BehaivourWave
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ActionOnWave(Collider2D col)
    {
        if (col.gameObject.CompareTag("InteractiveWave"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
