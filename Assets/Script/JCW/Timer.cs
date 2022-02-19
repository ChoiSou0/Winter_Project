using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text text;

    private GameManager gameManager;

    public bool isTimeUP;

    public int minute = 4; // �� 
    public int second_10; // �����ڸ� ��
    public int second_0; // �����ڸ� ��
    public int CurTime; // �Ҹ�ð�

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
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
            if (!gameManager.Skill_D_On)
            {
                if (minute == 0 && second_10 == 0 && second_0 == 0)
                {
                    isTimeUP = true;
                    break;
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
            yield return new WaitForSeconds(1);
        }
        yield return 0;
    }
}
