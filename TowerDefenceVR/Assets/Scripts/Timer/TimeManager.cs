using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    private float minuteToRealTime = 1.0f;
    private float timer;

    void Start()
    {
        Minute = 0;
        Hour = 0;
        timer = minuteToRealTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        OnMinuteChanged?.Invoke();

        if (timer <= 0)
        {
            Minute++;
            if (Minute >= 60)
            {
                Hour++;
                Minute = 0;
                OnMinuteChanged?.Invoke();
            }

            timer = minuteToRealTime;
        }
    }
}
