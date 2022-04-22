using UnityEngine;

public class Token : MonoBehaviour
{
	[SerializeField] private SaveManager saveManager;

	void OnTriggerEnter2D(Collider2D c2d)
	{
		//Destroy the coin if Object tagged Player comes in contact with it
		if (c2d.CompareTag("Player"))
		{
			//Add coin to counter
			saveManager.Tokens += 1;

			//Destroy coin
			Destroy(gameObject);
		}
	}
}