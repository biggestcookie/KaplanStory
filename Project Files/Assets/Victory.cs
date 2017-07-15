using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour {

    public AudioClip[] audioClip;
    public GUIText victory;
    private AudioSource audioSource;
    public GameObject screen;
    private void Start()
    {
        victory.text = "";
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            victory.text = "Boss Level Approaching!";
            Instantiate(screen);
            PlaySound(0);
            Invoke("NextScene", 3.0f);
        }

    }
    void PlaySound(int clip)
    {
        audioSource.clip = audioClip[clip];
        audioSource.Play();
    }
    public void NextScene()
    {
        SceneManager.LoadScene("Stage2");
    }
}
