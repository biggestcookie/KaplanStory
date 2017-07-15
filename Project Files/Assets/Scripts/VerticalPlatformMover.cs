using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatformMover : MonoBehaviour {
    public float speed, yMax, yMin;
    private void Update()
    {
        Vector3 movement = Vector3.up * speed * Time.deltaTime;
        transform.Translate(movement);
    }

}
