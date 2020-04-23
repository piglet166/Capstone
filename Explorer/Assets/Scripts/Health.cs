using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int MaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Die();
        }

        if (transform.position.y < -3f) Die();
    }

    void Die() {


        Destroy(gameObject);
    }

    public void TakeDamage(int damage) {
        health -= damage;
    }
}
