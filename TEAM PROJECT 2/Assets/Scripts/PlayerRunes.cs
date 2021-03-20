using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRunes : MonoBehaviour
{
    public int runes = 0;

    void Start()
    {
<<<<<<< Updated upstream
        
=======
        runes = 0;

        audioSource = GetComponent<AudioSource>();


>>>>>>> Stashed changes
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
}
