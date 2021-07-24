﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float timeLimit;
    [SerializeField] private Text remainingTime;

    void Start()
    {
        int minutes = (int)(timeLimit / 60);
        int seconds = (int)(timeLimit - minutes * 60);
        remainingTime.text = minutes.ToString() + ":" + seconds.ToString();
    }

 
    void Update()
    {
        if (timeLimit > 0f)
        {
            timeLimit -= Time.deltaTime;
            int minutes = (int)(timeLimit / 60);
            int seconds = (int)(timeLimit - minutes * 60);
            remainingTime.text = minutes.ToString("d2") + ":" + seconds.ToString("d2");
        }
    }
}
