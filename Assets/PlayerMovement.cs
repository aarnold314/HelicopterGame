using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public HeliController controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame - gets input from player
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;

    }

    // Called once every .02 seconds
    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    
    }
}
