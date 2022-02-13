using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBufer_Ctrl : MonoBehaviour
{
    private DeBufer_AttackRange attackRange;
    private DeBufer_MoveRange moveRange;
    private DeBufer_TelRange telRange;
    private Player_Control player_Ctrl;
    private SpriteRenderer spriteRenderer;

    public Transform target;

    public GameObject player;
    public GameObject DeBufer_Attack;
    public GameObject DeBufer_Magic;

    public float DeBufer_Speed;
    public int DeBufer_Hp;
    public int DeBufer_Amur;
    public int DeBufer_Power;

    public int TelRandom;
    public float TelTime;
    public float AttackTime;
    public float NukBack_Time;
    public float NukBack_Power;
    public float MagicTime;
    public float RGB;

    public bool Ding;
    public bool Hiting;
    public bool Attacking;
    public bool Magicing;
    public bool SkillS_Hiting;

    // Start is called before the first frame update
    void Start()
    {
        attackRange = GameObject.Find("DeBufer_Attack_Range").GetComponent<DeBufer_AttackRange>();
        moveRange = GameObject.Find("DeBufer_Move_Range").GetComponent<DeBufer_MoveRange>();
        telRange = GameObject.Find("DeBufer_Tel_Range").GetComponent<DeBufer_TelRange>();
        player_Ctrl = GameObject.Find("Player").GetComponent<Player_Control>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MagicTime += Time.deltaTime;
        TelTime += Time.deltaTime;

        // Die
        if (DeBufer_Hp <= 0)
        {
            Ding = true;
            RGB -= Time.deltaTime;
            Debug.Log(RGB);
            spriteRenderer.color = new Color(1, 1, 1, RGB);
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            if (RGB <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        // Magic
        if (MagicTime >= 60 && Magicing == false && moveRange.isMove == true)
        {
            MagicTime = 0;
            //DeBufer_Magic.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.5f);
            Instantiate(DeBufer_Magic, new Vector2(target.transform.position.x, target.transform.position.y + 0.5f), Quaternion.identity);
            Magicing = true;
        }

        // Tel
        if (TelTime >= 5 && moveRange.isMove == true && telRange.Teling == true && Ding == false)
        {
            float TelPos = Random.Range(1, 4);
            TelRandom = Random.Range(1, 3);

            if (TelRandom == 1)
            {
                transform.position = new Vector2(target.position.x - TelPos, target.position.y);

            }
            if (TelRandom == 2)
            { 
                transform.position = new Vector2(target.position.x + TelPos, target.position.y);

            }

        }

        // Hit
        if (Hiting == true && NukBack_Time <= 0.5f && Ding == false)
        {
            NukBack_Time += Time.deltaTime;
            transform.Translate(Vector2.right * NukBack_Power * player_Ctrl.Player_Vec * Time.deltaTime);
            if (NukBack_Time >= 0.5f)
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
                NukBack_Time = 0;
                Hiting = false;
            }
        }

        // SkillS_Hit
        if (SkillS_Hiting == true && NukBack_Time <= 1 && Ding == false)
        {
            NukBack_Time += Time.deltaTime;
            transform.Translate(Vector2.right * NukBack_Power * player_Ctrl.Player_Vec * Time.deltaTime);
            if (NukBack_Time >= 1)
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
                NukBack_Time = 0;
                SkillS_Hiting = false;
            }
        }

        // AttackTime
        #region
        if (Attacking == true && AttackTime <= 1)
        {
            AttackTime += Time.deltaTime;
            if (AttackTime >= 1)
            {
                AttackTime = 0;
                Attacking = false;
            }
        }
        #endregion

        // Attack and Move
        #region
        if (moveRange.isMove == true && attackRange.StartAttack == true && Attacking == false && Hiting == false && SkillS_Hiting == false && Ding == false)
        {
            Attack();
        }
        else if (moveRange.isMove == true && attackRange.StartAttack == false && Attacking == false && Hiting == false && SkillS_Hiting == false && Ding == false)
        {
            Follow();
        }
    }

    void Follow()
    {
        if (target.transform.position.x > this.transform.position.x)
        {
            this.spriteRenderer.flipX = true;
            transform.position = new Vector2(transform.position.x + DeBufer_Speed, transform.position.y);
        }
        else
        {
            this.spriteRenderer.flipX = false;
            transform.position = new Vector2(transform.position.x - DeBufer_Speed, transform.position.y);
        }
    }

    void Attack()
    {
        Attacking = true;
        DeBufer_Attack.SetActive(true);
        if (target.transform.position.x > this.transform.position.x)
        {
            spriteRenderer.flipX = true;
            DeBufer_Attack.transform.localPosition = new Vector2(0.6f, 0.9f);
        }
        else
        {
            spriteRenderer.flipX = false;
            DeBufer_Attack.transform.localPosition = new Vector2(-0.6f, 0.9f);
        }

        Invoke("Attackfalse", 0.05f);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            DeBufer_Hp -= player_Ctrl.Player_Power - DeBufer_Amur;
            Hiting = true;
        }

        if (collision.gameObject.tag == "Skill_A")
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            DeBufer_Hp -= player_Ctrl.SkillA_Power + player_Ctrl.Player_Power - DeBufer_Amur;
            Hiting = true;
        }

        if (collision.gameObject.tag == "Skill_S")
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            DeBufer_Hp -= player_Ctrl.SkillS_Power + player_Ctrl.Player_Power - DeBufer_Amur;
            SkillS_Hiting = true;
        }


    }

    void Attackfalse()
    {
        DeBufer_Attack.SetActive(false);
    }

}
