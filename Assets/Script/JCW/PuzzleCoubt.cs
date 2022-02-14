using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleCoubt : MonoBehaviour
{
    Text text;
    public int Target_P;
    public int Now_P;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Now_P.ToString() + "/" + Target_P.ToString();
    }
}
