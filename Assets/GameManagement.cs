using UnityEngine;

public class GameManagement : MonoBehaviour {

    public GameObject EnnemyPrefab;

    private float spawnFrequency = 10.0f;
    private float timeSinceLastSpawn = 0.0f;
    private int numberOfSpawns;

	// Use this for initialization
	void Start () {
        numberOfSpawns = GameObject.FindGameObjectsWithTag("Respawn").Length;
    }
	
	// Update is called once per frame
	void Update () {
        spawn();
	}

    void spawn()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnFrequency)
        {
            int chosenSpawn = Random.Range(0, numberOfSpawns);

            GameObject spawner = GameObject.FindGameObjectsWithTag("Respawn")[chosenSpawn];
            Instantiate(EnnemyPrefab, spawner.transform.position, spawner.transform.rotation);

            timeSinceLastSpawn = 0;
        }
    }
}
