using UnityEngine;
using UnityEngine.SceneManagement;

// A utility for transitioning to a scene as a component
// Particularly useful for buttons and events in the editor
public class SceneTransition : MonoBehaviour
{
	[SerializeField] private string TargetScene;

	public void TransitionScene()
	{
		SceneManager.LoadScene(TargetScene);
	}
}