﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart;
    public Text textBox;
    
    // Start is called before the first frame update
    void Start()
    {
        timeStart = 0;
        textBox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString() + " Seconds";
    }
}
