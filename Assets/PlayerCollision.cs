using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // creates reference to player movement script 
    public PlayerMovement movement;

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            // currently disables player movement when it collides with an enemy
            // change to an explosion graphic
           // movement.enabled = false;
        }
    }
}
