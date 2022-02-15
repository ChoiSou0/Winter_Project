using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPCount : MonoBehaviour
{
    public int SP;

    Text text;

    RectTransform Rect;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        SP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        StatusDark status = GameObject.Find("SP_Dark").GetComponent<StatusDark>();
 /*       switch (status.num)
        {
            case 0:
                Rect.anchoredPosition = Vector3.Lerp(new Vector3(0, -350, 0), new Vector3(0, -700, 0), 0.5F);
                break;
            case 1:
                Rect.anchoredPosition = Vector3.Lerp(new Vector3(0, -700, 0), new Vector3(0, -350, 0), 0.5F);
                break;
        }*/


        text.text = "SP:" + SP.ToString();
    }
}
