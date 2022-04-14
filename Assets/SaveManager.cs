using UnityEngine;

[CreateAssetMenu(menuName = "Save Manager")]
public class SaveManager : ScriptableObject
{
	private Save _activeSave;
	// TODO: add helicopter to get its tokens and such

	public void LoadGame(string savePath)
	{
		Debug.Log($"Loading game from {savePath} (NOT YET IMPLEMENTED)");
		_activeSave = new Save
		{
			ActiveLevel = 42,
			NumTokens = 69,
			Difficulty = 1,
		};
	}

	public void SaveGame(string savePath)
	{
		Debug.Log($"Saving game to {savePath} (NOT YET IMPLEMENTED)");
		Debug.Log($"level: {_activeSave.ActiveLevel}");
		Debug.Log($"tokens: {_activeSave.NumTokens}");
		Debug.Log($"difficulty: {_activeSave.Difficulty}");
	}
}