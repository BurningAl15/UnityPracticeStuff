using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

    public static SoundSystem instance;

    public AudioClip audioClipCoin;
    public AudioClip audioClipFlap;
    public AudioClip audioClipHit;

    public AudioSource audioSource;

    private void Awake()
    {
        if(SoundSystem.instance == null)
        {
            SoundSystem.instance = this;
        }
        else if(SoundSystem.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeCharacter()
    {
        PlayAudioClip(audioClipCoin);
    }

    public void PlayFlap()
    {
        PlayAudioClip(audioClipFlap);
    }

    public void PlayHit()
    {
        PlayAudioClip(audioClipHit);
    }

    public void PlayCoin()
    {
        PlayAudioClip(audioClipCoin);
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        if(SoundSystem.instance == this)
        {
            SoundSystem.instance =null;
        }
    }
}
