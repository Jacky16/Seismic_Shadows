using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaivourStalactites : BehaivourWave
{
    protected override void ActionWave(Collider2D col)
    {
        if (col.gameObject.CompareTag("InteractiveWave"))
        {
            //Esto se ejecuta cuando una onda interactiva choca con este objeto
        }
    }
}
