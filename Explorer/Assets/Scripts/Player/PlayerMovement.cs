using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public PlayerInput input;
    public bool left;

    public float maxSpeed;
    [SerializeField]
    float move;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
    }

    private void FixedUpdate() 
    {
        Facing();
        Walk();
    }

    void Walk() {
        move = input.Walk();
        anim.SetFloat("Speed", move);

        if (move == 0) rb.velocity = new Vector2(0f, rb.velocity.y);
        else {
            rb.AddForce(new Vector2(move * maxSpeed * Time.deltaTime, rb.velocity.y));
        }
    }

    void Facing() {

    }

    void CrossHair() {

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
