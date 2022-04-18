using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    // reference to player
    public Transform player;
    // reference to text
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        // gets the units traveled in the x direction by player
        if(player.position.x >= 0)
        {
        scoreText.text = player.position.x.ToString("0");
        }


    }
}
