using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Control : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D Wolf_rigid;
    private Player_Control playerControl;

    private AttackRange attackRange;
    private MoveRange moveRange;

    public GameObject Bite;
    public GameObject Move;

    public Transform target;
    public float velocity;
    public float Speed;
    public int Hp;
    public int Power;

    public float Hold;

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
        Wolf_rigid = GetComponent<Rigidbody2D>();
        Bite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }

        if (moveRange.WolfMove == false)
        {
            if (target.transform.position.x > this.transform.position.x)
            {
                this.spriteRenderer.flipX = true;
                while ()
                {
                    this.transform.position = new Vector2(transform.position.x - , transform.position.y);
                }
            }
            else
            {
                this.spriteRenderer.flipX = false;
                while ()
                {
                    this.transform.position = new Vector2(transform.position.x + , transform.position.y);
                }
            }
        }

        if (attackRange.Wolf_Attack == true && Backing == false && OneAttack == false)
        {
            AttackBite();
            OneAttack = true;
        }

        else if (attackRange.Wolf_Attack == false && Attacked == false && Backing == false)
        {
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        target = GameObject.Find("Player").transform;

        if (target.transform.position.x > this.transform.position.x)
        {
            this.spriteRenderer.flipX = true;
            this.transform.position = new Vector2(transform.position.x + Speed, 1);
        }
        else
        {
            this.spriteRenderer.flipX = false;
            this.transform.position = new Vector2(transform.position.x - Speed, 1);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.tag == "Attack")
        {
            Debug.Log("¸Â¾Ò¾î");
            Hp -= playerControl.Player_Power;
            Backing = true;

            if (target.transform.position.x > this.transform.position.x)
            {
                while (BackTime <= 0.5f)
                {
                    transform.position = new Vector2(transform.position.x - (0.01f), transform.position.y);
                    BackTime += Time.deltaTime;
                }
            }
            else
            {
                while (BackTime <= 0.5f)
                {
                    transform.position = new Vector2(transform.position.x + (0.01f), transform.position.y);
                    BackTime += Time.deltaTime;
                }
            }

            BackTime = 0;
            Backing = false;

        }

    }

    void AttackBite()
    {
        Attacked = true;
        Bite.SetActive(true);

        if (target.transform.position.x > this.transform.position.x)
        {
            Bite.transform.localPosition = new Vector2(1.3f, 0);
        }
        else
        {
            Bite.transform.localPosition = new Vector2(-1.3f, 0);
        }

        //Bite.SetActive(false);
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
}
