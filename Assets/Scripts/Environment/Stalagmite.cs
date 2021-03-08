using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagmite : MonoBehaviour
{
    private HealthPlayer health;
    private float count;
    [SerializeField] float timeToDamagePlayer;
    // Start is called before the first frame update
    void Start()
    {
        count = timeToDamagePlayer;
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            //VARIABLES
            //Count: Contador de segundos 
            //timeToDamagePlayer: Se le da el valor desde el inspector,
            //indica cada cuanto tiempo se le hará daño al player.

            //EXPLICACIÓN
            //Lo que se pretende es que cada 'X' segundos de estar encima
            //de una estalagmita, el jugador reciba 1 de daño.
            //De esta forma evitamos que el player se mantenga mucho tiempo encima.

            count += Time.deltaTime;
            if (count >= timeToDamagePlayer)
            {
                health.Damage(1);
                count = 0;
            }
        }
    }
}   
