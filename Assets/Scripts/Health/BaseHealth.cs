using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : Health {
	public Slider healthSlider;

	// Use this for initialization
	void Start () {
		startingHealth = 1000;
		currentHealth = startingHealth;
		// Problème : Mon slider ne se trouve pas directement dans mon GameObject, je le cherche donc
		if (healthSlider == null)
		{
			GameObject go = GameObject.Find("BaseHealthSlider");
			if (go != null)
			{
				healthSlider = go.GetComponent<Slider>();
			}
		}
	}

	public new void TakeDamage(int amount)
	{
		base.TakeDamage(amount);
		healthSlider.value = currentHealth;
        
		if (currentHealth <= 0)
		{
			isDestroyed = true;
		}
	}
}
