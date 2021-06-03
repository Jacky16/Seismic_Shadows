using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerEnemies : MonoBehaviour
{
    AudioSource audioSource;
    [Header("Walk Audios")]
    [SerializeField] AudioClip[] audiosWalk;

    [Header("Attack Audios")] 
    [SerializeField]AudioClip[] audiosAttacks;
  
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
        if (audiosWalk.Length == 0) return;
        int randomAudio = Random.Range(0, audiosWalk.Length);
        audioSource.PlayOneShot(audiosWalk[randomAudio]);
    }
    public void PlayAudioHit()
    {
        if (audiosHit.Length == 0) return;
        int randomAudio = Random.Range(0, audiosHit.Length);
        audioSource.PlayOneShot(audiosHit[randomAudio]);
    }
    public void PlayAudioDeath()
    {
        if (audiosDeath.Length == 0) return;
        int randomAudio = Random.Range(0, audiosDeath.Length);
        audioSource.PlayOneShot(audiosDeath[randomAudio]);
    }
    public void PlayAudiosAttack()
    {
        if (audiosAttacks.Length == 0) return;
        int randomAudio = Random.Range(0, audiosAttacks.Length);
        audioSource.PlayOneShot(audiosAttacks[randomAudio]);

    }

}
