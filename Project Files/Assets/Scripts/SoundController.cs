using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public static AudioClip jeffhit, jeffshoot, jeffdeath;
    static AudioSource audioSrc;

    private void Start()
    {
        jeffhit = Resources.Load<AudioClip>("jeffhit");
        jeffshoot = Resources.Load<AudioClip>("jeffshoot");
        jeffdeath = Resources.Load<AudioClip>("jeffdeath");
        audioSrc = GetComponent<AudioSource>();
    }
    
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "jeffhit":
                audioSrc.PlayOneShot(jeffhit);
                break;
            case "jeffshoot":
                audioSrc.PlayOneShot(jeffshoot);
                break;
            case "jeffdeath":
                audioSrc.PlayOneShot(jeffdeath);
                break;
        }
    }
}
