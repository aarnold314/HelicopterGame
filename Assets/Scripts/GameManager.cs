using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Game Manager")]
public class GameManager : ScriptableObject
{
	[SerializeField] private SaveManager saveManager;
	
	public void GameOver()
	{
		saveManager.SaveGame("mainSave");
		Debug.Log("Game Over");
	}
}