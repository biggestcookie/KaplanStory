using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private void Awake()
    {
        GetComponent<Camera>().orthographicSize = Screen.height / 2;
    }

}
