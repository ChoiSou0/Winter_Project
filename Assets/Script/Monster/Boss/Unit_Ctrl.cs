using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    private Animator animatior;
    private Player_Control player;
    public int Unit_Hp;
    public float LifeTime;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        gameManager = GameManager.Instance;
        player = GameManager.Instance.player;
        animatior = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Unit_Hp <= 0)
        {
            SoundManager.Instance.Play("Destory");
            animatior.SetBool("isDestroy", true);
            LifeTime += Time.deltaTime;

            if (LifeTime >= 0.5f)
            {
                gameManager.Ruin_Unit += 1;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            StartCoroutine(HIT());
            Debug.Log("맞음1");
            Unit_Hp -= player.Player_Power;
        }

        if (collision.gameObject.tag == "Skill_A")
        {
            Debug.Log("맞음2");
            StartCoroutine(HIT());
            Unit_Hp -= player.SkillA_Power + player.Player_Power;
        }

        if (collision.gameObject.tag == "Skill_S")
        {
            Debug.Log("맞음3");
            StartCoroutine(HIT());
            Unit_Hp -= player.SkillS_Power + player.Player_Power;
        }

    }

    IEnumerator HIT()
    {
        Debug.Log("1111");
        sprite.color = new Color(255,146,146,255);
        yield return new WaitForSecondsRealtime(1f);
        sprite.color = new Color(255, 255, 255, 255);
        yield return 0;
    }

}
