using System.IO;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private SaveManager saveManager;

	// TODO: proper save file locations
	private const string testSavePath = "testsave";

	public void PlayGame()
	{
		if (!File.Exists(testSavePath))
		{
			saveManager.CreateNewSave(testSavePath);
		}
		saveManager.LoadGame(testSavePath);
	}

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}
}