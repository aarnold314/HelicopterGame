using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSelector : MonoBehaviour
{
	[SerializeField] private SaveManager saveManager;

	[SerializeField] private string saveName;

	[SerializeField] private TextMeshProUGUI saveNameText;

	private void Awake()
	{
		if (!saveManager.SaveExists(saveName))
		{
			saveNameText.text = "New Save";
		}
	}

	public void LoadSave()
	{
		saveManager.CreateSaveIfNotExists(saveName);
		saveManager.LoadGame(saveName);
		SceneManager.LoadScene($"Objective1");
	}
}