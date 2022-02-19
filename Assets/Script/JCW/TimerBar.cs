using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    RectTransform Rect;

    Slider slider;

    public int num;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        Rect = GetComponent<RectTransform>();
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.Skill_D_On)
        {
            num = 1;
        }
        else
        {
            num = 0;
        }
        switch (num)
        {
            case 0:
                slider.value = 9;
                Rect.anchoredPosition = new Vector3(0, 1200, 0);
                break;
            case 1:
                slider.value -= Time.deltaTime;
                Rect.anchoredPosition = new Vector3(0, 400, 0);
                break;
        }
    }
}
