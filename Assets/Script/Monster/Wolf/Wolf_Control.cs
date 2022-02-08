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
        animator.SetBool("isDied", false);
        animator.SetBool("isIdle", false);
        animator.SetBool("isAttack", false);
        animator.SetBool("isHit", false);
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
            Backing = true;
            animator.SetBool("isDied", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isAttack", false);
            animator.SetBool("isHit", true);
            animator.SetBool("isRun", false);

            if (target.transform.position.x > this.transform.position.x)
            {
                while (BackTime <= 0.5f)
                {
                    transform.Translate(Vector2.right * backPower  * -1 * Time.deltaTime);
                    BackTime += Time.deltaTime;
                }
            }
            else
            {
                while (BackTime <= 0.5f)
                {
                    transform.Translate(Vector2.right * backPower * Time.deltaTime);
                    BackTime += Time.deltaTime;
                }
            }

            BackTime = 0;
            Backing = false;
            animator.SetBool("isDied", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isAttack", false);
            animator.SetBool("isHit", true);
            animator.SetBool("isRun", false);

        }

    }

    void AttackBite()
    {
        Attacked = true;
        Bite.SetActive(true);
        animator.SetBool("isDied", false);
        animator.SetBool("isIdle", false);
        animator.SetBool("isAttack", true);
        animator.SetBool("isHit", false);
        animator.SetBool("isRun", false);

        if (target.transform.position.x > this.transform.position.x)
        {
            Bite.transform.localPosition = new Vector2(1.3f, 0);
        }
        else
        {
            Bite.transform.localPosition = new Vector2(-1.3f, 0);
        }

        //Bite.SetActive(false);
        animator.SetBool("isDied", false);
        animator.SetBool("isIdle", false);
        animator.SetBool("isAttack", true);
        animator.SetBool("isHit", false);
        animator.SetBool("isRun", false);
        Invoke("Del", 2);
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
