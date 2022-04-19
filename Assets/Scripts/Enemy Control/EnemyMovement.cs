using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float frequency = 5f;

    [SerializeField] 
    private float magnitude = 5f;

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction;
    public PlayerMovement playerMovement;
    public bool hit = false;

    private Vector2 movement;
    private Vector2 startPosition;

    private Rigidbody2D rigidbodyComponent;


    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        direction = new Vector2(-1, Mathf.Sin(Time.time * frequency) * magnitude);
       if (hit)
       {
           movement = new Vector2(0,0);
       } else{
           movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
       }
        
        //transform.position = startPosition + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // Apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "MainCamera")
        {
           GetComponent<BoxCollider2D>().enabled = false;
           StartCoroutine(EnableBox(1.0f));
        }
        if (collisionInfo.collider.tag == "Player")
        {
            hit = true;
        }
    }

    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
