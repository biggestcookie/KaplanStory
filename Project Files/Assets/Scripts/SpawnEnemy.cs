using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    public Transform spawnPoint;
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            Destroy(gameObject);
        }
    }

}
