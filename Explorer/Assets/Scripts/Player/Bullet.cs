using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;
    public LayerMask enemyLayer;

    private void Start() {
        Physics.IgnoreLayerCollision(0, 8);
        Destroy(gameObject, .35f);
    }

    private void OnCollisionEnter2D (Collision2D collision) {

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, .2f, enemyLayer);

        foreach (Collider2D enemy in hits) {
            enemy.GetComponent<Health>().TakeDamage(5);
        }

        GameObject hit = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(hit, .5f);
        Destroy(gameObject);
    }
}
