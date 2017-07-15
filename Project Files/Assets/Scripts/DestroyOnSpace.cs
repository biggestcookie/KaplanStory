using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSpace : MonoBehaviour {

    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
            Destroy(this.gameObject);
    }
}
