using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float range;
    public float timer;
    public float fireRate;
    public LayerMask playerLayer;
    public GameObject bulletPrefab;
    public Transform muzzle;
    public float offset;
    public Renderer render;
    Vector2 player;
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
    }

    public bool Detect() {

        bool detected = false;
        RaycastHit2D hit = Physics2D.Raycast(muzzle.position, -Vector2.right, range, playerLayer);
        Debug.DrawRay(muzzle.position, -Vector2.right, Color.red);

        if(hit.collider != null) {
            detected = true;
        }
        return detected;
    }

    public void Shoot() {
        
        if (render.isVisible) Fire();
    }

    public void Fire() {
        if (CoolDown()) return;

        GameObject round = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        Rigidbody2D rbb = round.GetComponent<Rigidbody2D>();

        rbb.AddForce(-muzzle.right * bulletForce, ForceMode2D.Impulse);

        timer = Time.time + fireRate;
    }

    bool CoolDown() {
        if (Time.time > timer) return false;
        else return true;
    }
}
