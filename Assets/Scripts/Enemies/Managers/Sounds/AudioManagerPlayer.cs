using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [Header("Walk Audios")]
    [SerializeField]AudioClip [] audiosWalk;
    [Header("Jump Audios")]
    [SerializeField] AudioClip[] audiosJump;
    [Header("Hit Audios")]
    [SerializeField] AudioClip[] audiosHit;
    [Header("Push Audios")]
    [SerializeField] AudioClip[] audiosPush;
    [Header("Death Audios")]
    [SerializeField] AudioClip[] audiosDeath;
    [Header("Stick Audios")]
    [SerializeField] AudioClip[] audiosStick;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayAudioWalk()
    {
        int randomAudio = Random.Range(0, audiosWalk.Length);
        audioSource.PlayOneShot(audiosWalk[randomAudio]);
    }
    void PlayAudioJump()
    {
        int randomAudio = Random.Range(0, audiosJump.Length);
        audioSource.PlayOneShot(audiosJump[randomAudio]);
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
    void PlayAudioPush()
    {
        int randomAudio = Random.Range(0, audiosPush.Length);
        audioSource.PlayOneShot(audiosPush[randomAudio]);
    }
    void AudioStickAgainstGround()
    {
        int randomAudio = Random.Range(0, audiosStick.Length);
        audioSource.PlayOneShot(audiosStick[randomAudio]);
    }
}
