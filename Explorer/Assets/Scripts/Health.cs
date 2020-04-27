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
    public bool bullet;
    public AudioClip tankGrabed;
    public AudioClip respawnClip;
    public AudioSource hlthAS;

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
        if (player) {
            master.MasterRespawn();
            hlthAS.PlayOneShot(respawnClip);
        }

        if (!player) {

            if (!bullet) master.EnemyDied();

            Destroy(gameObject);
        }
    }

    public void Heal(int heal) {

        if (player) {

            health = health + heal;
            hlthAS.PlayOneShot(tankGrabed);
        }

        if (health > MaxHealth) health = MaxHealth;
    }

    public void TakeDamage(int damage) {
        if (invincible) return;
        health = health - damage;
    }

    public void Invincible() {
        if (player) {
            if (Input.GetKeyDown(KeyCode.I)) {
                if (invincible) {
                    invincible = false;
                } else {
                    invincible = true;
                    health = MaxHealth;
                }
            }
        }
    }

    public bool isPlayer() {
        return player;
    }
}
