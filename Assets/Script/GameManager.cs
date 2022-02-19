using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public SpriteRenderer spriteRenderer;
    public Player_Control player;
    public Camera_Control camera;
    public Transform target;

    public Bangtan_Ctrl bangtan_Ctrl;
    public Bangtan_AttackRange bangtan_AttackRange;
    public Bangtan_MoveRange bangtan_MoveRange;
    public Bangtan_Dash_Range bangtan_DashbRange;

    public Chain_Ctrl chain_Ctrl;
    public Chain_AttackRange chain_AttackRange;
    public Chain_RestructionRange chain_RestructionRange;

    public Wolf_Control wolf_Control;
    public MoveRange wolfMoveRange;
    public AttackRange wolfAttackRange;

    public DeBufer_Ctrl deBufer_Ctrl;
    public DeBufer_AttackRange deBufer_AttackRange;
    public DeBufer_MoveRange deBufer_MoveRange;
    public DeBufer_TelRange deBufer_TelRange;

    public ADC_Ctrl adc_Ctrl;

    public Boss_Ctrl boss_Ctrl;
    public Unit_Ctrl unit_Ctrl;
    public Bomb_Ctrl bomb_Ctrl;

    public bool FireBall1_On;
    public bool FireBall2_On;
    public bool FireBall3_On;


    public bool TimeLine_On;
    public bool Skill_D_On;
    public float TheWorldTime;
    public int Ruin_Unit;
    public bool GameOver;
    public bool GameClear;
    public float ClearTime;

    public GameObject SkillD;
    public GameObject Clear;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player_Control>();

        bangtan_Ctrl = FindObjectOfType<Bangtan_Ctrl>();
        bangtan_AttackRange = FindObjectOfType<Bangtan_AttackRange>();
        bangtan_MoveRange = FindObjectOfType<Bangtan_MoveRange>();
        bangtan_DashbRange = FindObjectOfType<Bangtan_Dash_Range>();

        chain_Ctrl = FindObjectOfType<Chain_Ctrl>();
        chain_AttackRange = FindObjectOfType<Chain_AttackRange>();
        chain_RestructionRange = FindObjectOfType<Chain_RestructionRange>();

        wolf_Control = FindObjectOfType<Wolf_Control>();
        wolfMoveRange = FindObjectOfType<MoveRange>();
        wolfAttackRange = FindObjectOfType<AttackRange>();

        deBufer_Ctrl = FindObjectOfType<DeBufer_Ctrl>();
        deBufer_AttackRange = FindObjectOfType<DeBufer_AttackRange>();
        deBufer_MoveRange = FindObjectOfType<DeBufer_MoveRange>();
        deBufer_TelRange = FindObjectOfType<DeBufer_TelRange>();

        adc_Ctrl = FindObjectOfType<ADC_Ctrl>();

        boss_Ctrl = FindObjectOfType<Boss_Ctrl>();
        unit_Ctrl = FindObjectOfType<Unit_Ctrl>();
        bomb_Ctrl = FindObjectOfType<Bomb_Ctrl>();

        camera = FindObjectOfType<Camera_Control>();
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


        if (player.Player_Hp <= 0)
        {
            GameOver = true;
        }

        if (GameClear == true && ClearTime <= 5f)
        {
            ClearTime += Time.deltaTime;

            if (ClearTime >= 5)
            {

            }
        }
    }

}
