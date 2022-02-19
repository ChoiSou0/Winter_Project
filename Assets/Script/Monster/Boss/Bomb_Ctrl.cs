using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Ctrl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform Bomb_transform;
    private Player_Control player;
    private Boss_Ctrl boss;

    public Sprite Boss_EX;

    public bool Pop;

    public float LifeTime;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Bomb_transform = GetComponent<Transform>();
        player = GameManager.Instance.player;
        boss = GameManager.Instance.boss_Ctrl;
        Pop = false;
        this.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        gameObject.tag = "Untagged";
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTime <= 0.6f)
        {
            LifeTime += Time.deltaTime;
            if(LifeTime <= 0.4f)
            {
                transform.Translate(Vector2.up * Speed * Time.deltaTime);
            }

            if (LifeTime >= 0.4f)
            {
                gameObject.tag = "Boss_Bomb";
                spriteRenderer.sprite = Boss_EX;
                Bomb_transform.localScale = new Vector3
                    (this.transform.localScale.x + Speed * Time.deltaTime, this.transform.localScale.y + Speed * Time.deltaTime);
            }

            if (LifeTime >= 0.6f)
            {
                boss.Attacking = false;
                boss.AttackTime = 0;
                Destroy(gameObject);
            }


        }
    }
}
