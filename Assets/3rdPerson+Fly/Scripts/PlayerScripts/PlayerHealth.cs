using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public Slider healthSlider;

    private int startingHealth = 200;
    private int currentHealth;

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

		currentHealth = startingHealth;
	}
    
	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		healthSlider.value = currentHealth;

        Debug.Log("Damage taken : " + amount + " / Health remaining : " + currentHealth);

        if (currentHealth <= 0)
			Debug.Log("You jut die");
    }
}
