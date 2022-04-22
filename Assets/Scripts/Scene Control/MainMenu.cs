using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
	[SerializeField] private SaveManager saveManager;

	private const string savePath = "mainSave";

	public void PlayGame()
	{
		saveManager.CreateSaveIfNotExists(savePath);
		saveManager.LoadGame(savePath);
		SceneManager.LoadScene("Objective1");
	}

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}
}