using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Game Manager")]
public class GameManager : ScriptableObject
{
	// idk why this is needed, some serialization weirdness
	[SerializeField] private SaveManager saveManager;

	public void GameOver()
	{
		Debug.Log("Game Over");
	}
}