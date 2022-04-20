using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowObjective : MonoBehaviour
{
    // public LevelLoader levelLoader;
    public GameObject objectiveScreenUI;
    [SerializeField] float waitTime = 5f;
    [SerializeField] int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        // levelLoader = GetComponent<LevelLoader>();
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    IEnumerator waiter()
    {
        // Shows objective screen for 10 seconds
        yield return new WaitForSecondsRealtime(waitTime);
        // levelLoader.LoadLevel(sceneIndex);
        

        SceneManager.LoadScene("Level1");
    }
}
