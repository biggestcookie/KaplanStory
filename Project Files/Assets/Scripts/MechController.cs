using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMax, yMax, xMin, yMin;
}

public class MechController : MonoBehaviour
{
    public float speed, fireRate;
    float nextFire;
    public GameObject shot;
    public Transform gun;
    public Boundary boundary;
    public int healthCount;
    public GUIText restartText;
    public GameObject explosion;
    private Stage2Controller gameController;
    public GameObject bakuretsu;
    public AudioClip[] audioClip;
    private AudioSource audioSource;



    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<Stage2Controller>();
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax)
        );
        if (Input.GetButton("Fire1"))
        {
            speed = 2.0f;
            Fire();
        }
        else
            speed = 7;
    }
    void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, gun.position, gun.rotation);
            //GetComponent<AudioSource>().Play();
        }
    }
    void PlaySound(int clip)
    {
        audioSource.clip = audioClip[clip];
        audioSource.Play();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shot")) return;
        if (explosion != null)
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
        }
        gameController.decreaseHealth();
        Destroy(other.gameObject);
        if (gameController.playerHealth == 0)
        {
            Instantiate(bakuretsu, transform.position, transform.rotation);
            Destroy(gameObject);
            gameController.Invoke("GameOver",1.0f);
        }

    }

}