using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float timeLimit;
    [SerializeField] private Text remainingTime;

    [SerializeField] private UnityEvent gameOverEvent = new UnityEvent();
    private bool nowPlaying = true;

    private void Start()
    {
        int minutes = (int)(timeLimit / 60);
        int seconds = (int)(timeLimit - minutes * 60);
        remainingTime.text = minutes.ToString() + ":" + seconds.ToString();
    }

 
    private void Update()
    {
        if (timeLimit > 0f)
        {
            timeLimit -= Time.deltaTime;
            int minutes = (int)(timeLimit / 60);
            int seconds = (int)(timeLimit - minutes * 60);
            remainingTime.text = minutes.ToString("d2") + ":" + seconds.ToString("d2");
        }
        else if (nowPlaying)
        {
            gameOverEvent.Invoke();
            nowPlaying = false;
            remainingTime.text = "00:00";
        }
    }

    public void AddTimeLimit(float seconds)
    {
        timeLimit += seconds;
    }
}
