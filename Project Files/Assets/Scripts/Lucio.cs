using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lucio : MonoBehaviour {
    public float speed, xMax, xMin;
    private float direction = 1;
    SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (transform.position.x > xMax)
        {
            direction = -1;
            sprite.flipX = false;
        }
        else if (transform.position.x < xMin)
        {
            direction = 1;
            sprite.flipX = true;
        }
        Vector3 movement = Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
