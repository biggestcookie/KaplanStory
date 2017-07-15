using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {
    public GUIText text;
    public GUIText nexttext;
    private bool si;
    private void Start()
    {
        text.text = "";
        nexttext.text = "";
        Invoke("Thanks", 5.0f);
        si = false;
    }
    private void Update()
    {
        if (Input.GetButtonUp("Fire1") && si)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    void Thanks()
    {
        si = true;
        text.text = "Thanks for playing!";
        nexttext.text = "Press Space to return to Main Menu";
    }

}
