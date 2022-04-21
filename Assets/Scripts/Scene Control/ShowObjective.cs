using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowObjective : MonoBehaviour
{
    // public LevelLoader levelLoader;
    public GameObject objectiveScreen;
    public GameObject taskScreen;
    [SerializeField] int sceneIndex;


    // Start is called before the first frame update
    void Start()
    {
        // levelLoader = GetComponent<LevelLoader>();
        // StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return) && taskScreen.activeSelf)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            objectiveScreen.SetActive(false);
            taskScreen.SetActive(true);
        }
        
    }
    IEnumerator waiter()
    {
        
        // Shows objective screen for 10 seconds
        yield return new WaitForSecondsRealtime(2f);
        // SceneManager.LoadScene("Level1");
    }
}
