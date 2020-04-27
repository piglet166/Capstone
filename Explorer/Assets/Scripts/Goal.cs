using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

        Debug.Log("goal hit");

        if (player != null) {
            PlayGame();
            Debug.Log("Goal Triggered");
        }
    }

    public void PlayGame() {
        SceneManager.LoadScene(3);
    }
}
