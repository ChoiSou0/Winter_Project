using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPCount : MonoBehaviour
{
    public int SP;

    Text text;

    int a;
    
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
        
        if(!status.isStatus)
        {
            SP = 5;
        }
        if (SP == 0)
        {
            if (a == 0)
            {
                a = 1;
                StartCoroutine(Sp_over());
            }
        }

        text.text = "SP:" + SP.ToString();
    }

    IEnumerator Sp_over()
    {
        Debug.Log("13");
        yield return new WaitForSecondsRealtime(2);

        Debug.Log("2222");
        StatusDark status = GameObject.Find("SP_Dark").GetComponent<StatusDark>();
        Wavecount wavecount = GameObject.Find("Wave_Count").GetComponent<Wavecount>();
        wavecount.Wave++;
        Time.timeScale = 1;
        status.isStatus = false;

        a = 0;
        yield return 0;
    }
}
