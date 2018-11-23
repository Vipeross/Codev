using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyAI : MonoBehaviour {

    public GameObject weaponFireStart;
    public GameObject weapon;
    public GameObject bulletPrefab;

    private float shootingRange = 5.0f;
    private float fireRate = 1.0f;
    private float timeSinceLastFire = 0.0f;
    private GameObject bullet;

    private GameObject objective;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        objective = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        movement();
        fire();
    }

    void movement ()
    {
        transform.LookAt(objective.GetComponent<Collider>().bounds.center);

        if (Vector3.Distance(transform.position, objective.transform.position) < shootingRange)
            agent.destination = transform.position;
        else
            agent.destination = objective.transform.position;
    }

    void fire ()
    {
        timeSinceLastFire += Time.deltaTime;

        if (Vector3.Distance(transform.position, objective.transform.position) < shootingRange && timeSinceLastFire >= fireRate)
        {

            Instantiate(bulletPrefab, weaponFireStart.transform.position, weapon.transform.rotation);

            timeSinceLastFire = 0.0f;
        }
    }
}
