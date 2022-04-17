using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		// Loads the next level in the queue
		SceneManager.LoadScene("Objective1");
	}

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}
}