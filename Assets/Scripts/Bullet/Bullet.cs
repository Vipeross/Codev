using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    protected float speed;
    protected float timeToLive;
    protected int damageOnPlayer;
    protected int damageOnBase;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeToLive);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    protected virtual void OnTriggerEnter(Collider other)
    {
        // Si on touche le joueur ou la base, on applique les dégats à l'entité touchée
        if (other.tag.Equals("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(damageOnPlayer);
        }
        else if (other.tag.Equals("Base"))
        {
            GameObject.FindGameObjectWithTag("Base").GetComponent<BaseHealth>().TakeDamage(damageOnBase);
        }

        // Si la balle touche un obstacle on la détruit
        // Attention : si l'objet touché est l'arme de l'ennemi en elle-même, on ne la détruit pas
        if (!other.name.Equals("Weapon"))
        {
            Destroy(gameObject);
        }
    }
}
