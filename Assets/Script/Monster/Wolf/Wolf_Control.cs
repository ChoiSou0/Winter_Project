using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Control : MonoBehaviour
{
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D Wolf_rigid;
    private Player_Control playerControl;
    private Animator animator;

    private AttackRange attackRange;
    private MoveRange moveRange;

    public GameObject Bite;

    public Transform target;
    public float velocity;
    public float Speed;
    public int Hp;
    public float Wolf_Power;
    public float RGB = 255;
    public bool Ding;
    
    public float Hold;
    public int moveVec;
    public float moveMax;
    public bool moving;
    
    public float BackTime;
    public bool Attacked = false;
    public bool OneAttack = false;
    public bool Backing = false;
    public float Xpower;
    public float Ypower;
    public float AttackTime;
    public int AttackVec;
    public float KullTime;
    public bool SkillS_Back;

    public float backPower;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameManager.Instance.player;
        attackRange = GameManager.Instance.wolfAttackRange;
        moveRange = GameManager.Instance.wolfMoveRange;
        gameManager = GameManager.Instance;
        target = GameManager.Instance.target;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Wolf_rigid = GetComponent<Rigidbody2D>();
        Bite.SetActive(false);
        moveVec = -1;
        RGB = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Bite.transform.localPosition = new Vector2(-0.2f, 0.5f);
        if (OneAttack == true)
            KullTime += Time.deltaTime;
        if (KullTime >= 2)
        {
            OneAttack = false;
            KullTime = 0;
        }

        if (gameManager.Skill_D_On == true)
        {
            Wolf_rigid.gravityScale = 0;
            animator.speed = 0;
        }
        else
        {
            Wolf_rigid.gravityScale = 1;
            animator.speed = 1;
        }

        if (Backing == true && BackTime <= 0.5f)
        {
            BackTime += Time.deltaTime;
            transform.Translate(Vector2.right * playerControl.Player_Vec * backPower * Time.deltaTime);
            if (BackTime >= 0.1f)
            {
                animator.SetBool("isHit", false);
            }

            if (BackTime >= 0.5f)
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
                Backing = false;
                BackTime = 0;
            }
        }

        if (SkillS_Back == true && BackTime <= 1)
        {
            BackTime += Time.deltaTime;
            transform.Translate(Vector2.right * playerControl.Player_Vec * backPower * Time.deltaTime);
            if (BackTime >= 0.1f)
            {
                animator.SetBool("isHit", false);
            }

            if (BackTime >= 1)
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
                
            }

            if (BackTime >= 4)
            {
                SkillS_Back = false;
                BackTime = 0;
            }
        }

        if (Hp <= 0)
        {
            Ding = true;
            animator.SetBool("isDied", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isAttack", false);
            animator.SetBool("isHit", false);
            animator.SetBool("isRun", false);
            RGB -= Time.deltaTime;
            Debug.Log(RGB);
            spriteRenderer.color = new Color(1, 1, 1, RGB);
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            if (RGB <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (moveRange.WolfMove == false && Ding == false && gameManager.Skill_D_On == false)
        {
            if (moving == false)
            {
                animator.SetBool("isRun", true);
                animator.SetBool("isIdle", false);
                this.transform.position = new Vector2(transform.position.x + (Speed * moveVec), transform.position.y);
                moveMax += Time.deltaTime;
            }

            if (moveMax >= 3)
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isIdle", true);
                moving = true;
                //animator.SetBool("isIdle", true);
                Invoke("Idle", 1f);
                moveMax -= 0.1f;
            }

        }

        if (Attacked == true && AttackTime <= 2 && gameManager.Skill_D_On == false)
        {
            AttackTime += Time.deltaTime;

            if (AttackTime <= 0.5f)
            {
                transform.Translate(Vector2.right * Xpower * AttackVec * Time.deltaTime);

                if (AttackTime <= 0.25f)
                    transform.Translate(Vector2.up * Ypower * Time.deltaTime);
            }

            if (AttackTime >= 0.1f)
                animator.SetBool("isAttack", false);

            if (AttackTime >= 0.5f)
            {
                AttackTime = 0;
                Attacked = false;
                Bite.SetActive(false);
            }

        }

        // Attack And Follow
        if (attackRange.Wolf_Attack == true && Backing == false && OneAttack == false && moveRange.WolfMove == true && Ding == false && gameManager.Skill_D_On == false)
        {
            AttackBite();
            OneAttack = true;
        }
        else if (Attacked == false && Backing == false && moveRange.WolfMove == true && Ding == false && gameManager.Skill_D_On == false)
        {
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        animator.SetBool("isRun", true);
        animator.SetBool("isIdle", false);
        target = GameObject.Find("Player").transform;

        if (target.transform.position.x > this.transform.position.x)
        {
            this.spriteRenderer.flipX = true;
            this.transform.position = new Vector2(transform.position.x + Speed, transform.position.y);
        }
        else
        {
            this.spriteRenderer.flipX = false;
            this.transform.position = new Vector2(transform.position.x - Speed, transform.position.y);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.tag == "Attack")
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            Hp -= playerControl.Player_Power;
            animator.SetBool("isHit", true);
            Backing = true;
           
        }

        if (collision2D.gameObject.tag == "Skill_A")
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            Hp -= playerControl.SkillA_Power + playerControl.Player_Power;
            animator.SetBool("isHit", true);
            Backing = true;
        }

        if (collision2D.gameObject.tag == "Skill_S")
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            Hp -= playerControl.SkillS_Power + playerControl.Player_Power;
            animator.SetBool("isHit", true);
            SkillS_Back = true;
        }

    }

    void AttackBite()
    {
        Attacked = true;
        Bite.SetActive(true);
        animator.SetBool("isAttack", true);

        if (target.transform.position.x > this.transform.position.x)
        {
            AttackVec = 1;
            this.spriteRenderer.flipX = true;
        }
        else
        {
            this.spriteRenderer.flipX = false;
            AttackVec = -1;
        }

        //Bite.SetActive(false);
    }

    void Idle()
    {
        if (moveVec > 0)
        {
            spriteRenderer.flipX = false;
            moveVec = -1;
        }
        else
        {
            spriteRenderer.flipX = true;
            moveVec = 1;
        }
        moveMax = 0;
        moving = false;
    }
    
}
