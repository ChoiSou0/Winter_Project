using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public int StatusNUM;
    // 1.최대체력 2.공격력 3.이동속도 4.공격속도

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StatusUP()
    {
        SPCount sP = GameObject.Find("SP_Count").GetComponent<SPCount>();
        Player_Control player = GameObject.Find("Player").GetComponent<Player_Control>();
        if (sP.SP > 0)
        {
            if (GetComponentInChildren<Slider>().value >= GetComponentInChildren<Slider>().maxValue)
            {
                SoundManager.Instance.Play("Nope");
            }
            else
            {
                GetComponentInChildren<Slider>().value++;
                sP.SP--;
                switch (StatusNUM)
                {
                    case 1:
                        player.Player_MaxHp += 10;
                        break;
                    case 2:
                        player.Player_Power += 4;
                        break;
                    case 3:
                        player.Player_Speed += 0.5f;
                        break;
                    case 4:
                        player.ATK_Time -= 0.07f;
                        break;
                }
                SoundManager.Instance.Play("Button_Click");
            }
        }
    }
}
