using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveComplete : MonoBehaviour
{
    // Player reaches end zone
    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
           GetComponent<BoxCollider2D>().enabled = false;
           StartCoroutine(EnableBox(1.0f));
        }
    }

    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
