using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Controller : MonoBehaviour {
    public float playerHealth, bossHealth;
    public Vector2 spawnWait;
    public GameObject explosion;
    public GameObject[] hazards;
    public GameObject healthBar;
    public GameObject bossHealthBar;
    public GUIText restartText,victoryText,perfectText;
    public Vector2 spawnValues;
    public bool victory;
    public AudioClip[] audioClip;
    float subtractBoss;
    float subtractPlayer;
    bool restart;
    GameObject hazard;
    private AudioSource audioSource;

    private void Start()
    {
        victory = false;
        restartText.text = "";
        victoryText.text = "";
        perfectText.text = "";
        Time.timeScale = 1.0f;
        subtractBoss = bossHealthBar.transform.localScale.x / bossHealth;
        subtractPlayer = healthBar.transform.localScale.x / playerHealth;
        audioSource = GetComponent<AudioSource>();
        PlaySound(0);
    }
    private void Update()
    {
        if (restart)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    void PlaySound(int clip)
    {
        audioSource.clip = audioClip[clip];
        audioSource.Play();
    }
    public void decreaseHealth()
    {
        playerHealth--;
        if (playerHealth >= 0)
        {
            healthBar.transform.localScale -= new Vector3(subtractPlayer, 0, 0);
        }
    }
    public void DecreaseBossHealth ()
    {
        bossHealth--;
        if (bossHealth == 70)
            PlaySound(1);
        else if (bossHealth == 60)
        {
            StartCoroutine(SpawnWaves());
            
        }
        else if (bossHealth >= 0)
        {
            bossHealthBar.transform.localScale -= new Vector3(subtractBoss, 0, 0);
        }

    }
    IEnumerator SpawnWaves()
    {
        while (true && victory == false)
        {
            if (bossHealth > 40)
            {
                hazard = hazards[0];
            }
            else if (bossHealth > 20 && bossHealth <= 40)
            {
                hazard = hazards[Random.Range(0, hazards.Length)];
            }
            else
                hazard = hazards[1];
            Vector2 spawnPosition = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(spawnWait.x, spawnWait.y));
        }
    }
    public void GameOver()
    {
        restart = true;
        Time.timeScale = 0.0f;
        restartText.text = "YOU ARE DEAD \n Press Space for Restart";
    }
    public void Victory()
    {
        if (playerHealth == 10)
        {
            perfectText.text = "Perfect!";
            Invoke("NextSceneVictory", 2.9f);

        }
        victoryText.text = "YOU ARE WINNER!";
        PlaySound(2);
        Invoke("NextScene", 3.0f);
    }
    public void NextScene()
    {
        SceneManager.LoadScene("Victory");
    }
    public void NextSceneVictory()
    {
        SceneManager.LoadScene("Victory2");
    }
}
