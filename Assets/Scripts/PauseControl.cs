using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;

    void Update()
    {
	  if (Input.GetKeyDown("escape"))
	  {
		print("escape was pressed");
		gameIsPaused = !gameIsPaused;
		PauseGame();
	  }
    }

    // Pause the game
    void PauseGame()
    {
	  if (gameIsPaused)
        {
        	Time.timeScale = 0;
        }
	  else
        {
        	Time.timeScale = 1;
        }
    }	
}
