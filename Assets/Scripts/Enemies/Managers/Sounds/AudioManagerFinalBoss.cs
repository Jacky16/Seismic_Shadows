using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerFinalBoss : MonoBehaviour
{
    AudioSource audioSource;
    [Header("Walk Audios")]
    [SerializeField] AudioClip[] audiosWalk;

    [Header("Attack Audios")]
    [SerializeField] AudioClip[] audiosAttacks;

    [Header("Hit Audios")]
    [SerializeField] AudioClip[] audiosHit;

    [Header("Death Audios")]
    [SerializeField] AudioClip[] audiosDeath;

    [Header("Audios Teleport")]
    [SerializeField] AudioClip[] audiosTeleport;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void PlayAudioWalk()
    {
        int randomAudio = Random.Range(0, audiosWalk.Length);
        audioSource.PlayOneShot(audiosWalk[randomAudio]);
        Debug.Log("Sondifo de cmain");
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
    public void PlayAudiosAttack()
    {
        int randomAudio = Random.Range(0, audiosAttacks.Length);
        audioSource.PlayOneShot(audiosAttacks[randomAudio]);

    }
}
