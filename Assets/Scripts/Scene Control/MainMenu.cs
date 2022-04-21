using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
	[SerializeField] private SaveManager saveManager;

	// TODO: proper save file locations
	private const string testSavePath = "testsave";

	public void PlayGame()
	{
		saveManager.CreateSaveIfNotExists(testSavePath);
		saveManager.LoadGame(testSavePath);
		SceneManager.LoadScene("Objective1");
	}

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}
}