using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowObjective : MonoBehaviour
{
    public GameObject objectiveScreenUI;
    
    [SerializeField] float waitTime = 5f;
    // add time constant

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    IEnumerator waiter()
    {
        // Shows objective screen for 10 seconds
        yield return new WaitForSecondsRealtime(waitTime);
        objectiveScreenUI.SetActive(false);

        SceneManager.LoadScene("Level1");
    }
}
