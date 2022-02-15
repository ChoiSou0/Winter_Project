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
        if(sP.SP > 0)
        {
            switch (StatusNUM)
            {
                case 1:
                    player.Player_MaxHp += 10;
                    break;
                case 2:
                    player.Player_Power += 4;
                    break;
                case 3:
                    player. += 4;
                    break;
            }
            GetComponentInChildren<Slider>().value++;
            sP.SP--;
        }
        

    } 
}
