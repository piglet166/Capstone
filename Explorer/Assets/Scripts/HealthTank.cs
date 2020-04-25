using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTank : MonoBehaviour
{
    public LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D collision) {

        //if (collision.gameObject.layer == playerLayer) {
            Health player = collision.gameObject.GetComponent<Health>();
            player.Heal(5);
            Destroy(gameObject);

            Debug.Log("Touched");
        //}
    }
}
