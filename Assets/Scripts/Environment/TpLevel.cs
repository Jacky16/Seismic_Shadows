using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpLevel : MonoBehaviour
{

    Transform player;
    [SerializeField] int posX;
    [SerializeField] int posY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.position = new Vector3(posX, posY, 0);
    }
}
