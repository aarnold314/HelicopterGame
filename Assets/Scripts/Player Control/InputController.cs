using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
	private Rigidbody2D rigidbodyComponent;

    [SerializeField] private HelicopterData helicopterData;
	// Set in the constructor using the data from helicopterData
	private WeaponType _weapon;
	private float _weaponCooldown;
	private const int leftClickButton = 0;

	private void Awake()
	{
		rigidbodyComponent = GetComponent<Rigidbody2D>();
	}

    private void Start()
	{
		_weapon = Instantiate(helicopterData.availableWeapons[helicopterData.activeWeaponIdx], transform, false);
		Debug.Log($"weapon stats: {_weapon.attackSpeed} {_weapon.damageMult} {_weapon.projectileSpeed}");
	}

    // Shooting aspect
	private void Update()
	{
		// Reduce cooldown for the weapon if it exists
		if (_weaponCooldown > 0)
		{
			_weaponCooldown -= Time.deltaTime;
			return;
		}

		var click = Input.GetMouseButtonDown(leftClickButton);
		var mouseScreenPos = Input.mousePosition;
		var targetPos = Camera.main!.ScreenToWorldPoint(mouseScreenPos);
		if (click || Input.GetKeyDown(KeyCode.Space))
		{
			_weapon.Fire(transform.position, targetPos);
			_weaponCooldown = 1 / _weapon.attackSpeed;
		}
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
		rigidbodyComponent.MovePosition(rigidbodyComponent.position + movement);
	}
}
