using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {
    Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);
        if (Input.GetButtonDown("Fire1")) {
            player.OnJumpInputDown();
        }
        if (Input.GetButtonUp("Fire1")) {
            player.OnJumpInputUp();
        }
        /*if(Input.GetButton("Fire1")) {
            player.OnMousePress();
        }*/
    }
}
