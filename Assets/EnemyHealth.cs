using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

	// Use this for initialization
	void Start () {
		startingHealth = 100;
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public new void TakeDamage(int amount)
	{
		base.TakeDamage(amount);

		if (currentHealth <= 0)
		{
			Debug.Log("You kill this enemy");
			Destroy(gameObject);
		}
	}
}
