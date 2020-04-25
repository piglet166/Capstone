using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject effect;
    public LayerMask playerLayer;

    private void Start() {
        Destroy(gameObject, .35f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Collider2D player = Physics2D.OverlapCircle(transform.position, .2f, playerLayer);

        if (player != null) player.GetComponent<Health>().TakeDamage(5);


        GameObject hit = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(hit, .5f);
        Destroy(gameObject);
    }
}
