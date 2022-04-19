using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private SaveManager saveManager;

	// TODO: proper save file locations
	private const string testSavePath = "UserData/testsave"; // This is relative to the project root

	public void PlayGame()
	{
		if (!File.Exists(testSavePath))
		{
			saveManager.CreateNewSave(testSavePath);
		}

		saveManager.LoadGame(testSavePath);
		
		// Loads the next level in the queue
		SceneManager.LoadScene("Objective1");
	}

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}
}