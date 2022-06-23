using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerScript : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private float startTime;
    private float t;
    private int minutes;
    private int seconds;

    public bool timeStopped = false;

    private void Start()
    {
        startTime = Time.time;
        timerText.color = Color.white;
    }

    public void stopTimer()
    {
        timeStopped = true;
        timerText.color = Color.yellow;
    }

    public void transitionToNextLevel()
    {
        FindObjectOfType<GameManager>().loadNextLevel();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (timeStopped == false)
        {
            timeUpdate();
        }
    }
    private void timeUpdate()
    {
        t = Time.time - startTime;
        minutes = ((int)t / 60);
        seconds = ((int)t % 60);
        if(minutes < 10)
        {
            if(seconds < 10)
            {
                timerText.text = "0" + minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                timerText.text = "0" + minutes.ToString() + ":" + seconds.ToString();
            }
        }
    }
}
