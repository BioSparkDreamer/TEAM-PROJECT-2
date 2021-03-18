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
		hidePaused();
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
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				gameIsPaused = false;
				hidePaused();
			}
		}
	}


	//..........................................Reloads the Level
	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    //..........................................Goes to About Screen
    public void about()
    {
		SceneManager.LoadScene(1);
	}

	//.......................................... Goes to Main Menu
	public void mainMenu()
    {
		SceneManager.LoadScene(0);
	}

	//..........................................Controls the un-pausing of the scene
	public void resume()
    {
		Time.timeScale = 1;
    }

	//..........................................Shows objects with ShowOnPause tag
	public void showPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//..........................................Hides objects with ShowOnPause tag
	public void hidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}
}
