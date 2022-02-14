using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Control : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D Wolf_rigid;
    private Player_Control playerControl;
    private Animator animator;

    private AttackRange attackRange;
    private MoveRange moveRange;

    public GameObject Bite;
    public GameObject Move;

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
    public float AttackTime;

    public float backPower;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<Player_Control>();
        attackRange = GameObject.Find("Wolf_Attack_Range").GetComponent<AttackRange>();
        moveRange = GameObject.Find("Wolf_Move_Range").GetComponent<MoveRange>();
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
                Backing = false;
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

        if (moveRange.WolfMove == false && Ding == false)
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

        if (Attacked == true && AttackTime <= 2)
        {
            AttackTime += Time.deltaTime;

            if (AttackTime >= 0.1f)
                animator.SetBool("isAttack", false);

        }

        // Attack And Follow
        if (attackRange.Wolf_Attack == true && Backing == false && OneAttack == false && moveRange.WolfMove == true && Ding == false)
        {
            AttackBite();
            OneAttack = true;
        }
        else if (attackRange.Wolf_Attack == false && Attacked == false && Backing == false && moveRange.WolfMove == true && Ding == false)
        {
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        animator.SetBool("isRun", true);
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
            Debug.Log("¸Â¾Ò¾î");
            Hp -= playerControl.Player_Power;
            animator.SetBool("isHit", true);
            Backing = true;
           
        }

    }

    void AttackBite()
    {
        Attacked = true;
        Bite.SetActive(true);
        animator.SetBool("isAttack", true);

        //Bite.SetActive(false);
    }

    void Nukback()
    {
        Wolf_rigid.AddRelativeForce(new Vector2(0f, 0f));
        Backing = false;
    }

    void Del()
    {
        Attacked = false;
        OneAttack = false;
        Bite.SetActive(false);
    }

    void Idle()
    {
        if (moveVec > 0)
        {
            spriteRenderer.flipX = false;
            moveVec = -1;
        }
        else if (moveVec < 0)
        {
            spriteRenderer.flipX = true;
            moveVec = 1;
        }
        moveMax = 0;
        moving = false;
    }
    
}
