using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public Canvas Main;
    public Canvas Help;
    private void Awake()
    {
        Help.enabled = false;
    }
    public void HelpOn()
    {
        Help.enabled = true;
        Main.enabled = false;
    }
    public void LoadOn()
    {
        SceneManager.LoadScene("Intro");
    }
    public void Return()
    {
        Help.enabled = false;
        Main.enabled = true;
    }
}
