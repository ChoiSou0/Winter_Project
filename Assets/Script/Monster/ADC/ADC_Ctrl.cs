using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADC_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Player_Control player;

    private Transform target;

    public GameObject FireBall1;
    public GameObject FireBall2;
    public GameObject FireBall3;

    public bool FireBall1_Spawn;
    public bool FireBall2_Spawn;
    public bool FireBall3_Spawn;

    public int ADC_Hp;
    public int ADC_Power;
    public int ADC_Amur;
    public float RGB;
    public bool Ding;

    public float AttackTime;
    public float Casting;
    public bool Cast;

    public bool Hited;
    public float BackTime;
    public float BackSpeed;

    public bool SkillS_Hit;
    public float SkillS_HitTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;
        gameManager = GameManager.Instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        target = GameManager.Instance.target;
        Cast = true;
    }

    // Update is called once per frame
    void Update()
    {
        AttackTime += Time.deltaTime;

        if (ADC_Hp <= 0)
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


        // Hit
        #region
        // Hit
        if (Hited == true && BackTime <= 0.2f)
        {
            animator.SetBool("isHit", true);
            BackTime += Time.deltaTime;
            transform.Translate(Vector2.right * BackSpeed * player.Player_Vec * Time.deltaTime);
            if (BackTime >= 0.2f)
            {
                animator.SetBool("isHit", false);
                Hited = false;
                BackTime = 0;
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }

        }

        // SkillS Hit
        if (SkillS_Hit == true && SkillS_HitTime <= 1)
        {
            animator.SetBool("isHit", true);
            SkillS_HitTime += Time.deltaTime;
            if (SkillS_HitTime <= 1)
                transform.Translate(Vector2.right * BackSpeed * player.Player_Vec * Time.deltaTime);

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
        #endregion


        // casting
        if (Casting <= 9 && Cast == true && AttackTime >= 3)
        {
            Casting += Time.deltaTime;

            if (Casting >= 1 && FireBall1_Spawn == false)
            {
                FireBall1_Spawn = true;
                animator.SetBool("isCasting", true);
                Instantiate(FireBall1, new Vector2(this.transform.position.x + 1.5f, this.transform.position.y + 1.75f), Quaternion.identity);
                //FireBall1.SetActive(true);
            }
            if (Casting >= 1.1f)
                animator.SetBool("isCasting", false);

            if (Casting >= 2 && FireBall2_Spawn == false)
            {
                FireBall2_Spawn = true;
                animator.SetBool("isCasting", true);
                Instantiate(FireBall2, new Vector2(this.transform.position.x, this.transform.position.y + 3.3f), Quaternion.identity);
                //FireBall2.SetActive(true);
            }
            if (Casting >= 2.1f)
                animator.SetBool("isCasting", false);

            if (Casting >= 3 && FireBall3_Spawn == false)
            {
                FireBall3_Spawn = true;
                animator.SetBool("isCasting", true);
                Instantiate(FireBall3, new Vector2(this.transform.position.x - 1.5f, this.transform.position.y + 1.75f), Quaternion.identity);
                //FireBall3.SetActive(true);
            }
            if (Casting >= 3.1f)
                animator.SetBool("isCasting", false);

            if (Casting >= 6)
            {
                animator.SetBool("isAttack", true);
                gameManager.FireBall1_On = true;
            }
            if (Casting >= 6.5f)
            animator.SetBool("isAttack", false);

            if (Casting >= 7)
            {
                animator.SetBool("isAttack", true);
                gameManager.FireBall2_On = true;
            }
            if (Casting >= 7.5f)
            animator.SetBool("isAttack", false);

            if (Casting >= 8)
            {
                animator.SetBool("isAttack", true);
                gameManager.FireBall3_On = true;
            }
            if (Casting >= 8.5f)
            animator.SetBool("isAttack", false);

            if (Casting >= 9)
            {
                AttackTime = 0;
                Casting = 0;
                FireBall1_Spawn = false;
                FireBall2_Spawn = false;
                FireBall3_Spawn = false;
            }
        }

        // see
        animator.SetBool("isIdle", true);
        if (target.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            Hited = true;
            ADC_Hp -= player.Player_Power - ADC_Amur;
            spriteRenderer.color = new Color(1, 0, 0, 1);
        }

        if (collision.gameObject.tag == "Skill_A")
        {
            Hited = true;
            ADC_Hp -= player.SkillA_Power + player.Player_Power - ADC_Amur;
            spriteRenderer.color = new Color(1, 0, 0, 1);
        }

        if (collision.gameObject.tag == "Skill_S")
        {
            SkillS_Hit = true;
            ADC_Hp -= player.SkillS_Power + player.Player_Power - ADC_Amur;
            spriteRenderer.color = new Color(1, 0, 0, 1);
        }
    }
}
