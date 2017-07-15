using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewScene : MonoBehaviour {
    private void Start()
    {
        Invoke("loadScene", 2.0f);
    }
    void loadScene()
    {
        SceneManager.LoadScene("Stage1");
    }
    
}
