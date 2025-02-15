﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;
    public GameObject pointArm;
    public Renderer arms;
    public Animator anim;
    public PlayerInput input;
    public Transform groundCheck;
    public Transform muzzle;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public AudioClip jumpAudio;
    public AudioSource plyrAS;
    [SerializeField]
    bool left;
    [SerializeField]
    float move;
    [SerializeField]
    bool grounded;

    [Header("Speed")]
    public float maxSpeed;
    public float walkSpeed;
    public float jumpSpeed;
    public float airSpeed;
    public float gcRadius;
    public float attackRange;
    public float rotationDifference;
    Vector3 worldPos;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        left = false;
        grounded = false;
    }

    void Update() 
    {
        CrossHair();
        Arms();
        Jump();
        Melee();
    }

    void FixedUpdate() 
    {
        Facing();
        Walk();

        grounded = CheckGround();
        anim.SetBool("Airborne", !grounded);

        CappedVelocity();
    }

    void CrossHair() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = rotationDifference;
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

        if (!grounded) return;
        move = input.Walk();
        anim.SetFloat("Speed", move);

        if (move == 0) rb.velocity = new Vector2(0f, rb.velocity.y);
        else {
            rb.AddForce(new Vector2(move * walkSpeed * Time.deltaTime, rb.velocity.y));
        }
    }

    void Jump() {
        if (grounded && input.Jump()) {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.AddForce(new Vector2(0, jumpSpeed));
            plyrAS.PlayOneShot(jumpAudio);
        } else if (!grounded) {
            move = input.Walk();
            
            rb.AddForce(new Vector2(move * airSpeed *Time.deltaTime, 0));

            if(rb.velocity.y <= 0.01f && rb.velocity.y >= -0.01f && input.Jump()) {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                rb.AddForce(new Vector2(0, jumpSpeed));
                plyrAS.PlayOneShot(jumpAudio);
            }
        }
    }

    void Melee() {
        if (input.Melee()) {
            if (grounded) {
                anim.SetTrigger("Attack");
                Collider2D[] hits = Physics2D.OverlapCircleAll(muzzle.position, attackRange, enemyLayer);

                foreach (Collider2D enemy in hits) {
                    enemy.GetComponent<Health>().TakeDamage(5);
                }
            } else {
                anim.SetTrigger("Attack");
                
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f, enemyLayer);

                foreach (Collider2D enemy in hits) {
                    enemy.GetComponent<Health>().TakeDamage(5);
                }
            }
        }
    }

    bool CheckGround() {

        bool ground = Physics2D.OverlapCircle(groundCheck.position, gcRadius, groundLayer);

        return ground;
    }

    void CappedVelocity() {

        float cappedVelocity = Mathf.Min(rb.velocity.x, maxSpeed);

        rb.velocity = new Vector3(cappedVelocity, rb.velocity.y);
    }
}
