using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipHolder : MonoBehaviour
{
    public static AudioClipHolder instance;

    AudioSource audioSource;

    public AudioClip laserClip;
    public AudioClip destroyClip;

    void Awake() 
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void DestoyedAudio()
    {
         audioSource.PlayOneShot(destroyClip);
    }

    public void LaserAudio()
    {
        audioSource.PlayOneShot(laserClip);
    }
}
