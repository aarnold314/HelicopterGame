using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float damage;
	public float radius;

	private Collider2D _selfCollider;
	private Renderer _renderer;

	[SerializeField] private GameObject explosionEffect;

	private void Start()
	{
		_selfCollider = GetComponent<Collider2D>();
		_renderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		// Delete when offscreen
		if (!_renderer.isVisible)
		{
			Destroy(gameObject);
		}
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
			var explosionColliders = Physics2D.OverlapCircleAll(contact.point, radius);
			foreach (var explosionCollider in explosionColliders)
			{
				if (explosionCollider == _selfCollider)
				{
					continue;
				}

				CollideWithGameObject(explosionCollider.gameObject);
				var explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
				explosionEffectIns.SetActive(true);
				explosionEffectIns.transform.localScale *= new Vector2(radius, radius);
				explosionEffectIns.transform.Translate(0, 20f, 0);
				Destroy(explosionEffectIns, 1);
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