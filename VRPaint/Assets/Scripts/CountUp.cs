using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountUp : MonoBehaviour
{
    public TMP_Text gameTimerText;
    float gameTimer = 0f;
    string endTime;
    public GameObject track3;
    public GameObject handClock;

    void Start()
    {
        gameTimerText.text = "";
    }

    void Update()
    {
        if (SetUpText.instance.gameCanStart)
        {
            if (!SetUpText.instance.gameHasEnded)
            {
                DisplayTimeInMinute();
            }
            else
            {
                handClock.SetActive(false);
               gameTimerText.text = "Your time: " + endTime;
            }
        }

    }


    void DisplayTimeInMinute()
    {
        gameTimer += Time.deltaTime;

        int sec = (int)(gameTimer % 60);
        int min = (int)(gameTimer / 60) % 60;

        if (gameTimer < 10)
        {
            gameTimerText.text = "00" + ":" + "0" + sec.ToString("F0");
        }
        else if (gameTimer > 10 && gameTimer < 60)
        {
            gameTimerText.text = "00" + ":" + sec.ToString("F0");
        }
        else if(sec < 10)
        {
            gameTimerText.text = "0" + min.ToString("F0") + ":" + "0" + sec.ToString("F0");
        }
        else if (gameTimer >= 60 && gameTimer < 600)
        {
            gameTimerText.text = "0" + min.ToString("F0") + ":" + sec.ToString("F0");
        }
        else
        {
            gameTimerText.text = min.ToString("F0") + ":" + sec.ToString("F0");
        }

        endTime = gameTimerText.text;
    }
}
