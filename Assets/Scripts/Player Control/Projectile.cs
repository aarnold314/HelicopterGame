using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float damage;
	public float radius;

	private Collider selfCollider;

	private void Awake()
	{
		selfCollider = GetComponent<Collider>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		// No explosion when radius is small
		if (radius <= 0)
		{
			CollideWithGameObject(collision.gameObject);
		}
		else
		{
			var contact = collision.GetContact(0);
			// OverlapSphere gets **all** colliders in the sphere, including this projectile's collider, make sure to skip it
			var collisionsInSphere = Physics.OverlapSphere(contact.point, radius);
			foreach (var explosionCollider in collisionsInSphere)
			{
				if (explosionCollider == selfCollider)
				{
					continue;
				}

				CollideWithGameObject(explosionCollider.gameObject);
			}
		}

		Destroy(gameObject);
	}

	private void CollideWithGameObject(GameObject collided)
	{
		// It's okay to hit a non-Health object, just exit early
		var health = collided.GetComponent<Health>();
		if (health == null)
		{
			return;
		}

		health.Damage(damage);
	}
}