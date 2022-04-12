using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float damage;
	public float radius;

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log($"Projectile hit {collision.gameObject.name}");

		var health = collision.gameObject.GetComponent<Health>();
		if (health == null)
		{
			// TODO: this warning is probably extra, here for debugging
			// the check and return MUST HAPPEN THOUGH
			Debug.LogWarning("projectile collided with non-health object");
			return;
		}
		
		health.Damage(damage);
		// TODO: figure out how to do a radius (raycasting?)
	}
}
