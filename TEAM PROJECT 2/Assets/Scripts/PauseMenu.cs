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

    void FixedUpdate()
	{

		//......................................Uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				ShowPaused();
				gameIsPaused = true;
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				HidePaused();
				gameIsPaused = false;
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
		HidePaused();
	}

	//.......................................... Goes to Main Menu
	public void MainMenu()
    {
		SceneManager.LoadScene(0);
		HidePaused();
	}

	//..........................................Controls the un-pausing of the scene
	public void Resume()
    {
		Time.timeScale = 1;
		HidePaused();
	}

	//..........................................Shows objects with ShowOnPause tag
	public void ShowPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
			Cursor.lockState = CursorLockMode.Confined;
		}
	}

	//..........................................Hides objects with ShowOnPause tag
	public void HidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
