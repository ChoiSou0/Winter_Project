using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWindow : MonoBehaviour
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
        switch (num)
        {
            case 0:
                Rect.anchoredPosition = new Vector3(0, 1200, 0);
                break;
            case 1:
                Rect.anchoredPosition = new Vector3(0, 0, 0);
                break;
        }
    }
}
