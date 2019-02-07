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
    private float waveDuration = 0.0f;
    private float gameTime = 0.0f;
    private int numberOfSpawns;
    private int numberOfEnemyPrefab;
    private int enemiesTotal = 0;
    private int enemiesLeft = 0;
    private int waveNumber = 0;
    private float rate;

    public float timeBeforeFirstWave;
    public GameObject timeBeforeFirstWaveText;
    public float advertDuration;
    private float timeBeforeHidingAdvert;
    public GameObject newWaveIncomingText;
    public AudioClip newWaveSound;

    private GameObject baseObject;
	private GameObject playerObject;

    public GameObject HUD;
    private Text enemyCount;
    private Text waveHUD;
    public GameObject screenPanel;
	public Text finalText;
    public GameObject waveTimer;
    public int waves;
    
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

        timeBeforeFirstWaveText.SetActive(true);

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

        BeforeFirstWave();
        AdvertManagement();

        spawn();

        // Gestion HUD
        string minutes = Mathf.Floor(gameTime / 60).ToString("00");
        string seconds = (gameTime % 60).ToString("00");
        enemyCount.text = "Spawn Ennemies Restant : " + enemiesLeft + "/" + enemiesTotal;
        waveHUD.text = "Vague " + waveNumber + "/" + waves;
        waveTimer.GetComponent<Text>().text = "Temps avant la prochaine vague : " + minutes + ":" + seconds;
        rate = 1.0f / (0.05f * waveNumber);
        if (rate > 10)
            rate = 10.0f;

        // Gestion de la vie de la base et du joueur
        if (baseObject.GetComponent<BaseHealth>().Destroyed())
			GameOver("Base détruite");
		else if (playerObject.GetComponent<PlayerHealth>().Dead())
			GameOver("Joueur mort");
	}

    void BeforeFirstWave ()
    {
        if (timeBeforeFirstWave > 0.0f)
        {
            timeBeforeFirstWave = Mathf.Max(0.0f, timeBeforeFirstWave - Time.deltaTime);
            timeBeforeFirstWaveText.GetComponent<Text>().text = "La partie commence dans " + Mathf.Floor(timeBeforeFirstWave) + "s !";
        }
        else
        {
            timeBeforeFirstWaveText.SetActive(false);

            if (waveNumber == 0)
                WaveUpdate();
        }
    }

    void AdvertManagement ()
    {
        if (timeBeforeHidingAdvert > 0.0f)
            timeBeforeHidingAdvert = Math.Max(0.0f, timeBeforeHidingAdvert - Time.deltaTime);
        else
        {
            newWaveIncomingText.SetActive(false);
        }
    }

    void ShowAdvert (GameObject toShow)
    {
        timeBeforeHidingAdvert = advertDuration;
        toShow.SetActive(true);
    }
    
    void SwitchCursor(bool flag)
	{
		Cursor.visible = flag;
		Cursor.lockState = (flag) ? CursorLockMode.None : CursorLockMode.Locked;
	}

    void spawn()
    {
        if (timeBeforeFirstWave == 0.0f)
        {
            timeSinceLastSpawn += Time.deltaTime;
            gameTime -= Time.deltaTime;

            if (timeSinceLastSpawn >= rate && enemiesLeft > 0)
            {
                int chosenSpawn = Random.Range(0, numberOfSpawns);
                int chosenEnemyPrefab = Random.Range(0, numberOfEnemyPrefab);

                GameObject spawner = GameObject.FindGameObjectsWithTag("Respawn")[chosenSpawn];
                Instantiate(EnemyPrefabs[chosenEnemyPrefab], spawner.transform.position, spawner.transform.rotation);

                timeSinceLastSpawn = 0;
                enemiesLeft--;
            }
            if (enemiesLeft == 0 && gameTime <= 0.1f)
            {
                if (waveNumber == waves)
                    Gamewin();
                else
                    WaveUpdate();
            }
        }
    }

    void Gamewin()
    {
        finalText.text = "Victoire !";
        finalText.color = Color.green;
        endGame();
    }

	void GameOver(string who)
	{
		finalText.text = "Défaite\n" + who;
        finalText.color = Color.red;
        endGame();
	}

    void endGame()
    {
        Time.timeScale = 0;
		screenPanel.SetActive(true);
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

    void WaveUpdate()
    {
        ShowAdvert(newWaveIncomingText);
        GetComponent<AudioSource>().PlayOneShot(newWaveSound);

        waveNumber++;

        enemiesTotal = 3 * waveNumber + Random.Range(0, waveNumber / 2);
        enemiesLeft = enemiesTotal;
        waveDuration = enemiesTotal * (Math.Max(8.0f, rate)) + 20;
        gameTime = waveDuration;
        rate = 1.0f / (0.05f * waveNumber);
        if (rate > 10)
            rate = 10.0f;
    }
}
