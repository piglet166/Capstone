﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quit();
    }

    public float Walk() {
        int button = 0;
        if (Input.GetKey(KeyCode.D)) button = 1;
        else if (Input.GetKey(KeyCode.A)) button = 2;

        switch (button) {
            case 0:
                return 0f;
            case 1:
                return 1f;
            case 2:
                return -1f;
            default:
                Debug.Log("Eror in PlayerInput Walk()");
                break;
        }

        return 0f;
    }

    public void Quit() {
        if (Input.GetKeyDown(KeyCode.Tab))
            SceneManager.LoadScene(0);
    }

    public bool Jump() {
        if (Input.GetKeyDown(KeyCode.Space)) return true;
        else return false;
    }

    public bool Melee() {
        if (Input.GetMouseButtonDown(1)) return true;
        else return false;
    }

    public bool Shoot() {
        if (Input.GetMouseButtonDown(0)) return true;
        else return false;
    }
}
