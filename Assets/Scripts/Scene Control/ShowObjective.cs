using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowObjective : MonoBehaviour
{
	public GameObject objectiveScreen;
	public GameObject taskScreen;
	[SerializeField] string sceneName;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return) && taskScreen.activeSelf)
		{
			SceneManager.LoadScene(sceneName);
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			objectiveScreen.SetActive(false);
			taskScreen.SetActive(true);
		}
	}
}