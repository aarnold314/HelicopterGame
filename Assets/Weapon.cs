using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private float attackSpeed;
	[SerializeField] private float damageMult;

	[SerializeField] private GameObject projectilePrefab;

	private float lastTime;

	private void Awake()
	{
		Debug.Log($"attached projectile: {projectilePrefab.name}");
	}

	// TODO: this is a test thing to demonstrate spawning things 
	private void Update()
	{
		const float spawnInterval = 2f;

		var currentTime = Time.time;
		if (currentTime - lastTime >= spawnInterval)
		{
			lastTime = currentTime;
			SpawnProjectile();
		}
	}

	private void SpawnProjectile()
	{
		var spawned = Instantiate(projectilePrefab);
	}
}
