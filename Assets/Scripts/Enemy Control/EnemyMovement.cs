using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float frequency = 5f;
	[SerializeField] private float magnitude = 5f;

	// [SerializeField] float shootingFrequency = 0.5f;

	public Vector2 speed = new Vector2(10, 10);
	public bool hit = false;

	private Rigidbody2D rigidbodyComponent;
	private const string cameraTag = "MainCamera";
	private const string playerTag = "Player";

	// Weapons
	//private WeaponType _weapon;
	private float _weaponCooldown;
	private const int leftClickButton = 0;

	public GameObject projectile;
	public float launchVelocity = 700f;

	private void Awake()
	{
		rigidbodyComponent = GetComponent<Rigidbody2D>();
		rigidbodyComponent.freezeRotation = true;
		//_weapon = Instantiate(helicopterData.availableWeapons[helicopterData.activeWeaponIdx], transform, false);
		//StartCoroutine("AutoShoot");
	}

	// // enemy shooting
	// void Update()
	// {
	// 	var click = Input.GetMouseButtonDown(leftClickButton);
	// 	var mouseScreenPos = Input.mousePosition;
	// 	// Vector3 targetPos = new Vector3(10f,0f,0f);
	// 	// enemy.Fire(transform.position, targetPos);

	// 	// GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
    //     // ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity,0));
	// }

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
		// Allows enemy to pass through screen boundary
		if (collisionInfo.collider.tag == cameraTag)
		{
			GetComponent<BoxCollider2D>().enabled = false;
			StartCoroutine(EnableBox(1.0f));
		}
		// kills when they collide
		if (collisionInfo.collider.tag == playerTag)
		{
			rigidbodyComponent.freezeRotation = false;
			GetComponent<BoxCollider2D>().enabled = false;
			hit = true;
		}
	}

	// Waiter
	IEnumerator EnableBox(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		GetComponent<BoxCollider2D>().enabled = true;
	}
}