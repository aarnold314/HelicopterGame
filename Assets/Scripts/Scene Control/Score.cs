using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    // reference to player
    public Transform player;
    public Text scoreText;
    // public Slider slider;

    // public Health health;
    // public GameObject heli;

    // Update is called once per frame
    void Update()
    {
        // gets the units traveled in the x direction by player
        if(player.position.x >= 0)
        {
        scoreText.text = player.position.x.ToString("0");
        }

        // Trying to grab health of player
        // health = heli.GetComponent<Health>();
        // Debug.Log(health);
        // slider.value = health.CurrentHealth;
    }
}
