using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_bar : MonoBehaviour
{

    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Player_Control player = GameObject.Find("Player").GetComponent<Player_Control>();
        slider.maxValue = player.Player_MaxHp;
        slider.value = player.Player_Hp;
    }
}
