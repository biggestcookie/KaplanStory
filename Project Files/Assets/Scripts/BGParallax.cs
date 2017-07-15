using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGParallax : MonoBehaviour
{
    private Vector2 velocity;


    public float smoothTimeX,speed;

    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void LateUpdate()
    {
        if (player != null)
        {
            float posX = player.transform.position.x/speed;
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        }
    }

}
