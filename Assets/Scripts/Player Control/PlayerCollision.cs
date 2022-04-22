using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	[SerializeField] private Health health;

	public GameObject failScreen;

	private const string enemyTag = "Enemy";
	private const string groundTag = "Ground";

	private void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		// Kill the player if they collide with an enemy
		if (collisionInfo.collider.CompareTag(enemyTag) || collisionInfo.collider.CompareTag(groundTag))
		{
			health.Kill();

			failScreen.SetActive(true);
		}
	}
}