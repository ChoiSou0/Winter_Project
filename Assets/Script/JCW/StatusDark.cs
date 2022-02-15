using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDark : MonoBehaviour
{
    RectTransform Rect;

    public bool isStatus;

    public float Curtime =0;

    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (isStatus)
        {
            case false:
                Curtime += Time.deltaTime;
                if (Curtime >= 2)
                {
                    Rect.anchoredPosition = new Vector3(0, 1200, 0);
                    Time.timeScale = 1;
                    Curtime = 0;
                }
                break;
            case true:
                Rect.anchoredPosition = new Vector3(0, 0, 0);
                Time.timeScale = 0;
                break;
        }
    }
}
