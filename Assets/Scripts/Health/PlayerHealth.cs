using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : Health
{
	public Image playerHealthBar;
	private Text playerBar;

	void Awake()
	{
		playerBar = GameObject.Find("TextPlayerBar").GetComponent<Text>();
		startingHealth = 200;
		currentHealth = startingHealth;
		MajUI();
	}
    
	public new void TakeDamage(int amount)
	{
		base.TakeDamage(amount);
		
		if (currentHealth <= 0)
		{
            isDead = true;
		}
		MajUI();
	}

	void MajUI()
	{
		playerHealthBar.fillAmount = (float)currentHealth / startingHealth;
		playerBar.text = currentHealth + " / " + startingHealth;
	}
}
