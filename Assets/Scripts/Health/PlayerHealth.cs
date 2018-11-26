using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : Health
{
	public Slider healthSlider;
    public Animator anim;

    void Awake()
	{
		startingHealth = 200;
        findHealthSlider();

        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
	}
    
	public new void TakeDamage(int amount)
	{
		base.TakeDamage(amount);

        findHealthSlider();
        healthSlider.value = currentHealth;
        
		if (currentHealth <= 0)
		{
			Debug.Log("You jut die");
            anim.SetTrigger("Death");
            
            isDead = true;
            
		}
    }

    void findHealthSlider ()
    {
        if (healthSlider == null)
        {
            GameObject go = GameObject.Find("PlayerHealthSlider");
            if (go != null)
            {
                healthSlider = go.GetComponent<Slider>();
            }
        }
    }
}
