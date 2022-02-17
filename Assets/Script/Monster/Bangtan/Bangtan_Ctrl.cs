using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bangtan_Ctrl : MonoBehaviour
{
    private Animator animator;
    private GameManager gameManager;

    public GameObject Bangtan_Attack;
    public GameObject Bangtan_Rush;
    public Transform target;

    public int Bangtan_Hp;
    public int Bangtan_Power;
    public int Amur;
    public float Speed;
    public float DashTime;
    public float DashingTime;
    public float DashPower;
    public float AttackTime;
    public float RGB;
    public float HitTime;
    public int SkillS_Vec;
    public float SkillS_HitTime;
    public float SkillS_HitPower;
    public int Vec;

    public bool Dashing;
    public bool Hited;
    public bool Attacking;
    public bool Ding;
    public bool SkillS_Hit;

    
    private Bangtan_AttackRange attackRange;
    private Bangtan_MoveRange moveRange;
    private Bangtan_Dash_Range dashRange;
    private SpriteRenderer spriteRenderer;
    private Player_Control player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;
        gameManager = GameManager.Instance;
        attackRange = GameManager.Instance.bangtan_AttackRange;
        moveRange = GameManager.Instance.bangtan_MoveRange;
        dashRange = GameManager.Instance.bangtan_DashbRange;

        //Bangtan_Attack = GameManager.Instance.Bangtan_Attack;
        //Bang
        target = GameManager.Instance.target;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        RGB = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Bangtan_Rush.transform.localPosition = new Vector2(0, 0.95f);
        DashTime += Time.deltaTime;

        if (SkillS_Hit == true && SkillS_HitTime <= 1)
        {
            animator.SetBool("isHit", true);
            if (SkillS_HitTime <= 1)
                transform.Translate(Vector2.right * SkillS_Vec * SkillS_HitPower * Time.deltaTime);
            SkillS_HitTime += Time.deltaTime;
            if (SkillS_HitTime >= 0.1f)
                animator.SetBool("isHit", false);

            if (SkillS_HitTime >= 1)
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
                
            }

            if (SkillS_HitTime >= 4)
            {
                SkillS_Hit = false;
                SkillS_HitTime = 0;
            }
        }

        if (Hited == true && HitTime <= 0.5f)
        {
            animator.SetBool("isHit", true);
            HitTime += Time.deltaTime;
            if (HitTime >= 0.1f)
                animator.SetBool("isHit", false);

            if (HitTime >= 0.5f)
            {
                HitTime = 0;
                spriteRenderer.color = new Color(1, 1, 1, 1);
                Hited = false;
            }
        }

        // Die
        if (Bangtan_Hp <= 0)
        {
            animator.SetBool("isDied", true);
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

        // Rush
        if (moveRange.isMove == true && dashRange.Dashed == true && SkillS_Hit == false && gameManager.Skill_D_On == false)
        {
            if (DashTime >= 15)
            {
                animator.SetBool("isRush", true);
                DashTime = 0;
                Dashing = true;
                if (target.transform.position.x > this.transform.position.x)
                    Vec = 1;
                else
                    Vec = -1;

            }

        }

        if (Dashing == true && DashingTime <= 0.5f && SkillS_Hit == false && gameManager.Skill_D_On == false)
        {
            Bangtan_Rush.SetActive(true);
            transform.Translate(Vector2.right * DashPower * Vec * Time.deltaTime);
            DashingTime += Time.deltaTime;

            if (DashingTime >= 0.5f)
            {
                DashingTime = 0;
                animator.SetBool("isRush", false);
                Dashing = false;
                Bangtan_Rush.SetActive(false);
            }

        }

        // Attack
        if (Attacking == true && AttackTime <= 1.5f && SkillS_Hit == false && gameManager.Skill_D_On == false)
        {
            animator.SetBool("isAttack", true);
            AttackTime += Time.deltaTime;

            if (AttackTime >= 0.1f)
                Bangtan_Attack.SetActive(false);
            if (AttackTime >= 0.7f)


            if (AttackTime >= 1.5f)
            {
                AttackTime = 0;
                Attacking = false;
            }
        }

        if (moveRange.isMove == true && attackRange.Attacked == true && Dashing == false && Attacking == false && Ding == false && SkillS_Hit == false && gameManager.Skill_D_On == false)
        {
            Attacked();
        }
        else if (moveRange.isMove == true && Dashing == false && Attacking == false && Ding == false && SkillS_Hit == false && gameManager.Skill_D_On == false)
        {
            FollowPlayer();
        }

    }

    void FollowPlayer()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isRun", true);
        

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
            Hited = true;
            Bangtan_Hp -= player.Player_Power - Amur;
        }

        if (collision.gameObject.tag == "Skill_A")
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            Hited = true;
            Bangtan_Hp -= player.SkillA_Power + player.Player_Power - Amur;
        }

        if (collision.gameObject.tag == "Skill_S")
        {
            if (Dashing == true)
            {
                DashingTime = 0;
                Dashing = false;
                Bangtan_Rush.SetActive(false);
            }

            if (Attacking == true)
            {
                Bangtan_Attack.SetActive(false);
                Attacking = false;
            }

            if (target.transform.position.x > this.transform.position.x)
            {
                SkillS_Vec = -1;
            }
            else
            {
                SkillS_Vec = 1;
            }

            spriteRenderer.color = new Color(1, 0, 0, 1);
            SkillS_Hit = true;
            Bangtan_Hp -= player.SkillS_Power + player.Player_Power - Amur;
        }
    }

    void Attacked()
    {
        Attacking = true;
        Bangtan_Attack.SetActive(true);
        if (target.transform.position.x > this.transform.position.x)
        {
            spriteRenderer.flipX = true;
            Bangtan_Attack.transform.localPosition = new Vector2(0.9f, 0.9f);
        }
        else
        {
            spriteRenderer.flipX = false;
            Bangtan_Attack.transform.localPosition = new Vector2(-0.9f, 0.9f);
        }

    }

}
