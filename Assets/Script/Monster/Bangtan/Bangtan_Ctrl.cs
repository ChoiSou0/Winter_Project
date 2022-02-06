using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bangtan_Ctrl : MonoBehaviour
{
    public GameObject Bangtan_Attack;
    public Transform target;

    public int Bangtan_Hp;
    public int Amur;
    public float Speed;
    public float DashTime;

    public bool Dashing;

    private Bangtan_MoveRange moveRange;
    private Bangtan_AttackRange attackRange;
    private Bangtan_Dash_Range dash_Range;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        moveRange = GameObject.Find("Bangtan_Move_Range").GetComponent<Bangtan_MoveRange>();
        attackRange = GameObject.Find("Bangtan_Attack_Range").GetComponent<Bangtan_AttackRange>();
        dash_Range = GameObject.Find("Bangtan_Dash_Range").GetComponent <Bangtan_Dash_Range>();
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
                
            }

        }

        // Attack
        if (moveRange.isMove == false && attackRange.Attacked == true && dash_Range.Dashed == false && Dashing == false)
        {
            if (target.transform.position.x > this.transform.position.x)
            {
                spriteRenderer.flipX = true;
                Bangtan_Attack.transform.position = new Vector2(1, 0.9f);
                Bangtan_Attack.SetActive(true);
            }
            else
            {
                spriteRenderer.flipX = false;
                Bangtan_Attack.transform.position = new Vector2(-1, 0.9f);
                Bangtan_Attack.SetActive(true);
            }

            Bangtan_Attack.SetActive(false);
            Invoke("AttackTime", 0.5f);
        }
        else if (moveRange.isMove == true && attackRange.Attacked == false && dash_Range.Dashed == true)
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

        }
    }

    void AttackTime()
    {
        Dashing = false;
    }

}
