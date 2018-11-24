using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBehaviour : MonoBehaviour {

    public GameObject weapon;
    private float fireRate;
    private float delay;


	// Use this for initialization
	void Start () {
        fireRate = 1.0f;
        delay = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {
        delay+= Time.deltaTime;
        
		if(Input.GetMouseButton(0) && delay > fireRate)
        {
            Debug.Log("ça tire");
            delay = 0.0f;
        }
	}
}
