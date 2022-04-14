using UnityEngine;

public class TestSave : MonoBehaviour
{
	[SerializeField] private SaveManager _saveManager;

	void Start()
	{
		_saveManager.LoadGame("a");
		_saveManager.SaveGame("test");
	}
}