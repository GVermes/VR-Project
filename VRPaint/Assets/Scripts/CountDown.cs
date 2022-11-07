using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float min = 3;
    public float sec = 30;
    public TMP_Text timerText;
    public TMP_Text colorText;
    public Animator anim;

    void Start()
    {
        timerText.text = "";
    }

    void Update()
    {
        if (SetUpText.instance.gameCanStart)
        {

            DisplayTimeInMinute();
            
        }

    }

    void DisplayTimeInMinute()
    {
       //MAKE COUNT UP CLOCK
        sec -= Time.deltaTime;

        if(sec < 9.5f)
        {
            timerText.text = "0" + min.ToString("F0") + ":0" + sec.ToString("F0");
        }
        else
        {
            timerText.text = "0" + min.ToString("F0") + ":" + sec.ToString("F0");
        }

        if(sec <= 0)
        {
            min -= 1;
            sec = 59;
        }
        else if(min == -1)
        {
            print("Time is up!");
            //ENDGAME
        }
    }
}
