using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;

    private void Start() {
        Physics.IgnoreLayerCollision(0, 8);
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        GameObject hit = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(hit, .5f);
        Destroy(gameObject);
    }
}
