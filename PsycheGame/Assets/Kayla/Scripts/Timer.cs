﻿//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public Text timerText;
    public GameObject GameOverScreen;
    private bool gameWon = false;
    public GameObject ship;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue += 0;
        }
        if ( !gameWon ) DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            GameOverScreen.SetActive(true);
            GameOverScreen.GetComponent<Animator>().SetTrigger("ShowWinScreen");  
            gameWon = true;
            Destroy( ship );
            Destroy( gameObject );
        }
        else
        {
            GameOverScreen.SetActive(false);

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
