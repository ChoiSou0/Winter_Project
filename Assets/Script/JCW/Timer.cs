using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text text;

    public int minute = 4; // 분 
    public int second_10; // 십의자리 초
    public int second_0; // 일의자리 초
    public int CurTime; // 소모시간

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine("Timer_Start");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = minute.ToString() + ":" + second_10.ToString() + second_0.ToString();
    }

    IEnumerator Timer_Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!(minute == 0 && second_10 == 0 && second_0 == 0))
            {
                yield return 0;
                // 여기 게임오버
            }
            if (second_0 == 0)
            {
                if (second_10 == 0)
                {
                    minute--;
                    CurTime++;
                    second_10 = 5;
                    second_0 = 9;
                    continue;
                }
                second_10--;
                second_0 = 9;
                CurTime++;
                continue;
            }
            second_0--;
            CurTime++;
        }
    }
}
