using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeDid;
    public bool TimeON = false;

    public Text TimerS;

    private void Start()
    {
        TimeON = true;
    }

    private void FixedUpdate()
    {
        if (TimeON)
        {
            if (TimeDid >= 0)
            {
                TimeDid += Time.deltaTime;
                TimerUpdate(TimeDid);
            }
            else
            {
                TimeON = false;
            }
        }
    }

    void TimerUpdate(float currentTime)
    {
        currentTime += 1;

        float seconds = currentTime % 1000;

        TimerS.text = string.Format("Time :" + "{0:00}", seconds);

    }
}
