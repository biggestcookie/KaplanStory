using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {
    public GameObject explosion;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) return;
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
