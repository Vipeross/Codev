using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBehaviour : MonoBehaviour {

    public GameObject weapon;
    public LineRenderer line;

    private float fireRate = 1.0f;
    private float timeSinceLastShoot = 0.0f;
    private int damage = 50;
	
	// Update is called once per frame
	void Update () {
        timeSinceLastShoot += Time.deltaTime;
        RaycastHit hit;
        
        if (Input.GetMouseButton(0) && timeSinceLastShoot > fireRate)
        {
            Ray shoot = new Ray(weapon.transform.position, weapon.transform.forward);
            //Debug.DrawRay(shoot.origin, shoot.direction * 10.0f, Color.red);

            if(Physics.Raycast(shoot,out hit))
            {
                GameObject target = hit.collider.gameObject;
                Debug.Log("target : " + target.tag + " name : " + target.name);
                if(target.tag == "Enemy")
                    target.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

            timeSinceLastShoot = 0.0f;
        }
        
	}
}
