using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Master master;
    public int health;
    public int MaxHealth;
    public bool player;
    bool invincible;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<Master>();
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Invincible();

        if (health <= 0) {
            Die();
        }

        if (transform.position.y < -3f) Die();
    }

    void Die() {
        if (player) master.MasterRespawn();

        Destroy(gameObject);
    }

    public void Heal(int heal) {
        if (player) health += heal;
    }

    public void TakeDamage(int damage) {
        if (invincible) return;
        health -= damage;
    }

    public void Invincible() {
        if (Input.GetKeyDown(KeyCode.I) && player) {
            invincible = true;
            health = MaxHealth;
        }
    }

    public bool isPlayer() {
        return player;
    }
}
