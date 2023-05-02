using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusic : MonoBehaviour
{
    public AudioMixer audioMixer;
    private AudioSource audioSource;

    void Start()
    {
        audioMixer.SetFloat("Volume", 1);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

}

