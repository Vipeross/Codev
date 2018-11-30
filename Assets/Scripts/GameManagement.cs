using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class GameManagement : MonoBehaviour
{

    public GameObject[] EnemyPrefabs = new GameObject[4];
    private float timeSinceLastSpawn = 0.0f;
    private int numberOfSpawns;
    private int numberOfEnemyPrefab;
    private int enemiesTotal = 0;
    private int enemiesLeft = 0;
    private int waveNumber = 1;
    private float rate;

    private GameObject baseObject;
	private GameObject playerObject;

    public GameObject HUD;
	public Text enemyCount;
    public Text waveHUD;
	public GameObject screenPanel;
	public Text finalText;
    public int waves;

    Random rdn;
	// Use this for initialization
	void Start()
    {
        Time.timeScale = 1.0f;
        // UI
        HUD.SetActive(true);
        enemyCount = GameObject.Find("EnemyCount").GetComponent<Text>();
        waveHUD = GameObject.Find("Wave").GetComponent<Text>();
        baseObject = GameObject.FindGameObjectWithTag("Base");
        playerObject = GameObject.FindGameObjectWithTag("Player");

        SwitchCursor(false);

        numberOfSpawns = GameObject.FindGameObjectsWithTag("Respawn").Length;
        numberOfEnemyPrefab = EnemyPrefabs.Length;
        rate = 20.0f;
        enemiesTotal = 3 * waveNumber + Random.Range(0, waveNumber / 2);
        enemiesLeft = enemiesTotal;
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
        enemyCount.text = "Ennemis Restants : " + enemiesLeft + "/" + enemiesTotal;
        waveHUD.text = "Vague " + waveNumber;
        rate = 1.0f / (0.05f * waveNumber);
        if (rate > 10)
            rate = 10.0f;

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
        
        if (timeSinceLastSpawn >= rate && enemiesLeft > 0)
        {
            int chosenSpawn = Random.Range(0, numberOfSpawns);
            int chosenEnemyPrefab = Random.Range(0, numberOfEnemyPrefab);

            GameObject spawner = GameObject.FindGameObjectsWithTag("Respawn")[chosenSpawn];
            Instantiate(EnemyPrefabs[chosenEnemyPrefab], spawner.transform.position, spawner.transform.rotation);

            timeSinceLastSpawn = 0;
            enemiesLeft--;
        }
        if (enemiesLeft == 0 && waveNumber <= waves)
        {
            waveNumber++;
            enemiesTotal = 3 * waveNumber + Random.Range(0, waveNumber/2);
            enemiesLeft = enemiesTotal;
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
