using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillA_Ctrl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Player_Control player;
    public float LifeTime = 0;
    public float Speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player_Control>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTime >= 0 && player.Skill_A_On == true)
        {
            if (player.Player_Vec > 0)
            {
                spriteRenderer.flipX = false;
                transform.Translate(Vector2.right * Speed * 1 * Time.deltaTime);
            }
            else if (player.Player_Vec < 0)
            {
                spriteRenderer.flipX = true;
                transform.Translate(Vector2.right * Speed * -1 * Time.deltaTime);
            }

            LifeTime -= Time.deltaTime;
        }

        if (LifeTime <= 0)
        {
            Destroy(this.gameObject);
            LifeTime = 0;
            player.Skill_A_On = false;
        }

    }

}
