﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        //TODO tirar esse comentário
        //audioSource.volume = PlayerPrefsController.GetMasterVolume();
        audioSource.volume = 1f;
        
    }

   public void setVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
