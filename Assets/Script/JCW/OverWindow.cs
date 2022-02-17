using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverWindow : MonoBehaviour
{
    RectTransform Rect;

    public int isGameOver;

    public int isTimer;

    public int isButton;

    Text text;

    public int minute;
    public int second;

    // Start is called before the first frame update
    void Start()
    {
        if(isTimer == 1)
        {
            text = GetComponent<Text>();
        }
        Rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimer == 0)
        {
            if (isButton == 0)
            {
                switch (isGameOver)
                {
                    case 0:
                        Rect.anchoredPosition = new Vector3(0, 1200, 0);
                        break;
                    case 1:
                        Rect.anchoredPosition = new Vector3(0, 0, 0);
                        Time.timeScale = 0;
                        break;
                }
            }
        }
        else if(isTimer ==1)
        {
            Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
            minute = timer.CurTime / 60;
            second = timer.CurTime % 60;
            text.text = "소요 시간:" + minute.ToString() + ":" + second.ToString();
        }
    }

    public void OverBack()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}
