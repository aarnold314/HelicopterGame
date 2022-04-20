using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	[field: SerializeField] public float CurrentHealth { get; private set; }
	[field: SerializeField] public float MaxHealth { get; private set; }

	public UnityEvent onKilled;
	public UnityEvent<float> onDamageTaken;

	public void Damage(float damage)
	{
		// Calculates the real damage taken to pass to OnDamageTaken
		var oldHealth = CurrentHealth;
		CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);

		var heathDiff = oldHealth - CurrentHealth;
		onDamageTaken.Invoke(heathDiff);

		if (CurrentHealth <= 0)
		{
			Killed();
		}
	}

	public void Kill()
	{
		// Killing is equal to dealing the entire current health as damage
		onDamageTaken.Invoke(CurrentHealth);
		CurrentHealth = 0;
		Killed();
	}

	private void Killed()
	{
		onKilled.Invoke();
	}

	// Called when the component is reset to default values in the editor
	private void Reset()
	{
		MaxHealth = 50;
		CurrentHealth = MaxHealth;
	}
}