using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	[SerializeField] private Health health;

	private const string enemyTag = "Enemy";

	private void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		// Kill the player if they collide with an enemy
		if (collisionInfo.collider.CompareTag(enemyTag))
		{
			health.Kill();
		}
	}
}