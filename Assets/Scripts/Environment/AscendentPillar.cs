using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AscendentPillar : BehaivourWave
{
    Rigidbody2D rb2d2;
    float count;
    [SerializeField] Transform moveTo;
    Vector3 initialPos;
    [SerializeField] float duration;
    [SerializeField] Ease ease;
    bool isGrown;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb2d2 = gameObject.GetComponent<Rigidbody2D>();
        initialPos = transform.position;
        isGrown = false;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //EXPLICACION
        //Si canMove es true, se inicia un contador que hace que
        //hasta que no se llegue a ascTime, el pilar irá ascendiendo
        //progresivamente. Una vez llegado a ascTime, el cuerpo se 
        //hará Static para que deje de subir.

        //VARIABLES
        //canMove: booleano para saber si el pilar debe subir o no.
        //count: contador de cuanto lleva subiendo.
        //ascTime: se le asigna el valor desde el inspector, tiempo
        //máximo que estará subiendo el pilar.
        //speed: se le asigna el valor desde el inspector, velocidad
        //a la que ascenderá el pilar.

        
    }
    protected override void ActionOnWave(Collider2D col)
    {
        if(col.tag == "InteractiveWave")
        {
            if (!isGrown)
            {
                transform.DOMove(moveTo.position, duration).SetEase(ease).OnComplete(() => isGrown = true);
            }
            else
            {
                transform.DOMove(initialPos, duration).SetEase(ease).OnComplete(() => isGrown = false);

            }

        }
    }
}
