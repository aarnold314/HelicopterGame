using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Type")]
public class WeaponType : ScriptableObject
{
	public float attackSpeed = 1;
	public float damageMult = 1;
	public float projectileSpeed = 100;

	// Times each upgrade has been applied
	public SerializableDictionary<WeaponUpgrade.UpgradeType, int> upgradesApplied =
		new SerializableDictionary<WeaponUpgrade.UpgradeType, int>();

	private void Awake()
	{
		if (!upgradesApplied.ContainsKey(WeaponUpgrade.UpgradeType.AttackDamage))
		{
			upgradesApplied.Add(WeaponUpgrade.UpgradeType.AttackDamage, 0);
		}

		if (!upgradesApplied.ContainsKey(WeaponUpgrade.UpgradeType.AttackSpeed))
		{
			upgradesApplied.Add(WeaponUpgrade.UpgradeType.AttackSpeed, 0);
		}

		if (!upgradesApplied.ContainsKey(WeaponUpgrade.UpgradeType.ProjectileSpeed))
		{
			upgradesApplied.Add(WeaponUpgrade.UpgradeType.ProjectileSpeed, 0);
		}
	}

	public const int MaxUpgradesApplied = 3;

	[SerializeField] private GameObject projectilePrefab;

	public void Fire(Vector3 spawnPos, Vector3 targetPos)
	{
		var spawned = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

		// Get the normalized difference between the current position and the target position as a direction
		// Then multiply by the projectile speed to get the target speed
		var projVecNormal = (targetPos - spawnPos).normalized;
		var targetVelocity = projectileSpeed * projVecNormal;

		spawned.GetComponent<Rigidbody2D>().AddForce(targetVelocity, ForceMode2D.Impulse);

		var proj = spawned.GetComponent<Projectile>();
		proj.damage *= damageMult;
	}
}