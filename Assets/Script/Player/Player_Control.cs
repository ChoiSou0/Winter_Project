using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    //[SerializeField] public LayerMask Nocheck;

    private Rigidbody2D Player_Rigid;
    private SpriteRenderer Player_Renderer;
    private Wolf_Control wolf_Control;
    private Bangtan_Ctrl bangtan_Ctrl;

    public GameObject Camera;
    public GameObject Attack;
    public GameObject Skill_A;
    public GameObject SKill_S;

    public float Player_Hp;
    public int Player_Power;
    public float Player_Speed = 5f;
    public float Player_Jumpforce = 5f;
    public int Player_Life = 3;

    public float Floor;
    
    public bool Player_Jumping;
    public int Jump_Cnt;

    bool Dashing;
    public float Dash_Cnt;
    public float Dash_FullTime;

    public float DashForce;
    public float StartDashTimer;

    float CurrentDashTimer;
    float DashDirection;

    bool isDashing;

    public int Player_Vec;

    // Skill
    public float Skill_A_Time;
    public float Skill_S_Time;
    public float Skill_D_Time;

    public bool Skill_A_On;
    public bool Skill_S_On;
    public bool Skill_D_On;

    public int SkillA_Power;
    public int SkillS_Power;

    // Start is called before the first frame update
    void Start()
    {
        Player_Rigid = GetComponent<Rigidbody2D>();
        Player_Renderer = GetComponent<SpriteRenderer>();
        wolf_Control = GameObject.Find("Wolf").GetComponent<Wolf_Control>();
        bangtan_Ctrl = GameObject.Find("Bangtan").GetComponent<Bangtan_Ctrl>();

        Attack.SetActive(false);
    }

    void Update()
    {
        Skill_A_Time += Time.deltaTime;
        Skill_S_Time += Time.deltaTime;

        // Died ∏∏µÈæÓæﬂµ 
        #region
        #endregion

        // Move
        #region
        // Move
        float h = Input.GetAxisRaw("Horizontal");

        Player_Rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Player_Renderer.flipX = false;
            Attack.transform.localPosition = new Vector2(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Player_Renderer.flipX = true;
            Attack.transform.localPosition = new Vector2(-1, 0);
        }

        if (Player_Rigid.velocity.x > Player_Speed)
            Player_Rigid.velocity = new Vector2(Player_Speed, Player_Rigid.velocity.y);
        else if (Player_Rigid.velocity.x < Player_Speed * (-1))
            Player_Rigid.velocity = new Vector2(Player_Speed * (-1), Player_Rigid.velocity.y);

        #endregion

        // Jump
        #region
        // Jump
        if (Input.GetKeyDown(KeyCode.C) && Jump_Cnt > 0 && Player_Jumping == false)
        {
            if (this.transform.position.y > 0)
            {
                Player_Jumping = true;
                Jump_Cnt--;
                Player_Rigid.AddForce(Vector2.up * Player_Jumpforce, ForceMode2D.Impulse);
                Player_Jumping = false;
            }
            else if (this.transform.position.y < 0)
            {
                Player_Jumping = true;
                Jump_Cnt--;
                Player_Rigid.AddForce(Vector2.down * Player_Jumpforce, ForceMode2D.Impulse);
                Player_Jumping = false;
            }
        }
        
        #endregion

        // Dash
        #region
        // Dash
        if (Input.GetKeyDown(KeyCode.Z) && h != 0 && Dash_Cnt > 0)
        {
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
            Dashing = true;
            Player_Rigid.velocity = transform.right * DashDirection * DashForce;

            CurrentDashTimer -= Time.deltaTime;

            if (CurrentDashTimer <= 0)
            {
                isDashing = false;
                Dashing = false;
            }
        }
        #endregion

        // Skill(A)
        if (Input.GetKeyDown(KeyCode.A) && Skill_A_Time >= 7)
        {
            Skill_A_Time = 0;
            if (Player_Renderer.flipX == false)
                Player_Vec = 1;
            else if (Player_Renderer.flipX == true)
                Player_Vec = -1;

            Instantiate(Skill_A, new Vector2(transform.localPosition.x, transform.localPosition.y + 0.5f), Quaternion.identity);
            Skill_A_On = true;
        }

        // Skill(S)
        if (Input.GetKeyDown(KeyCode.S) && Skill_S_Time >= 14)
        {
            Skill_S_Time = 0;
            Instantiate(SKill_S, new Vector2(transform.localPosition.x, transform.localPosition.y + 0.5f), Quaternion.identity);
            Skill_S_On = true;
        }

        // The World (Skill D)
        



        // Attack
        if (Input.GetKeyDown(KeyCode.X))
        {
            //RaycastHit2D Skill_A_hit = Physics2D.BoxCast(transform.position, 
            //    new Vector2(8, 1), 0, new Vector2(1, 0), 0);

            //if (Skill_A_hit.transform != null && Skill_A_hit.transform.tag == "Enermy")
            //{
            //    Destroy(Skill_A_hit.transform.gameObject);
            //}

            Attack.gameObject.SetActive(true);

            if (Player_Renderer.flipX == false)
            {
                Attack.transform.localPosition = new Vector2(1, 0.5f);
            }
            else if (Player_Renderer.flipX == true)
            {
                Attack.transform.localPosition = new Vector2(-1, 0.5f);
            }

            Invoke("Attack_Del", 0.1f);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Ground")
        {
            Debug.Log("∂•");
            Jump_Cnt = 2;
            Player_Jumping = false;
        }
        else
        {
            Debug.Log("¡°«¡¡ﬂ");
            Player_Jumping = true;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bite" && Dashing == false)
        {
            Player_Hp -= wolf_Control.Wolf_Power;
        }

        if (collision.gameObject.tag == "Bangtan_Attack" && Dashing == false)
        {
            Player_Hp -= bangtan_Ctrl.Bangtan_Power;
        }  

        if (collision.gameObject.tag == "Bangtan_Rush" && Dashing == false)
        {
            Player_Hp -= 15;
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

    void Attack_Del()
    {
        Attack.gameObject.SetActive(false);
    }
    
}
