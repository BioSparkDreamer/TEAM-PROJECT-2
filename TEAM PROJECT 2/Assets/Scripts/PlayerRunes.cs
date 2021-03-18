﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRunes : MonoBehaviour
{
    public int runes = 0;
    public AudioSource runeAudio;

    void Start()
    {
        
    }


    void Update()
    {
        //..............................................Conditional to get into temple
        if (runes == 3)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void ChangeRunes()
        {
	        runes++; 
        }

    internal void PlayAudioForRunes()
    {
            runeAudio.Play();     
    }
}
