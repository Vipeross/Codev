using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	protected int startingHealth;
	protected int currentHealth;
	protected bool isDestroyed;
	protected bool isDead;

	// Use this for initialization
	void Start () {
		isDestroyed = false;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
	}

	public bool Destroyed()
	{
		return isDestroyed;
	}

	public bool Dead()
	{
		return isDead;
	}
}
