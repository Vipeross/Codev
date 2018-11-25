using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBehaviour : MonoBehaviour {

    public GameObject weapon;
    private float fireRate;
    private float delay;
    public LineRenderer line;
    


	// Use this for initialization
	void Start () {
        fireRate = 1.0f;
        delay = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {
        delay+= Time.deltaTime;
        RaycastHit hit;
        
        if (Input.GetMouseButton(0) && delay > fireRate)
        {
            
            Debug.Log("ça tire");
            Ray shoot = new Ray(weapon.transform.position, weapon.transform.forward);
            Debug.DrawRay(shoot.origin, shoot.direction * 10.0f, Color.red);
            
            

            if(Physics.Raycast(shoot,out hit))
            {
                
                GameObject target = hit.collider.gameObject;
                if(target.tag == "Enemy")
                {
                    Destroy(target);
                }
             
            }

            delay = 0.0f;
        }
        
	}
}
