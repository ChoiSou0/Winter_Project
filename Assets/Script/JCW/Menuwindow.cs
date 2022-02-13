using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menuwindow : MonoBehaviour
{
    RectTransform Rect;

    public int num;

    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            num = 1;
        }
        switch (num)
        {
            case 0:
                Rect.anchoredPosition = new Vector3(0, 1200, 0);
                Time.timeScale = 1;
                break;
            case 1:
                Rect.anchoredPosition = new Vector3(0, 0, 0);
                Time.timeScale = 0;
                break;
        }
    }
}
