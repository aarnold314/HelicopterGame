using System.IO;
using UnityEngine;

public class TestSave : MonoBehaviour
{
	[SerializeField] private SaveManager _saveManager;

	private const string testSavePath = "UserData/testsave"; // This is relative to the project root

	private void Start()
	{
		if (!File.Exists(testSavePath))
		{
			_saveManager.CreateNewSave(testSavePath);
		}

		_saveManager.LoadGame(testSavePath);
		_saveManager.SaveGame(testSavePath);
	}
}