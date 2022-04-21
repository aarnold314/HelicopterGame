using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveComplete : MonoBehaviour
{
    // public GameObject pauseScreen;
    public GameObject showScreen;
    
    [SerializeField] float waitTime = 5f;
	
    public Health playerHealth;
    // Player reaches end zone
    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
	  // If player enters and is not "dead"
        if (collisionInfo.collider.tag == "Player" && ((Health.isDead) == false))
        {
            Debug.Log("Touchdown");
            Freeze();
        }
    }

    void Freeze ()
    {
        // freezes game
        Time.timeScale = 0f;
        showScreen.SetActive(true);
        StartCoroutine(EnableBox(waitTime));
    }

    IEnumerator EnableBox (float waitTime)
    {
        // Shows objective screen for 10 seconds
        yield return new WaitForSecondsRealtime(waitTime);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        // Time.timeScale = 1f;

        // yield return new WaitForSeconds(waitTime);
    }
}
