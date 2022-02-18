using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDark : MonoBehaviour
{
    RectTransform Rect;

    public bool isStatus;

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
                Rect.anchoredPosition = new Vector3(0, 1200, 0);
                break;
            case true:
                Rect.anchoredPosition = new Vector3(0, 0, 0);
                Time.timeScale = 0;
                break;
        }
    }
}
