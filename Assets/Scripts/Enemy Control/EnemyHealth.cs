using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public void OnDamageTaken(float damage) {}

	public void OnKilled()
	{
		Destroy(gameObject);
	}
}