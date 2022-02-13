using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADC_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private Player_Control player;

    private Transform target;

    public GameObject FireBall1;
    public GameObject FireBall2;
    public GameObject FireBall3;

    public int ADC_Hp;
    public int ADC_Power;
    public int ADC_Amur;

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
        player = GameObject.Find("Player").GetComponent<Player_Control>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        target = GameObject.Find("Player").transform;
        Cast = true;
    }

    // Update is called once per frame
    void Update()
    {
        AttackTime += Time.deltaTime;

        // Hit
        #region
        // Hit
        if (Hited == true && BackTime <= 0.2f)
        {
            BackTime += Time.deltaTime;
            transform.Translate(Vector2.right * BackSpeed * player.Player_Vec * Time.deltaTime);
            if (BackTime >= 0.2f)
            {
                Hited = false;
                BackTime = 0;
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }

        }

        // SkillS Hit
        if (SkillS_Hit == true && SkillS_HitTime <= 1)
        {
            SkillS_HitTime += Time.deltaTime;
            transform.Translate(Vector2.right * BackSpeed * player.Player_Vec * Time.deltaTime);
            if (SkillS_HitTime >= 1)
            {
                SkillS_Hit = false;
                SkillS_HitTime = 0;
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }
        }
        #endregion

        // casting
        if (Casting <= 8 && Cast == true)
        {
            Casting += Time.deltaTime;

            if (Casting >= 1)
            {
                FireBall1.SetActive(true);
            }

            if (Casting >= 2)
            {
                FireBall2.SetActive(true);
            }

            if (Casting >= 3)
            {
                FireBall3.SetActive(true);
            }

            if (Casting >= 6)
            {
                gameManager.FireBall1_On = true;
            }

            if (Casting >= 7)
            {
                gameManager.FireBall2_On = true;
            }

            if (Casting >= 8)
            {
                gameManager.FireBall3_On = true;
            }

        }

        // see
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
            spriteRenderer.color = new Color(1, 0, 0, 1);
        }

        if (collision.gameObject.tag == "Skill_A")
        {
            Hited = true;
            spriteRenderer.color = new Color(1, 0, 0, 1);
        }

        if (collision.gameObject.tag == "Skill_S")
        {
            SkillS_Hit = true;
            spriteRenderer.color = new Color(1, 0, 0, 1);
        }
    }
}
