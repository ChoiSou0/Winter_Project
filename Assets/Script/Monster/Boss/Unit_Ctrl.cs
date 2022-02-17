using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    private Player_Control player;
    public int Unit_Hp;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = GameManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Unit_Hp <= 0)
        {
            gameManager.Ruin_Unit += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            Unit_Hp -= player.Player_Power;
        }

        if (collision.gameObject.tag == "SkillA")
        {
            Unit_Hp -= player.SkillA_Power + player.Player_Power;
        }

        if (collision.gameObject.tag == "SkillS")
        {
            Unit_Hp -= player.SkillS_Power + player.Player_Power;
        }

    }

}
