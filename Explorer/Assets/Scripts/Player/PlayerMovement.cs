using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    PlayerInput input;

    public float maxSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
    }

    private void FixedUpdate() 
    {
        Walk();
    }

    void Walk() {
        float move = input.Walk();

        if (move == 0) rb.velocity = new Vector2(0f, rb.velocity.y);
        else {
            rb.AddForce(new Vector2(move * maxSpeed * Time.deltaTime, rb.velocity.y));
            Debug.Log("Moving");
        }
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
