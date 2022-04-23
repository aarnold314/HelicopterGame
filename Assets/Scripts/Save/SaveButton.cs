using UnityEngine;

public class SaveButton : MonoBehaviour
{
	[SerializeField] private SaveManager saveManager;

	private void Start()
	{
		saveManager.ActiveLevel = saveManager.ActiveLevel + 1;
	}

	public void SaveGame()
	{
		//saveManager.SaveGame();
	}
}