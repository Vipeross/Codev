using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : Health
{
	public Slider healthSlider;

    void Awake()
	{
		startingHealth = 200;
		// Problème : Mon slider ne se trouve pas directement dans mon GameObject, je le cherche donc
		if (healthSlider == null)
		{
			GameObject go = GameObject.Find("PlayerHealthSlider");
			if (go != null)
			{
				healthSlider = go.GetComponent<Slider>();
			}
		}

		currentHealth = startingHealth;
	}
    
	public new void TakeDamage(int amount)
	{
		base.TakeDamage(amount);
		healthSlider.value = currentHealth;

        Debug.Log("Damage taken : " + amount + " / Health remaining : " + currentHealth);

		if (currentHealth <= 0)
		{
			Debug.Log("You jut die");
			isDead = true;
		}
    }
}
