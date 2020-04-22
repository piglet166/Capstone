using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject pointArm;
    public Renderer arms;
    public Animator anim;
    public PlayerInput input;
    [SerializeField]
    bool left;


    public float maxSpeed;
    public float jumpSpeed;
    [SerializeField]
    float move;
    Vector3 worldPos;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        left = false;
    }

    void Update() 
    {
        CrossHair();
        Arms();
        Dash();
        Jump();
        Melee();
    }

    void FixedUpdate() 
    {
        Facing();
        Walk();
    }

    void CrossHair() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 20;
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void Facing() {
        float lookdir = worldPos.x - rb.position.x;
        if (lookdir < 0) left = true;
        else left = false;

        anim.SetBool("FaceLeft", left);
    }

    void Arms() {

        if (left) {
            arms.sortingOrder = 1;
        } else {
            arms.sortingOrder = -1;
        }

        Vector2 cross = new Vector2(worldPos.x, worldPos.y);
        Vector2 pointDir = cross - rb.position;
        float angle = Mathf.Atan2(pointDir.y, pointDir.x) * Mathf.Rad2Deg;

        pointArm.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Walk() {
        move = input.Walk();
        anim.SetFloat("Speed", move);

        if (move == 0) rb.velocity = new Vector2(0f, rb.velocity.y);
        else {
            rb.AddForce(new Vector2(move * maxSpeed * Time.deltaTime, rb.velocity.y));
        }
    }

    void Dash() {

        float dash = input.Dash();
        if (dash == 0f) return;
        else if(dash < -0.01f) {

        } else {

        }
    }
    void Jump() {

    }

    void Melee() {

    }
}
