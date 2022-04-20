using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Vector2 speed = new Vector2(50, 50);

	private Rigidbody2D rigidbodyComponent;

	private void Awake()
	{
		rigidbodyComponent = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		// variables for x and y axis - Horizontal and Vertical vars are assigned by Unity
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		// multiplication of the axis for player movement
		var movement = new Vector2(speed.x * inputX, speed.y * inputY);

		// Scale by the time since the last FixedUpdate
		movement *= Time.fixedDeltaTime;

		// Apply movement to the rigidbody
		//rigidbodyComponent.velocity = movement;
		rigidbodyComponent.MovePosition(rigidbodyComponent.position + movement);
	}
}