using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Ctrl : MonoBehaviour
{
    private Boss_Ctrl boss;
    private Animator animator;
    private Player_Control player;

    public Vector2 Vec;
    public float LifeTime;
    public float Speed;
    public float HitTime;
    public bool Hiting;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameManager.Instance.boss_Ctrl;
        player = GameManager.Instance.player;
        animator = GetComponent<Animator>();
        Vec = (player.transform.position - this.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTime <= 7 && Hiting == false)
        {
            LifeTime += Time.deltaTime;
            transform.Translate(Vec * Speed * Time.deltaTime);

            if (this.transform.position.y < -1.67f)
            {
                boss.Attacking = false;
                boss.AttackTime = 0;
                Destroy(gameObject);
            }
            else if (this.transform.position.y > 27)
            {
                boss.Attacking = false;
                boss.AttackTime = 0;
                Destroy(gameObject);
            }
            else if (this.transform.position.x > 76)
            {
                boss.Attacking = false;
                boss.AttackTime = 0;
                Destroy(gameObject);
            }
            else if (this.transform.position.x < -32)
            {
                boss.Attacking = false;
                boss.AttackTime = 0;
                Destroy(gameObject);
            }

            if (LifeTime >= 7)
            {
                boss.Attacking = false;
                boss.AttackTime = 0;
                Destroy(gameObject);

            }
        }

        if (Hiting == true && HitTime <= 0.5f)
        {
            HitTime += Time.deltaTime;
            if (HitTime >= 0.5f)
            {
                boss.Attacking = false;
                boss.AttackTime = 0;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isHit", true);
            Hiting = true;
        }
    }
}
