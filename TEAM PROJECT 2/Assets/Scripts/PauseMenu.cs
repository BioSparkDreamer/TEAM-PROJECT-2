using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	GameObject[] pauseObjects;

	public static bool gameIsPaused;

	void Start()
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("Pause Menu");
		
		HidePaused();
	}

	void Update()
	{

		//......................................Uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				gameIsPaused = true;
				ShowPaused();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				gameIsPaused = false;
				HidePaused();
			}
		}
	}


	//..........................................Reloads the Level
	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    //..........................................Goes to About Screen
    public void About()
    {
		SceneManager.LoadScene(1);
	}

	//.......................................... Goes to Main Menu
	public void MainMenu()
    {
		SceneManager.LoadScene(0);
	}

	//..........................................Controls the un-pausing of the scene
	public void Resume()
    {
		Time.timeScale = 1;
    }

	//..........................................Shows objects with ShowOnPause tag
	public void ShowPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//..........................................Hides objects with ShowOnPause tag
	public void HidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}
}
