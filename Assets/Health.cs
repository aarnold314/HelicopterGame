using UnityEngine;

public class Health : MonoBehaviour
{
	[field: SerializeField] public float CurrentHealth { get; private set; }
	[field: SerializeField] public float MaxHealth { get; private set; }

	public void Damage(float damage)
	{
		CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);

		if (CurrentHealth <= 0)
		{
			Killed();
		}
	}

	private void Killed()
	{
		Destroy(gameObject);
	}
}
