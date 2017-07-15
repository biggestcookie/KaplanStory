using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genji : MonoBehaviour {
    public GameObject explosion;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) return;
        if (explosion != null)
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
        }
        if (other.CompareTag("Shot"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);

    }

}
