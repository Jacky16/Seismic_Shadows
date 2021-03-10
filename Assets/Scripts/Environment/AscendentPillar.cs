using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscendentPillar : BehaivourWave
{
    Rigidbody2D rb2d2;
    float count;
    [SerializeField] float ascTime;
    [SerializeField] float speed;
    bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        
        rb2d2 = gameObject.GetComponent<Rigidbody2D>();
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

        if(canMove == true)
        {
            count += Time.fixedDeltaTime;
           
            if(count >= ascTime)
            {
                canMove = false;
                rb2d2.bodyType = RigidbodyType2D.Static;
                GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            }
        }
        if (canMove)
        {
            rb2d2.velocity = Vector2.up * speed;
        }     
    }
    protected override void ActionOnWave(Collider2D col)
    {
        if(col.tag == "InteractiveWave")
        {
            canMove = true;
        }
    }
}
