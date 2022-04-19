using UnityEngine;

public class AttackController : MonoBehaviour
{
	[SerializeField] private HelicopterData helicopterData;

	// Set in the constructor using the data from helicopterData
	private WeaponType _weapon;
	
	private float _weaponCooldown;

	private const int leftClickButton = 0;

	private void Start()
	{
		Debug.LogWarning("TODO: merge this and the movement controller into a general InputController");
		_weapon = Instantiate(helicopterData.availableWeapons[helicopterData.activeWeaponIdx], transform, false);
		Debug.Log($"weapon stats: {_weapon.attackSpeed} {_weapon.damageMult} {_weapon.projectileSpeed}");
	}

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
		if (click)
		{
			_weapon.Fire(transform.position, targetPos);
			_weaponCooldown = 1 / _weapon.attackSpeed;
		}
	}
}