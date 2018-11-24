using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {

    public GameObject[] EnemyPrefabs = new GameObject[4];

    private float spawnFrequency = 10.0f;
    private float timeSinceLastSpawn = 0.0f;
    private int numberOfSpawns;
    private int numberOfEnemyPrefab;
	private int enemiesLeft = 0;

	Text enemyCount;

    // Use this for initialization
    void Start () {
        numberOfSpawns = GameObject.FindGameObjectsWithTag("Respawn").Length;
        numberOfEnemyPrefab = EnemyPrefabs.Length;

		enemyCount = GameObject.Find("EnemyCount").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        spawn();
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		enemiesLeft = enemies.Length;
		enemyCount.text = "Ennemis Restant : " + enemiesLeft;
	}

    void spawn()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnFrequency)
        {
            int chosenSpawn = Random.Range(0, numberOfSpawns);
            int chosenEnemyPrefab = Random.Range(0, numberOfEnemyPrefab);

            GameObject spawner = GameObject.FindGameObjectsWithTag("Respawn")[chosenSpawn];
            Instantiate(EnemyPrefabs[chosenEnemyPrefab], spawner.transform.position, spawner.transform.rotation);

            timeSinceLastSpawn = 0;
        }
    }
}
