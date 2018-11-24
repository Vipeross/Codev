using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAI : MonoBehaviour {

    public GameObject weaponFireStart;
    public GameObject weapon;

    protected Enemy enemy;
    protected GameObject objective;
    protected GameObject player;
    protected GameObject basement;

    private float timeSinceLastFire = 0.0f;
    private GameObject bullet;
    
    private NavMeshAgent agent;

    // Use this for initialization
    protected void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        basement = GameObject.FindGameObjectWithTag("Base");
        enemy = gameObject.GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	protected void Update () {
        chooseObjective();
        movement();
        fire();
    }

    public abstract void chooseObjective ();

    void movement ()
    {
        transform.LookAt(objective.GetComponent<Collider>().bounds.center);
        weapon.transform.LookAt(objective.GetComponent<Collider>().bounds.center);

        // Si on est à distance de shoot l'objectif, on arrête de bouger
        if (Vector3.Distance(transform.position, objective.transform.position) < enemy.shootingRange)
            agent.destination = transform.position;

        // Sinon on va vers l'objectif
        else
            agent.destination = objective.transform.position;
    }

    void fire ()
    {
        timeSinceLastFire += Time.deltaTime;

        // Si on est à distance pour shooter et que notre fire rate est ok
        if (Vector3.Distance(transform.position, objective.transform.position) < enemy.shootingRange && timeSinceLastFire >= enemy.fireRate)
        {
            Debug.Log("fire");
            Instantiate(enemy.bulletPrefab, weaponFireStart.transform.position, weapon.transform.rotation);

            timeSinceLastFire = 0.0f;
        }
    }
}
