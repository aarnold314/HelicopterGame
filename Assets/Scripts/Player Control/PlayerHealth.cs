using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

	public GameObject player;
	[SerializeField] private InputController playerMovement;
	[SerializeField] private GameObject explosionEffect;
	[SerializeField] private GameManager gameManager;
	[SerializeField] private Health health;
	public Slider healthSlider;
	private bool dead = false;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Return) && dead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
	public void OnDamageTaken(float damage)
	{
		healthSlider.value = health.CurrentHealth / health.MaxHealth;
	}

	public void OnKilled()
	{
		// Disable the player movement when killed and go to game over
		playerMovement.enabled = false;
		health.enabled = false;
		dead = true;
		healthSlider.value = 0;

		player.GetComponent<BoxCollider2D>().enabled = false;

		// Spawn an explosion when the player dies
		var explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
		explosionEffectIns.SetActive(true);
		explosionEffectIns.transform.localScale = new Vector2(10f, 10f);
		explosionEffectIns.transform.Translate(0, 70f, 0);
		Destroy(explosionEffectIns, 3);

		gameManager.GameOver();
	}
}