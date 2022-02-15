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
        Rect = GetComponent<RectTransform>();
        SP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        StatusDark status = GameObject.Find("SP_Dark").GetComponent<StatusDark>();
        
        if(!status.isStatus)
        {
            SP = 5;
        }

        text.text = "SP:" + SP.ToString();
    }
}
