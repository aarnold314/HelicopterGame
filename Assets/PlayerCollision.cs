using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        Debug.Log(collisionInfo.collider.name);
    }
}
