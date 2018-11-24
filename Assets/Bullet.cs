using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float speed;
    private float timeToLive;
    private int damageOnPlayer;
    private int damageOnBase;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeToLive);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        // Si on touche le joueur ou la base, on applique les dégats à l'entité touchée
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Joueur touché !");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(damageOnPlayer);
        }
        else if (other.tag.Equals("Base"))
        {
            Debug.Log("Base touchée !");
            //GameObject.FindGameObjectWithTag("Base").GetComponent<BaseHealth>().TakeDamage(damageOnBase);
        }

        // Si la balle touche un obstacle on la détruit
        // Attention : si l'objet touché est l'arme de l'ennemi en elle-même, on ne la détruit pas
        if (!other.name.Equals("Weapon"))
            Destroy(gameObject);
    }
}
