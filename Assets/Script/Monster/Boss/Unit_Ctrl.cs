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
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = GameManager.Instance.player;
        animatior = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Unit_Hp <= 0)
        {
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
            Debug.Log("맞음1");
            Unit_Hp -= player.Player_Power;
        }

        if (collision.gameObject.tag == "Skill_A")
        {
            Debug.Log("맞음2");
            Unit_Hp -= player.SkillA_Power + player.Player_Power;
        }

        if (collision.gameObject.tag == "Skill_S")
        {
            Debug.Log("맞음3");
            Unit_Hp -= player.SkillS_Power + player.Player_Power;
        }

    }

}
