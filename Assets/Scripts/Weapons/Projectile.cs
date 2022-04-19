using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float damage;
	public float radius;

	private Collider2D _selfCollider;

	// TODO: Kill projectile when offscreen/time

	private void Start()
	{
		_selfCollider = GetComponent<Collider2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
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
				if (explosionCollider.GetComponent<Collider2D>() == _selfCollider)
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
		// It's okay to hit a non-Health object
		if (collided.TryGetComponent<Health>(out var health))
		{
			health.Damage(damage);
		}
	}
}