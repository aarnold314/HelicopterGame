using UnityEngine;
using UnityEngine.SceneManagement;

public class TempShopNav : MonoBehaviour
{
    // public static int level = 0;
    public string[] levels = {"Level1", "Level2", "Level3"};
    public int index = 0;
    // [SerializeField] public string sceneName;

    void Start()
    {
        index += 1;
        Debug.Log(index);

        // scene = SceneManager.GetActiveScene();
        // Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);
    }

    public void NextScene ()
    {
        SceneManager.LoadScene(levels[index]);
    }
}
