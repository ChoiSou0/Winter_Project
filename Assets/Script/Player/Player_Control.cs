using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    private DeBufer_Magic deBuf_Magic;

    private Rigidbody2D Player_Rigid;
    private SpriteRenderer Player_Renderer;
    private Wolf_Control wolf_Control;
    private Bangtan_Ctrl bangtan_Ctrl;
    private DeBufer_Ctrl deBufer_Ctrl;
    private ADC_Ctrl adc_Ctrl;
    private Chain_Ctrl chain_Ctrl;
    private Boss_Ctrl boss_Ctrl;
    private Bomb_Ctrl bomb_Ctrl;
    private Player_FallRange fallRange;
    private Animator ani;
    private GameManager gameManager;

    public GameObject Camera;
    public GameObject Attack;
    public GameObject Skill_A;
    public GameObject SKill_S;

    public float Player_MaxHp;
    public float Player_Hp;
    public int Player_Power;
    public float Player_Speed = 5f;
    public float Player_Jumpforce = 5f;
    public int Player_Life = 3;
    public int ATK_Motion;
    public float AttackTime;
    public float DelTime;
    public bool Attacking;
    public float ATK_Time = 0.8f;

    public float Floor;
    
    public bool Player_Jumping;
    public float JumpTime;
    public int Jump_Cnt;

    bool Dashing;
    public float Dash_Cnt;
    public float Dash_FullTime;

    public float DashForce;
    public float StartDashTimer;

    float CurrentDashTimer;
    float DashDirection;

    bool isDashing;

    public int Player_MoveVec;
    public int Player_Vec;

    public bool DeBuf;
    public bool DeBuf_Damge;
    public float DotDeal_Time;
    public float DotTime;

    public bool Chaining;
    public int X_cnt;
    // Skill
    public float Skill_A_Time;
    public float Skill_S_Time;
    public float Skill_D_Time;

    public float SkillA_ani;
    public float SkillS_ani;

    public bool Skill_A_On;
    public bool Skill_S_On;

    public float Magic_ani_Time;
    public bool Magic_ani;

    public int SkillA_Power;
    public int SkillS_Power;

    // Start is called before the first frame update
    void Start()
    {
        Player_Rigid = GetComponent<Rigidbody2D>();
        Player_Renderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        wolf_Control = GameManager.Instance.wolf_Control;
        bangtan_Ctrl = GameManager.Instance.bangtan_Ctrl;
        deBufer_Ctrl = GameManager.Instance.deBufer_Ctrl;
        adc_Ctrl = GameManager.Instance.adc_Ctrl;
        chain_Ctrl = GameManager.Instance.chain_Ctrl;
        boss_Ctrl = GameManager.Instance.boss_Ctrl;
        bomb_Ctrl = GameManager.Instance.bomb_Ctrl;
        gameManager = GameManager.Instance;
        fallRange = GameObject.Find("Player_Fall_Range").GetComponent<Player_FallRange>();

        Attack.SetActive(false);

        ATK_Motion = 1;
    }

    void Update()
    {
        if (gameManager.GameOver == false)
        {
            Skill_A_Time += Time.deltaTime;
            Skill_S_Time += Time.deltaTime;
            Skill_D_Time += Time.deltaTime;
            DelTime += Time.deltaTime;

            //if (gameManager.Skill_D_On == true)
            //{
            //    Magic_ani = true;
            //}

            //if (Magic_ani_Time <= 0.1f && Magic_ani == true)
            //{
            //    Magic_ani_Time += Time.deltaTime;

            //    if (Magic_ani_Time >= 0.1f)
            //    {
            //        ani.SetBool("isMagic", false);
            //        ani.SetBool("isIdle", true);
            //        Magic_ani_Time = 0;
            //        Magic_ani = false;
            //    }
            //}

            if (Skill_A_On == true && SkillA_ani <= 0.5f)
            {
                ani.SetBool("isSkillA", true);
                SkillA_ani += Time.deltaTime;
                if (SkillA_ani >= 0.5f)
                    ani.SetBool("isSkillA", false);
            }

            if (Skill_S_On == true && SkillS_ani <= 0.5f)
            {
                ani.SetBool("isSkillS", true);
                SkillS_ani += Time.deltaTime;
                if (SkillS_ani >= 0.5f)
                    ani.SetBool("isSkillS", false);
            }

            // DeBuf
            if (DeBuf == true && DotDeal_Time <= 1)
            {
                Player_Speed = 2.5f;
                DotDeal_Time += Time.deltaTime;
                if (DotDeal_Time >= 1)
                {
                    DotDeal_Time = 0;
                    Player_Hp -= 4;
                }
            }

            if (DeBuf == false && DeBuf_Damge == true && DotTime <= 2)
            {
                DotDeal_Time += Time.deltaTime;
                DotTime += Time.deltaTime;

                if (DotDeal_Time >= 1)
                {
                    DotDeal_Time = 0;
                    Player_Hp -= 4;
                }

                if (DotTime >= 2)
                {
                    DotTime = 0;
                    DeBuf_Damge = false;
                    Player_Speed = 5;
                }
            }

            // Died 만들어야됨
            #region
            #endregion

            // Move
            #region
            // Move
            float h = Input.GetAxisRaw("Horizontal");

            if (Skill_S_On == false && Chaining == false)
            {
                Player_Rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    ani.SetBool("isRun", true);
                    ani.SetBool("isIdle", false);
                    Player_Renderer.flipX = false;
                    Attack.transform.localPosition = new Vector2(0.5f, 0.5f);
                    Player_MoveVec = 1;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    ani.SetBool("isRun", true);
                    ani.SetBool("isIdle", false);
                    Player_Renderer.flipX = true;
                    Attack.transform.localPosition = new Vector2(-0.5f, 0.5f);
                    Player_MoveVec = -1;
                }
                else if (h == 0)
                {
                    ani.SetBool("isIdle", true);
                    ani.SetBool("isRun", false);
                }
            }

            if (Player_Rigid.velocity.x > Player_Speed)
            {
                Player_Rigid.velocity = new Vector2(Player_Speed, Player_Rigid.velocity.y);
            }
            else if (Player_Rigid.velocity.x < Player_Speed * (-1))
            {
                Player_Rigid.velocity = new Vector2(Player_Speed * (-1), Player_Rigid.velocity.y);
            }

            #endregion

            // Jump
            #region
            // Jump
            if (Input.GetKeyDown(KeyCode.C) && Jump_Cnt > 0 && Chaining == false)
            {
                SoundManager.Instance.Play("Jump");
                ani.SetBool("isJump", true);
                Player_Jumping = true;
                Jump_Cnt--;
                Player_Rigid.AddForce(Vector2.up * Player_Jumpforce, ForceMode2D.Impulse);
            }

            if (Player_Jumping == true && JumpTime <= 0.1f)
            {
                JumpTime += Time.deltaTime;

                if (JumpTime >= 0.1f)
                {
                    ani.SetBool("isJump", false);
                }
            }

            if (Player_Jumping == true && fallRange.isGround == true)
            {
                ani.SetBool("isFall", true);
            }
            #endregion

            // Dash
            #region
            // Dash
            if (Input.GetKeyDown(KeyCode.Z) && Dash_Cnt > 0 && Chaining == false)
            {
                SoundManager.Instance.Play("Dash");
                Dash_Cnt -= 1;
                isDashing = true;
                CurrentDashTimer = StartDashTimer;
                Player_Rigid.velocity = Vector2.zero;
                DashDirection = (int)h;

                if (Dash_Cnt == 0)
                {
                    Invoke("Dash_Full", Dash_FullTime);
                }
            }

            if (isDashing)
            {
                ani.SetBool("isDash", true);
                Dashing = true;
                transform.Translate(Vector2.right * Player_MoveVec * DashForce * Time.deltaTime);

                CurrentDashTimer -= Time.deltaTime;

                if (CurrentDashTimer <= 0)
                {
                    ani.SetBool("isDash", false);
                    isDashing = false;
                    Dashing = false;
                }
            }
            #endregion

            // Skill(A)
            if (Input.GetKeyDown(KeyCode.A) && Skill_A_Time >= 7 && Chaining == false)
            {
                SoundManager.Instance.Play("Slash");
                Skill_A_Time = 0;
                if (Player_Renderer.flipX == false)
                    Player_Vec = 1;
                else if (Player_Renderer.flipX == true)
                    Player_Vec = -1;

                Instantiate(Skill_A, new Vector2(transform.localPosition.x, transform.localPosition.y + 1f), Quaternion.identity);
                Skill_A_On = true;
            }

            // Skill(S)
            if (Input.GetKeyDown(KeyCode.S) && Skill_S_Time >= 14 && Chaining == false)
            {
                SoundManager.Instance.Play("Knock_Back");
                Skill_S_Time = 0;
                if (Player_Renderer.flipX == false)
                    Player_Vec = 1;
                else if (Player_Renderer.flipX == true)
                    Player_Vec = -1;

                Instantiate(SKill_S, new Vector2(transform.localPosition.x, transform.localPosition.y + 1f), Quaternion.identity);
                Skill_S_On = true;
            }

            // The World (Skill D)
            if (Input.GetKeyDown(KeyCode.D) && Skill_D_Time >= 100 && Chaining == false)
            {
                SoundManager.Instance.Play("Time_Stop");
                Skill_D_Time = 0;
                gameManager.Skill_D_On = true;
            }

            if (Chaining == true && X_cnt <= 10)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    X_cnt -= 1;
                    
                }

                if (X_cnt == 0)
                {
                    ani.SetBool("isRestraint", false);
                    Chaining = false;
                }

            }

            if (Attacking == true && AttackTime <= 0.1f && Chaining == false)
            {
                AttackTime += Time.deltaTime;

                if (AttackTime >= 0.1f)
                {
                    AttackTime = 0;
                    Attacking = false;
                    ani.SetBool("isAttack1", false);
                    ani.SetBool("isAttack2", false);
                    Attack.SetActive(false);

                    if (ATK_Motion == 3)
                        ATK_Motion = 1;
                }
            }

            // Attack
            if (Input.GetKeyDown(KeyCode.X) && DelTime >= ATK_Time && Chaining == false)
            {
                //RaycastHit2D Skill_A_hit = Physics2D.BoxCast(transform.position, 
                //    new Vector2(8, 1), 0, new Vector2(1, 0), 0);

                //if (Skill_A_hit.transform != null && Skill_A_hit.transform.tag == "Enermy")
                //{
                //    Destroy(Skill_A_hit.transform.gameObject);
                //}
                DelTime = 0;
                SoundManager.Instance.Play("Attack");
                if (Player_Renderer.flipX == false)
                    Player_Vec = 1;
                else if (Player_Renderer.flipX == true)
                    Player_Vec = -1;

                Attack.gameObject.SetActive(true);

                if (Player_Renderer.flipX == false)
                {
                    Attack.transform.localPosition = new Vector2(0.5f, 0.5f);
                }
                else if (Player_Renderer.flipX == true)
                {
                    Attack.transform.localPosition = new Vector2(-0.5f, 0.5f);
                }

                if (ATK_Motion == 1)
                    ani.SetBool("isAttack1", true);
                else if (ATK_Motion == 2)
                    ani.SetBool("isAttack2", true);

                ATK_Motion++;

                Attacking = true;
            }
        }
        else
        {
            ani.SetBool("isDied", true);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Ground")
        {
            ani.SetBool("isJump", false);
            ani.SetBool("isFall", false);
            Jump_Cnt = 2;
            Player_Jumping = false;
        }
        else
        {
            Player_Jumping = true;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bite" && Dashing == false)
        {
            ani.SetBool("isRestraint", false);
            Chaining = false;
            Player_Hp -= wolf_Control.Wolf_Power;
        }

        if (collision.gameObject.tag == "Bangtan_Attack" && Dashing == false)
        {
            ani.SetBool("isRestraint", false);
            Chaining = false;
            Player_Hp -= bangtan_Ctrl.Bangtan_Power;
        }  

        if (collision.gameObject.tag == "Bangtan_Rush" && Dashing == false)
        {
            ani.SetBool("isRestraint", false);
            Chaining = false;
            Player_Hp -= 15;
        }

        if (collision.gameObject.tag == "ADC_Fire" && Dashing == false)
        {
            ani.SetBool("isRestraint", false);
            Chaining = false;
            Player_Hp -= adc_Ctrl.ADC_Power;
        }

        if (collision.gameObject.tag == "Chain_Attack" && Dashing == false)
        {
            ani.SetBool("isRestraint", false);
            Chaining = false;
            Player_Hp -= chain_Ctrl.Chain_Power;
        }

        if (collision.gameObject.tag == "DeBufer_Attack" && Dashing == false)
        {
            ani.SetBool("isRestraint", false);
            Chaining = false;
            Player_Hp -= deBufer_Ctrl.DeBufer_Power;
        }

        if (collision.gameObject.tag == "DeBufer_Magic" && Dashing == false)
        {
            DeBuf_Damge = true;
            DeBuf = true;
        }

        if (collision.gameObject.tag == "Chain_Restruction" && Dashing == false)
        {
            ani.SetBool("isRestraint", true);
            X_cnt = 10;
            Chaining = true;
        }

        if (collision.gameObject.tag == "Boss_Sheild")
        {
            CurrentDashTimer = 0;
            ani.SetBool("isDash", false);
            isDashing = false;
            Dashing = false;
        }


        if (collision.gameObject.tag == "PastBack")
        {
            gameManager.TimeLine_On = false;
        }
        if (collision.gameObject.tag == "FutureBack")
        {
            gameManager.TimeLine_On = true;
        }

        if (collision.gameObject.tag == "Boss_Fire" && Dashing == false)
        {
            Player_Hp -= boss_Ctrl.Fire_Power;
            Chaining = false;
        }

        if (collision.gameObject.tag == "Boss_Bomb" && bomb_Ctrl.Pop == true && Dashing == false)
        {
            Player_Hp -= boss_Ctrl.Bomb_Power;
            Chaining = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeBufer_Magic")
        {
            Debug.Log("매직풀림");
            DeBuf = false;
        }
    }

    void FixedUpdate()
    {
        //Debug.DrawRay(Player_Rigid.position, Vector2.down, new Color(0, 1, 0));

        //RaycastHit2D RayHit = Physics2D.Raycast(Player_Rigid.position, Vector2.down, 0.5f, LayerMask.GetMask("Ground"));


        //if (RayHit.collider != null /*&& RayHit.distance < 0.5f*/)
        //{
        //    Debug.Log("G");
        //    Player_Jumping = false;
        //}
        //else
        //{
        //    Debug.Log("D");
        //    Player_Jumping = true;
        //}


    }

    void Dash_Full()
    {
        Dash_Cnt = 2;
    }

    void Del()
    {
        Debug.Log("The World Del");
    }
}
