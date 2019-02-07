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
    protected NavMeshAgent agent;

    private float timeSinceLastFire = 0.0f;
    private GameObject bullet;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        basement = GameObject.FindGameObjectWithTag("Base");
        enemy = gameObject.GetComponent<Enemy>();

        chooseObjective();
    }
	
	// Update is called once per frame
	void Update () {
        chooseObjective();
        movement();
        fire();
    }

    public abstract void chooseObjective ();

    void movement ()
    {
        transform.LookAt(objective.GetComponent<Collider>().bounds.center);
        weapon.transform.LookAt(objective.GetComponent<Collider>().bounds.center);


        // Si on est à distance de shoot l'objectif
        if (Vector3.Distance(weaponFireStart.transform.position, objective.transform.position) < enemy.shootingRange)
        {

            agent.SetDestination(transform.position);

            RaycastHit hit;

            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(weaponFireStart.transform.position, objective.transform.position, out hit, enemy.shootingRange))
            {
                Debug.DrawLine(weaponFireStart.transform.position, objective.transform.position, Color.blue);
                Debug.Log("Did Hit : " + hit.collider.gameObject.name);
            }
            else
            {
                Debug.DrawLine(weaponFireStart.transform.position, objective.transform.position, Color.red);
                Debug.Log("Did not Hit : " + hit.collider.gameObject.name);
            }
        }

        // Sinon on va vers l'objectif
        else
            agent.SetDestination(objective.transform.position);
    }

    void fire ()
    {
        timeSinceLastFire += Time.deltaTime;

        // Si on est à distance pour shooter et que notre fire rate est ok
        if (Vector3.Distance(weaponFireStart.transform.position, objective.transform.position) < enemy.shootingRange && timeSinceLastFire >= enemy.fireRate)
        {
            Instantiate(enemy.bulletPrefab, weaponFireStart.transform.position, weapon.transform.rotation);

            timeSinceLastFire = 0.0f;
        }
    }
}
