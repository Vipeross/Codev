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

    public GameObject HUD;
	public Text enemyCount;
	public GameObject screenPanel;
	public Text finalText;

	// Use this for initialization
	void Start()
    {
        // UI
        HUD.SetActive(true);
        enemyCount = GameObject.Find("EnemyCount").GetComponent<Text>();
        baseObject = GameObject.FindGameObjectWithTag("Base");
        playerObject = GameObject.FindGameObjectWithTag("Player");

        SwitchCursor(false);

        numberOfSpawns = GameObject.FindGameObjectsWithTag("Respawn").Length;
        numberOfEnemyPrefab = EnemyPrefabs.Length;
	}

    // Update is called once per frame
    void Update()
    {
        // Gestion de la souris
        if (Input.GetKey(KeyCode.Escape))
			SwitchCursor(true);
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && Cursor.lockState != CursorLockMode.Locked && Cursor.visible == true)
			SwitchCursor(false);

        spawn();

        // Nombre d'ennemis restants
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        enemyCount.text = "Ennemis Restant : " + enemiesLeft;

        // Gestion de la vie de la base et du joueur
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
