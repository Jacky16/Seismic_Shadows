using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaivourInteractive : BehaivourWave
{
    protected override void ActionOnWave(Collider2D col)
    {
        if (col.gameObject.CompareTag("InteractiveWave"))
        {

        }
    }
}
