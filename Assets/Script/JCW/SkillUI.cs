using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    Image image;

    public float CoolTime;

    public int Skill_num;
    // 1.참격 2.넉백 3.시간정지

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Player_Control player = GameObject.Find("Player").GetComponent<Player_Control>();

        switch (Skill_num)
        {
            case 1:
                image.fillAmount = 1 - (player.Skill_A_Time / 7);
                break;
            case 2:
                image.fillAmount = 1 - (player.Skill_S_Time / 14);
                break;
            case 3:
                image.fillAmount = 1 - (player.Skill_D_Time / 100);
                break;

        }
    }
}
