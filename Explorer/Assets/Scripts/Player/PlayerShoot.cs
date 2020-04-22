using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public PlayerInput input;
    public Transform muzzle;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Shoot()) {
            Fire();
        }
    }

    void Fire() {
        GameObject round = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        Rigidbody2D rbb = round.GetComponent<Rigidbody2D>();
        rbb.AddForce(muzzle.right * bulletForce, ForceMode2D.Impulse);
    }
}
