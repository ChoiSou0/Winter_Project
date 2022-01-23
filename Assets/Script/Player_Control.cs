using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    //[SerializeField] public LayerMask Nocheck;

    private Rigidbody2D Player_Rigid;

    public float Player_Speed = 5f;
    public float Player_Jumpforce = 5f;
    public int Player_Life = 3;

    public float Floor;
    
    public bool Player_Jumping;

    float movX;
    public float Dash_Cnt;
    public float Dash_FullTime;

    public float DashForce;
    public float StartDashTimer;

    float CurrentDashTimer;
    float DashDirection;

    bool isGrounded = false;
    bool isDashing;


    private bool Isdash = false;


    // Start is called before the first frame update
    void Start()
    {
        Player_Rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Player_Rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (Player_Rigid.velocity.x > Player_Speed)
            Player_Rigid.velocity = new Vector2(Player_Speed, Player_Rigid.velocity.y);
        else if (Player_Rigid.velocity.x < Player_Speed * (-1))
            Player_Rigid.velocity = new Vector2(Player_Speed * (-1), Player_Rigid.velocity.y);

        // Jump
        if (Input.GetButtonDown("Jump") && Player_Jumping == false)
        {
            Player_Rigid.AddForce(Vector2.up * Player_Jumpforce, ForceMode2D.Impulse);
        } 

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
            Player_Rigid.velocity = transform.right * DashDirection * DashForce;

            CurrentDashTimer -= Time.deltaTime;

            if (CurrentDashTimer <= 0)
            {
                isDashing = false;
            }
        }
        // Attack
        if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit2D Skill_A_hit = Physics2D.BoxCast(transform.position, 
                new Vector2(8, 1), 0, new Vector2(1, 0), 0);

            if (Skill_A_hit.transform != null && Skill_A_hit.transform.tag == "Enermy")
            {
                Destroy(Skill_A_hit.transform.gameObject);
            }
        }

        
    }

    void FixedUpdate()
    {
        Debug.DrawRay(Player_Rigid.position, Vector2.down, new Color(0, 1, 0));

        RaycastHit2D RayHit = Physics2D.Raycast(Player_Rigid.position, Vector2.down, 1, LayerMask.GetMask("Ground"));

        if (RayHit.collider != null && RayHit.distance < 0.5f)
        {
            Debug.Log("G");
            Player_Jumping = false;
        }
        else
        {
            Player_Jumping = true;
        }
    }

    void Dash_Full()
    {
        Dash_Cnt = 2;
    }
    
}
