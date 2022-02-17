using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player_Control player;
    public Transform target;

    public Bangtan_AttackRange bangtan_AttackRange;
    public Bangtan_MoveRange bangtan_MoveRange;
    public Bangtan_Dash_Range bangtan_DashbRange;

    public Chain_AttackRange chain_AttackRange;
    public Chain_RestructionRange chain_RestructionRange;

    public bool FireBall1_On;
    public bool FireBall2_On;
    public bool FireBall3_On;


    public bool Skill_D_On;
    public float TheWorldTime;

    public GameObject SkillD;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Control>();

        bangtan_AttackRange = FindObjectOfType<Bangtan_AttackRange>();
        bangtan_MoveRange = FindObjectOfType<Bangtan_MoveRange>();
        bangtan_DashbRange = FindObjectOfType<Bangtan_Dash_Range>();

        chain_AttackRange = FindObjectOfType<Chain_AttackRange>();
        chain_RestructionRange = FindObjectOfType<Chain_RestructionRange>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Skill_D_On == true && TheWorldTime <= 9)
        {
            SkillD.SetActive(true);
            TheWorldTime += Time.deltaTime;

            if (TheWorldTime >= 9)
            {
                SkillD.SetActive(false);
                TheWorldTime = 0;
                Skill_D_On = false;
            }
        }

    }

}
