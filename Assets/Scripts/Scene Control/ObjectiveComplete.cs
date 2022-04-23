using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveComplete : MonoBehaviour
{
	// public GameObject pauseScreen;
	public GameObject showScreen;
	[SerializeField] private string nextObjective;
	[SerializeField] string nextScene;
	[SerializeField] float waitTime = 5f;

	[SerializeField] private SaveManager saveManager;

	// Player reaches end zone
	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.collider.CompareTag("Player"))
		{
			Freeze();
		}
	}

	void Freeze()
	{
		// freezes game
		Time.timeScale = 0f;
		showScreen.SetActive(true);
		StartCoroutine(EnableBox(waitTime));
	}

	IEnumerator EnableBox(float waitTime)
	{
		// Shows objective screen for 10 seconds
		yield return new WaitForSecondsRealtime(waitTime);
		Time.timeScale = 1f;
		NextSceneNavigation.NextScene = nextObjective;
		SceneManager.LoadScene(nextScene);
	}
}