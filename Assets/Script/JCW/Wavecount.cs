using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wavecount : MonoBehaviour
{
    Text text;
    public int Wave =1;

    // Start is called before the first frame update
    void Awake()
    {
        SoundManager.Instance.Play("Ingame", SOUND.BGM);
        SoundManager.Instance.Play("Ingame", SOUND.BGM);
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
