using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesLeft : MonoBehaviour
{
    public Master master;
    public Text elt;

    // Update is called once per frame
    void Update()
    {
        elt.text = "Enemies Left: " + master.enemiesLeft.ToString();
    }
}
