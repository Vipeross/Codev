using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : Health {
	public Image baseHealthBar;
	private Text baseBar;

	// Use this for initialization
	void Start () {
		baseBar = GameObject.Find("TextBaseBar").GetComponent<Text>();
		startingHealth = 1000;
		currentHealth = startingHealth;
		MajUI();
	}

	public new void TakeDamage(int amount)
	{
		base.TakeDamage(amount);
        
		if (currentHealth <= 0)
		{
			isDestroyed = true;
		}
		MajUI();
	}

	void MajUI()
	{
		baseHealthBar.fillAmount = (float)currentHealth / startingHealth;
		baseBar.text = currentHealth + " / " + startingHealth;
	}
}
