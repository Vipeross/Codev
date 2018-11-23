using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float speed = 15.0f;
    private float timeToLive = 1.0f;

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
        if (other.tag.Equals("Player"))
            Debug.Log("Joueur touché !");

        if (!other.name.Equals("Weapon"))
            Destroy(gameObject);
    }
}
