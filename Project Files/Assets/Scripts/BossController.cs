using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public AudioClip[] audioClip;
    public float dodge;
    public float smoothing;
    public float startDelay,waveWait;
    public float hazardCount;

    public float spawnWait;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    public GameObject bakuretsu;

    private float currentSpeed;
    private float targetManeuver;
    private Animator anim;
    private Rigidbody2D rb;
    public Transform gun;
    public GameObject shot;
    public GameObject explosion;
    private Stage2Controller gameController;
    private AudioSource audioSource;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = rb.velocity.y;
        StartCoroutine(Evade());
        StartCoroutine(Fire());
        anim = GetComponent<Animator>();
        gameController = GameObject.Find("GameController").GetComponent<Stage2Controller>();
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.y);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            PlaySound(0);
            anim.SetBool("shooting", true);
            for (int i = 0; i < hazardCount; i++)
            {
                Instantiate(shot, gun.position, gun.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            anim.SetBool("shooting", false);
            
            yield return new WaitForSeconds(waveWait);
            
        }
    }

    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.y, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector2(currentSpeed, newManeuver);
        rb.position = new Vector2
        (
            Mathf.Clamp(rb.position.x, -boundary.xMax, boundary.xMax),
            Mathf.Clamp(rb.position.y, -boundary.yMax, boundary.yMax)
        );
        anim.SetBool("hit", false);

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("hit", true);
        if (other.CompareTag("Enemy")) return;
        if (explosion != null)
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            
        }
        gameController.DecreaseBossHealth();
        Destroy(other.gameObject);
        
        if (gameController.bossHealth == 0)
        {
            Instantiate(bakuretsu, transform.position, transform.rotation);
            Destroy(gameObject);
            gameController.victory = true;
            gameController.Victory();
        }

        
    }
    void PlaySound(int clip)
    {
        audioSource.clip = audioClip[clip];
        audioSource.Play();
    }
}
