using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float frequency = 5f;
	[SerializeField] private float magnitude = 5f;

	public Vector2 speed = new Vector2(10, 10);
	public bool hit = false;

	private Rigidbody2D rigidbodyComponent;
	private const string cameraTag = "MainCamera";
	private const string playerTag = "Player";

	private void Awake()
	{
		rigidbodyComponent = GetComponent<Rigidbody2D>();
		rigidbodyComponent.freezeRotation = true;
	}

	private void FixedUpdate()
	{
		// Enemy move path
		var direction = new Vector2(-1, Mathf.Sin(Time.time * frequency) * magnitude);
		Vector2 movement;
		// Removes enemy movement after collision
		if (hit)
		{
			movement = new Vector2(0, 0);
			Destroy(this);
		}
		else
		{
			movement = new Vector2(
				speed.x * direction.x,
				speed.y * direction.y
			);
		}

		// Apply movement to the rigidbody
		rigidbodyComponent.velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.collider.tag == cameraTag)
		{
			GetComponent<BoxCollider2D>().enabled = false;
			StartCoroutine(EnableBox(1.0f));
		}

		if (collisionInfo.collider.tag == playerTag)
		{
			rigidbodyComponent.freezeRotation = false;
			GetComponent<BoxCollider2D>().enabled = false;
			hit = true;
		}
	}

	IEnumerator EnableBox(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		GetComponent<BoxCollider2D>().enabled = true;
	}
}