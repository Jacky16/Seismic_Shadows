using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerEnemies : MonoBehaviour
{
    AudioSource audioSource;
    [Header("Walk Audios")]
    [SerializeField] AudioClip[] audiosWalk;
  
    [Header("Hit Audios")]
    [SerializeField] AudioClip[] audiosHit;
  
    [Header("Death Audios")]
    [SerializeField] AudioClip[] audiosDeath;
  

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void PlayAudioWalk()
    {
        int randomAudio = Random.Range(0, audiosWalk.Length);
        audioSource.PlayOneShot(audiosWalk[randomAudio]);
    }
    void PlayAudioHit()
    {
        int randomAudio = Random.Range(0, audiosHit.Length);
        audioSource.PlayOneShot(audiosHit[randomAudio]);
    }
    void PlayAudioDeath()
    {
        int randomAudio = Random.Range(0, audiosDeath.Length);
        audioSource.PlayOneShot(audiosDeath[randomAudio]);
    }
    
}
