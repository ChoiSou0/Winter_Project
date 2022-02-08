using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bangtan_Ctrl : MonoBehaviour
{
    public GameObject Bangtan_Attack;
    public Transform target;

    public int Bangtan_Hp;
    public int Bangtan_Power;
    public int Amur;
    public float Speed;
    public float DashTime;
    public float DashingTime;
    public float DashPower;
    public int Vec;

    public bool Dashing;

    private Bangtan_MoveRange moveRange;
    private Bangtan_AttackRange attackRange;
    private Bangtan_Dash_Range dash_Range;
    private SpriteRenderer spriteRenderer;
    private Player_Control player_Control;

    // Start is called before the first frame update
    void Start()
    {
        moveRange = GameObject.Find("Bangtan_Move_Range").GetComponent<Bangtan_MoveRange>();
        attackRange = GameObject.Find("Bangtan_Attack_Range").GetComponent<Bangtan_AttackRange>();
        dash_Range = GameObject.Find("Bangtan_Dash_Range").GetComponent <Bangtan_Dash_Range>();
        player_Control = GameObject.Find("Player").GetComponent<Player_Control>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DashTime += Time.deltaTime;

        // Rush
        if (moveRange.isMove == true && attackRange.Attacked == false && dash_Range.Dashed == true)
        {
            if (DashTime >= 15)
            {
                DashTime = 0;
                Dashing = true;
                if (target.transform.position.x > this.transform.position.x)
                    Vec = 1;
                else
                    Vec = -1;

            }

        }

        if (Dashing == true && DashingTime <= 0.5f)
        {
            transform.Translate(Vector2.right * DashPower * Vec * Time.deltaTime);
            DashingTime += Time.deltaTime;
            if (DashingTime >= 0.5f)
            {
                DashingTime = 0;
                Dashing = false;
            }

        }

        // Attack
        if (moveRange.isMove == true && attackRange.Attacked == true && dash_Range.Dashed == true && Dashing == false)
        {
            Bangtan_Attack.SetActive(true);
            if (target.transform.position.x > this.transform.position.x)
            {
                spriteRenderer.flipX = true;
                Bangtan_Attack.transform.localPosition = new Vector2(1.2f, 0.9f);
            }
            else
            {
                spriteRenderer.flipX = false;
                Bangtan_Attack.transform.localPosition = new Vector2(-1.2f, 0.9f);
            }

            
            Invoke("AttackTime", 0.5f);
        }
        else if (moveRange.isMove == true && attackRange.Attacked == false && dash_Range.Dashed == true && Dashing == false)
        {
            FollowPlayer();
        }

    }

    void FollowPlayer()
    {
        target = GameObject.Find("Player").transform;

        if (target.transform.position.x > this.transform.position.x)
        {
            this.spriteRenderer.flipX = true;
            transform.position = new Vector2(transform.position.x + Speed, transform.position.y);
        }
        else
        {
            this.spriteRenderer.flipX = false;
            transform.position = new Vector2(transform.position.x - Speed, transform.position.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            Bangtan_Hp -= player_Control.Player_Power - Amur;
            Invoke("Hiting", 0.5f);
        }
    }

    void AttackTime()
    {
        Bangtan_Attack.SetActive(false);
    }

    void Hiting()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
