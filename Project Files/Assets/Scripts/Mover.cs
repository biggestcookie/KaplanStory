using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Mover : MonoBehaviour {
    public float speed;
    Player player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if (player.direction)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
        }
    }
}
