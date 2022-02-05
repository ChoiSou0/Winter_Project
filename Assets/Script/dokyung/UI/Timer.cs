using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text[] text_time; 
    public int Second;
    public int Minute;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TimerInvoke", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        text_time[0].text = ((int)time / 3600).ToString();
        text_time[1].text = ((int)time / 60 % 60).ToString();
        text_time[2].text = ((int)time % 60).ToString();
    }

    void TimerInvoke()
    {
        Second--;
        if(Second == 0)
        {
            if (Minute == 0)
            {
                CancelInvoke("TimerInvoke");
                return 0; 
            }
            else
            {
                Minute--;
                Second = 59;
            }
        }
    }
}
