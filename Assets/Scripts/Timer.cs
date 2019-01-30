using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text MinutenEnSecondenTimerText;

    public bool TimerIsactive = true;
    private float MiliSeconden = 0f;
    private float seconden = 0f;
    private float minuten = 0f;

    private static Timer p_timer_instance;
    public static Timer Timer_Instance { get { return p_timer_instance; } }

    private void Awake()
    {
        p_timer_instance = this;
    }

    public float Seconden
    {
        get
        {
            return seconden;
        }
        set
        {
            seconden = value;
        }
    }

    public float Minuten
    {
        get
        {
            return minuten;
        }
        set
        {
            minuten = value;
        }
    }

    private void Update()
    {
        if (TimerIsactive == true)
        {
            if (MinutenEnSecondenTimerText != null)
            {
                MiliSeconden++;

                if (MiliSeconden >= 60f) //hier komen de seconden er bij
                {
                    MiliSeconden = 0f;
                    seconden += 1f;
                }

                if (seconden >= 60f) //hier komen de minuten er bij
                {
                    seconden = 0f;
                    minuten += 1f;
                }

                MinutenEnSecondenTimerText.text = " " + minuten.ToString() + " : " + " " + seconden.ToString();
            }
        }
    }
}