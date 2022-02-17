using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillS_Ctrl : MonoBehaviour
{
    private Transform SkillA_tranform;
    private Player_Control player;
    public float LifeTime = 1;
    public float SkillA_Scale;
    public float Speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player_Control>();
        SkillA_tranform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTime >= 0 && player.Skill_S_On == true)
        {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.5f);
            SkillA_Scale += Time.deltaTime * Speed;
            if (SkillA_Scale <= 14)
                SkillA_tranform.localScale = new Vector3(SkillA_Scale, SkillA_Scale, 1);
            LifeTime -= Time.deltaTime;
        }

        if (LifeTime <= 0)
        {
            Destroy(this.gameObject);
            SkillA_Scale = 1;
            player.Skill_S_On = false;
            player.SkillS_ani = 0;
        }
    }
}
