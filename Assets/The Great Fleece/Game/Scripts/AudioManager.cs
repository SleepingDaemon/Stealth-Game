using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.Log("AudioManager is null");

            return _instance;
        }
    }

    public AudioSource voiceOverSource = null;
    
    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clip)
    {
        voiceOverSource.clip = clip;
        voiceOverSource.Play();
    }
}
