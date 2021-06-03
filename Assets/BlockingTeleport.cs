using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingTeleport : MonoBehaviour
{
    [SerializeField] float time;
    float counter = 0;
    FinalBoss finalBoss;
    bool hasTeleport;
    [SerializeField] Transform []tpPos;

    private void Awake()
    {
        finalBoss = GameObject.FindGameObjectWithTag("FinalBoss").GetComponent<FinalBoss>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FinalBoss"))
        {
            finalBoss.SetHole(true);
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("FinalBoss"))
        {
            finalBoss.StopMovement();
            counter += Time.fixedDeltaTime;
            if(counter >= time)
            {
                int ran = Random.Range(0, tpPos.Length);

                finalBoss.StartCoroutine(finalBoss.Teleport(tpPos[ran].position));
                counter = 0;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FinalBoss"))
        {
            counter = 0;

        }
    }
}
