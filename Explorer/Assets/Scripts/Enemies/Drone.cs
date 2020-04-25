using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float range;
    public float timer;
    public float fireRate;
    public LayerMask playerLayer;
    public GameObject bulletPrefab;
    public Transform muzzle;
    public float offset;
    public Animator anim;
    public Renderer render;
    Vector2 player;
    bool left;
    float bulletForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Detect()) Shoot();
        else transform.Rotate(Vector3.zero);

        if (left) offset = -180;
        else offset = 0;
    }

    public bool Detect() {
        bool detected = Physics2D.OverlapCircle(transform.position, range, playerLayer);

        player = GameObject.FindGameObjectWithTag("Player").transform.position;

        return detected;
    }

    public void Shoot() {

        if (player.x > transform.position.x) {
            anim.SetBool("Left", false);
            left = false;
        } else {
            anim.SetBool("Left", true);
            left = true;
        }

        Vector2 target = new Vector2(player.x, player.y);
        Vector2 pointDir = target - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(pointDir.y, pointDir.x) * Mathf.Rad2Deg + offset;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (render.isVisible) Fire();
    }

    public void Fire() {
        if (CoolDown()) return;
        
        GameObject round = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        Rigidbody2D rbb = round.GetComponent<Rigidbody2D>();

        if (left) rbb.AddForce(-muzzle.right * bulletForce, ForceMode2D.Impulse);
        else rbb.AddForce(muzzle.right * bulletForce, ForceMode2D.Impulse);

        timer = Time.time + fireRate;
    }

    bool CoolDown() {
        if (Time.time > timer) return false;
        else return true;
    }
}
