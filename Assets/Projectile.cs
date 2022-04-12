using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float damage;
	public float radius;

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log($"Projectile hit {collision.gameObject.name}");
		// TODO: check if collider has HP, if it does, then apply damage
		// Also figure out how to do a radius (raycasting?)
	}
}
