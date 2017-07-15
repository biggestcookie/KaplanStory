using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Images : MonoBehaviour {
    public GameObject[] image;
    int counter = 0;
    private void Start()
    {
        Instantiate(image[counter]);
    }
    private void Update()
    {
        if (Input.GetButtonUp("Fire1") && counter < 11)
        {
            counter++;
            Instantiate(image[counter]);
        }
            
    }
}
