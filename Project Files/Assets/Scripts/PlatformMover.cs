using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {
    public float speed, xMax, xMin;
    private float direction = 1;
    private void Update()
    {
        if (transform.position.x > xMax)
            direction = -1;
        else if (transform.position.x < xMin)
            direction = 1;
        Vector3 movement = Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }

}
