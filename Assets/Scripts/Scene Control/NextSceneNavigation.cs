using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneNavigation : MonoBehaviour
{
	public static string NextScene;

	public void GoToNextScene()
	{
		SceneManager.LoadScene(NextScene);
	}
}