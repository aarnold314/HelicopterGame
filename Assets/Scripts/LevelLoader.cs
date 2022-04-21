using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
	public GameObject loadingScreen;
	public GameObject previousScreen;
	public Slider slider;

	public void LoadLevel(string sceneName)
	{
		StartCoroutine(LoadAsynchronously(sceneName));
		Debug.Log("In levelloader");
	}

	private IEnumerator LoadAsynchronously(string sceneName)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

		previousScreen.SetActive(false);
		loadingScreen.SetActive(true);

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / 0.9f);
			slider.value = progress;

			yield return null;
		}
	}
}