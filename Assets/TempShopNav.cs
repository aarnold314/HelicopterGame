using UnityEngine;
using UnityEngine.SceneManagement;

public class TempShopNav : MonoBehaviour
{
    [SerializeField] public string sceneName;

    // void Start()
    // {
    //     // scene = SceneManager.GetActiveScene();
    //     // Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);
    // }

    public void NextScene ()
    {
        SceneManager.LoadScene(sceneName);
    }
}
