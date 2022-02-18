using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wavecount : MonoBehaviour
{
    Text text;
    public int Wave;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (Wave == 8)
        {
            text.text = "Wave.Final";
        }
        else
        {
            text.text = "Wave." + Wave.ToString();
        }
    }
}
