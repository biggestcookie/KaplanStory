using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeY;
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector2.right * -newPosition;
    }

}
