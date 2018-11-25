using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{

    public GameObject[] EnemyPrefabs = new GameObject[4];

    private float spawnFrequency = 10.0f;
    private float timeSinceLastSpawn = 0.0f;
    private int numberOfSpawns;
    private int numberOfEnemyPrefab;
    private int enemiesLeft = 0;

	private GameObject baseObject;
	private GameObject playerObject;

	public Text enemyCount;
	public GameObject screenPanel;
	public Text finalText;

	// Use this for initialization
	void Start()
    {
        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/

        numberOfSpawns = GameObject.FindGameObjectsWithTag("Respawn").Length;
        numberOfEnemyPrefab = EnemyPrefabs.Length;

        enemyCount = GameObject.Find("EnemyCount").GetComponent<Text>();
		screenPanel.SetActive(false);
		baseObject = GameObject.FindGameObjectWithTag("Base");
		playerObject = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.Escape)) {
			SwitchCursor(true);
        }
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && Cursor.lockState != CursorLockMode.Locked && Cursor.visible == true)
        {
			SwitchCursor(false);
        }*/

        spawn();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        enemyCount.text = "Ennemis Restant : " + enemiesLeft;
		if (baseObject.GetComponent<BaseHealth>().Destroyed())
			GameOver("Base détruite");
		else if (playerObject.GetComponent<PlayerHealth>().Dead())
			GameOver("Joueur mort");

	}

	void SwitchCursor(bool flag)
	{
		Cursor.visible = flag;
		Cursor.lockState = (flag) ? CursorLockMode.None : CursorLockMode.Locked;
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

	void GameOver(string who)
	{
		Time.timeScale = 0;
		screenPanel.SetActive(true);
		finalText.text = "Défaite\n" + who;
		SwitchCursor(true);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
