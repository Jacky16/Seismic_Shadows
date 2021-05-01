using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StoryController : MonoBehaviour
{
    [TextArea]
    [SerializeField] string story;
    [SerializeField] TextMeshProUGUI textToShow;
    [SerializeField] TextMeshProUGUI textEscape;
    [SerializeField] TextMeshProUGUI textSpace;
    [SerializeField] string numberStory;
    MusicController music;
    int textLength;
    string completeText = "";
    string actualText = "";
    float counter;
    int index;
    bool completed;
    bool escaped;
    // Start is called before the first frame update
    void Start()
    {
        textEscape.enabled = false;
        textSpace.enabled = false;
        index = 0;
        textToShow.text = "";
        textLength = story.Length;
        counter = 0;
        completed = false;
        music = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        counter += Time.deltaTime;
        if (index < textLength)
        {
            if (counter >= 0.05)
            {
                actualText = actualText + story[index];
                textToShow.text = actualText;
                index++;
                counter = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (completed)
            {
                if(SceneManager.GetActiveScene().name != "Story_8")
                {
                    SceneManager.LoadScene("Story_" + numberStory);
                }

                else
                {
                    music.DestroyItem();
                    SceneManager.LoadScene("1_UpperMantle");
                }
            }
            else
            {
                for (int j = 0; j < textLength; j++)
                {
                    completeText = completeText + story[j];
                }

                textToShow.text = completeText;
                index = textLength;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && escaped)
        {
            music.DestroyItem();
            SceneManager.LoadScene("1_UpperMantle");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !escaped)
        {
            textEscape.enabled = true;
            escaped = true;
        }

        if (index == textLength)
        {
            textSpace.enabled = true;
            completed = true;
        }
    }
}
