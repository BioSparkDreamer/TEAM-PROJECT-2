using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRunes : MonoBehaviour
{
    public int runes = 0;
    public AudioSource runeAudio;
    public GameObject projectilePrefab;
    public AudioSource musicSource;
    AudioSource audioSource;
    public AudioClip barkSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        //..............................................Conditional to get into temple
        if (runes == 3)
        {
            SceneManager.LoadScene(1);
        }
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
        runes++;
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
