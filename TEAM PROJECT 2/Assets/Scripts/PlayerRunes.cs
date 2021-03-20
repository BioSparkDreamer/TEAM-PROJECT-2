using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunes : MonoBehaviour
{
    static public int runes;
    public AudioSource runeAudio;
    public GameObject projectilePrefab;
    public AudioSource musicSource;
    AudioSource audioSource;
    public AudioClip barkSound;

    void Start()
    {
        runes = 0;

        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);
            Destroy(projectile, .5f);
            PlaySound(barkSound);

        }
    }

    public void ChangeRunes()
    {
        runes += 1;
    }

    internal void PlayAudioForRunes()
    {
        runeAudio.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
