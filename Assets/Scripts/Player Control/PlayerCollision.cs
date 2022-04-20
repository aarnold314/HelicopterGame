using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // creates reference to player movement script 
    public PlayerMovement movement;
    public GameObject explosionEffect;
    

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {

            float inputX = Input.GetAxis("Horizontal");
		    float inputY = Input.GetAxis("Vertical");
            
            // currently disables player movement when it collides with an enemy
            // change to an explosion graphic
           movement.enabled = false;
           
        //    explosionEffect.SetActive(true);
        //    explosionEffect.transform.position = new Vector2(inputX,inputY);
            GameObject explosionEffectIns = Instantiate(explosionEffect,transform.position,Quaternion.identity);
            explosionEffectIns.SetActive(true);
            explosionEffectIns.transform.localScale = new Vector2(10f,10f);
            explosionEffectIns.transform.Translate(0,70f,0);
            Destroy(explosionEffectIns,3);

           FindObjectOfType<GameManager>().GameOver();

        }
    }
}
