using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("1_UpperMantle");
        }

        counter += Time.deltaTime;
        if(counter >= 70)
        {
            SceneManager.LoadScene("1_UpperMantle");
        }
    }
}
