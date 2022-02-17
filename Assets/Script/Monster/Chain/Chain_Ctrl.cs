using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    private Animator animator;
    private Player_Control player;
    private SpriteRenderer spriteRenderer;
    private Chain_AttackRange attackRange;
    private Chain_RestructionRange chain_RestructionRange;
    public Transform target;

    public GameObject Chain_Attack;
    public GameObject Chain_Restruction;

    public int Chain_Hp;
    public int Chain_Power;
    public int Chain_Amur;
    public float Chain_Speed;
    public bool Ding;
    public float RGB;

    public bool Attacking;
    public float AttackTime;
    public float RestructionTime;
    public bool NoChain;
    public bool ThrowChain;

    public bool Hiting;
    public float HitTime;
    public bool SkillS_Hit;
    public float SkillS_HitTime;
    public float BackPower;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;
        attackRange = GameManager.Instance.chain_AttackRange;
        gameManager = GameManager.Instance;
        target = GameManager.Instance.target;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        chain_RestructionRange = GameManager.Instance.chain_RestructionRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (Chain_Hp <= 0)
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

        if (Hiting == true && HitTime <= 0.5f)
        {
            animator.SetBool("isHit", true);
            spriteRenderer.color = new Color(1, 0, 0, 1);
            HitTime += Time.deltaTime;
            transform.Translate(Vector2.right * BackPower * player.Player_Vec * Time.deltaTime);

            if (HitTime >= 0.5f)
            {
                animator.SetBool("isHit", false);
                spriteRenderer.color = new Color(1, 1, 1, 1);
                HitTime = 0;
                Hiting = false;
            }

        }

        if (SkillS_Hit == true && SkillS_HitTime <= 1)
        {
            animator.SetBool("isHit", true);
            spriteRenderer.color = new Color(1, 0, 0, 1);
            SkillS_HitTime += Time.deltaTime;
            transform.Translate(Vector2.right * BackPower * player.Player_Vec * Time.deltaTime);

            if (SkillS_HitTime >= 1)
            {
                animator.SetBool("isHit", false);
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }

            if (SkillS_HitTime >= 4)
            {
                SkillS_Hit = false;
                SkillS_HitTime = 0;
            }

        }

        if (chain_RestructionRange.Restructioning == true)
        {
            animator.SetBool("isRestruction", true);
            NoChain = true;
            Chain_Speed = 0.04f;
            Instantiate(Chain_Restruction, new Vector2(this.transform.position.x, this.transform.position.y + 2), Quaternion.identity);
            chain_RestructionRange.Restructioning = false;
           
            
        }

        if (NoChain == true && RestructionTime <= 0.5f && gameManager.Skill_D_On == false)
        {
            ThrowChain = true;
            RestructionTime += Time.deltaTime;

            if (RestructionTime >= 0.5f)
            {
                animator.SetBool("isRestruction", false);
                ThrowChain = false;
            }
        }

        if (Attacking == true && AttackTime <= 1f && gameManager.Skill_D_On == false)
        {
            animator.SetBool("isAttack", true);
            AttackTime += Time.deltaTime;
            if (AttackTime >= 0.2f)
            {
                animator.SetBool("isAttack", false);
                Chain_Attack.SetActive(false);
            }

            if (AttackTime >= 1)
            {
                AttackTime = 0;
                Attacking = false;
            }
        }

        if (attackRange.Attacked == true && Attacking == false && Hiting == false && SkillS_Hit == false && ThrowChain == false && gameManager.Skill_D_On == false)
        {
            Attack();
        }
        else if (Hiting == false && Attacking == false && SkillS_Hit == false && ThrowChain == false && gameManager.Skill_D_On == false)
        {
            Follow();
        }
    }

    void Follow()
    {
        if (NoChain == false)
        {
            animator.SetBool("isRun", true);
            animator.SetBool("isRun2", false);
        }
        else
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isRun2", true);
        }

        if (target.transform.position.x > this.transform.position.x)
        {
            this.spriteRenderer.flipX = true;
            transform.position = new Vector2(transform.position.x + Chain_Speed, transform.position.y);
        }
        else
        {
            this.spriteRenderer.flipX = false;
            transform.position = new Vector2(transform.position.x - Chain_Speed, transform.position.y);
        }
    }

    void Attack()
    {
        Attacking = true;
        Chain_Attack.SetActive(true);
        if (target.transform.position.x > this.transform.position.x)
        {
            spriteRenderer.flipX = true;
            Chain_Attack.transform.localPosition = new Vector2(0.6f, 0.7f);
        }
        else
        {
            spriteRenderer.flipX = false;
            Chain_Attack.transform.localPosition = new Vector2(-0.6f, 0.7f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            Hiting = true;
            Chain_Hp -= player.Player_Power - Chain_Amur;
        }

        if (collision.gameObject.tag == "Skill_A")
        {
            Hiting = true;
            Chain_Hp -= player.SkillA_Power + player.Player_Power - Chain_Amur;
        }

        if (collision.gameObject.tag == "Skill_S")
        {
            SkillS_Hit = true;
            Chain_Hp -= player.SkillS_Power + player.Player_Power - Chain_Amur;
        }
    }
}
