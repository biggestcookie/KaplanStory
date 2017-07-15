using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Widowmaker : MonoBehaviour {
    public float fireRate, delay;
    public Transform gun;
    public GameObject shot;
    public AudioClip[] audioClip;
    private AudioSource audioSource;
    private Player player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        InvokeRepeating("Fire", delay, fireRate);
        audioSource = GetComponent<AudioSource>();
        PlaySound(0);
    }
    private void Update()
    {
        if (player != null)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist > 13)
                Destroy(gameObject);
        }
    }
    void Fire()
    {
        Instantiate(shot, gun.position, gun.rotation);
        PlaySound(1);
    }
    void PlaySound(int clip)
    {
        audioSource.clip = audioClip[clip];
        audioSource.Play();
    }

}
