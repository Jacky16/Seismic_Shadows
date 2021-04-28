using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerEnemies : MonoBehaviour
{
    [SerializeField]AudioSource audioSource;
    [Header("Walk Audios")]
    [SerializeField] AudioClip[] audiosWalk;
  
    [Header("Hit Audios")]
    [SerializeField] AudioClip[] audiosHit;
  
    [Header("Death Audios")]
    [SerializeField] AudioClip[] audiosDeath;
  
    void PlayAudioWalk()
    {
        int randomAudio = Random.Range(0, audiosWalk.Length);
        audioSource.PlayOneShot(audiosWalk[randomAudio]);
    }
    public void PlayAudioHit()
    {
        int randomAudio = Random.Range(0, audiosHit.Length);
        audioSource.PlayOneShot(audiosHit[randomAudio]);
    }
    public void PlayAudioDeath()
    {
        int randomAudio = Random.Range(0, audiosDeath.Length);
        audioSource.PlayOneShot(audiosDeath[randomAudio]);
    }
    
}
