using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) Walk(true);
        if (Input.GetKey(KeyCode.D)) Walk(false);
        if (Input.GetKey(KeyCode.Q)) Dash(true);
        if (Input.GetKey(KeyCode.E)) Dash(false);
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
        if (Input.GetMouseButtonDown(1)) Melee();
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    void Walk(bool Left) {

    }

    void Dash(bool Left) {

    }

    void Jump() {

    }

    void Melee() {

    }

    void Shoot() {

    }
}
