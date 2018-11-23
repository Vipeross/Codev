using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth;
	public int currentHealth;
	public Slider healthSlider;
	public int attackValue;

	void Awake()
	{
		// Problème : Mon slider ne se trouve pas directement dans mon GameObject, je le cherche donc
		if (healthSlider == null)
		{
			GameObject go = GameObject.Find("HealthSlider");
			if (go != null)
			{
				healthSlider = go.GetComponent<Slider>();
			}
		}
		startingHealth = 200;
		attackValue = 10;
		currentHealth = startingHealth;
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			TakeDamage(attackValue);
		}
	}


	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		
		if (currentHealth <= 0)
		{
			Debug.Log("You jut die");
		}
	}
}
