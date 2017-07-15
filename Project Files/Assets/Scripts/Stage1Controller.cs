using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Controller : MonoBehaviour 
{
    public GUIText restartText;
    public float platformDelay, platformRate;
    public Transform platformSpawn;
    public GameObject platform;
    bool restart;
    private void Start()
    {
        restart = false;
        restartText.text = "";
        Time.timeScale = 1.0f;
        InvokeRepeating("SpawnPlatforms", platformDelay, platformRate);
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
    public void GameOver()
    {
        restart = true;
        Time.timeScale = 0.0f;
        restartText.text = "YOU ARE DEAD \n Press Space for Restart";
    }
    void SpawnPlatforms()
    {
        Instantiate(platform, platformSpawn.position, platformSpawn.rotation);
    }
}
