using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boop : MonoBehaviour {
    CircleCollider2D circleRadius;
    public float scale;
    public float maxSize;
    private void Start()
    {
        circleRadius = GetComponent<CircleCollider2D>();
        circleRadius.radius = .0001f;
    }
    private void Update()
    {
        circleRadius.radius *= scale;
        if (circleRadius.radius > maxSize)
            Destroy(gameObject);
    }
}
