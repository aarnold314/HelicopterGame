using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollisions : MonoBehaviour
{
    // Allows enemies to pass through bounds
    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
           GetComponent<EdgeCollider2D>().enabled = false;
           StartCoroutine(EnableBox(1.0f));
        }
    }

    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<EdgeCollider2D>().enabled = true;
    }
}
