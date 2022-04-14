using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjective : MonoBehaviour
{
    public GameObject objectiveScreenUI;
    // add time constant

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    IEnumerator waiter()
    {
        // Doesn't start game
        Time.timeScale = 0f; 
        // Shows objective screen for 10 seconds
        yield return new WaitForSecondsRealtime(10);
        objectiveScreenUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
