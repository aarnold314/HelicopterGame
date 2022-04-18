using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float frequency = 5f;

    [SerializeField] 
    private float magnitude = 5f;

    [SerializeField] 
    private float offset = 0f;

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction;

    private Vector2 movement;
    private Vector2 startPosition;

    private Rigidbody2D rigidbodyComponent;


    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        direction = new Vector2(-1, Mathf.Sin(Time.time * frequency + offset) * magnitude);
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
        //transform.position = startPosition + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // Apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }

    
}
