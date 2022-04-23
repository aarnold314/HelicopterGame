using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowObjective : MonoBehaviour
{
	public GameObject objectiveScreen;
	public GameObject taskScreen;
	[SerializeField] private string sceneName;
	[SerializeField] private bool saveGameOnTransition;
	[SerializeField] private SaveManager saveManager;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return) && taskScreen.activeSelf)
		{
			if (saveGameOnTransition)
			{
				saveManager.SaveGame();
			}

			SceneManager.LoadScene(sceneName);
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			objectiveScreen.SetActive(false);
			taskScreen.SetActive(true);
		}
	}
}