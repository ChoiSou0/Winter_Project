using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    private Transform target;
    private Player_Control player;

    public GameObject Sheild;
    public GameObject Unit;
    public GameObject Fire;
    public GameObject Bomb;

    public bool Grogy;
    public bool Spawn_Unit;
    public bool Sheild_On;
    public bool Attacking;

    public int Bomb_Power;
    public int Fire_Power;
    public int Unit_Paturn1;
    public int Unit_Paturn2;
    public int Attack_Paturn;
    public float AttackTime;
    public float GrogyTime;
    public float DawnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;
        gameManager = GameManager.Instance;
        target = GameManager.Instance.target;

        Sheild_On = true;
        Spawn_Unit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Grogy == false && Attacking == false && gameManager.Skill_D_On == false)
        {
            AttackTime += Time.deltaTime;
        }

        if (Spawn_Unit == true && gameManager.Skill_D_On == false)
        {
            Sheild.SetActive(true);
            Spawn_Unit = false;
            Spawn();
        }

        if (AttackTime >= 3 && Attacking == false && Grogy == false && gameManager.Skill_D_On == false)
        {
            Attack();
            Attacking = true;
        }

        if (Grogy == false && gameManager.Skill_D_On == false)
        {
            Teling();
        }

        if (gameManager.Ruin_Unit == 4 && gameManager.Skill_D_On == false)
        {
            Grogy = true;

        }


        if (Grogy == true && GrogyTime <= 7 && gameManager.Skill_D_On == false)
        {
            Sheild.SetActive(false);
            GrogyTime += Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, new Vector2(transform.position.x, 3.7f), DawnSpeed * Time.deltaTime);

            if (GrogyTime >= 7)
            {
                gameManager.Ruin_Unit = 0;
                Grogy = false;
                Spawn_Unit = true;
                GrogyTime = 0;
            }
        }

    }

    void Attack()
    {
        Attack_Paturn = Random.Range(1, 3);

        if (Attack_Paturn == 1)
        {
            Instantiate(Fire, this.transform.position, Quaternion.identity);
        }
        else if (Attack_Paturn == 2)
        {
            Instantiate(Bomb, this.transform.position, Quaternion.identity);
        }
    }

    void Spawn()
    {
        Unit_Paturn1 = Random.Range(1, 8);
        Unit_Paturn2 = Random.Range(1, 8);

        if (Unit_Paturn1 == 1)
        {
            Instantiate(Unit, new Vector2(63.5f, 1.75f), Quaternion.identity);
            Instantiate(Unit, new Vector2(13.5f, 1.74f), Quaternion.identity);
        }
        else if (Unit_Paturn1 == 2)
        {
            Instantiate(Unit, new Vector2(58.2f, 7.045f), Quaternion.identity);
            Instantiate(Unit, new Vector2(7.8f, 7.04f), Quaternion.identity);
        }
        else if (Unit_Paturn1 == 3)
        {
            Instantiate(Unit, new Vector2(68f, 13.24f), Quaternion.identity);
            Instantiate(Unit, new Vector2(17.7f, 13.24f), Quaternion.identity);
        }
        else if (Unit_Paturn1 == 4)
        {
            Instantiate(Unit, new Vector2(60.9f, 19.24f), Quaternion.identity);
            Instantiate(Unit, new Vector2(11.4f, 19.24f), Quaternion.identity);
        }
        else if (Unit_Paturn1 == 5)
        {
            Instantiate(Unit, new Vector2(26.7f, 19.24f), Quaternion.identity);
            Instantiate(Unit, new Vector2(-23.4f, 19.24f), Quaternion.identity);
        }
        else if (Unit_Paturn1 == 6)
        {
            Instantiate(Unit, new Vector2(37f, 13.24f), Quaternion.identity);
            Instantiate(Unit, new Vector2(-13.63f, 13.24f), Quaternion.identity);
        }
        else if (Unit_Paturn1 == 7)
        {
            Instantiate(Unit, new Vector2(22.46f, 7f), Quaternion.identity);
            Instantiate(Unit, new Vector2(-27.8f, 7.04f), Quaternion.identity);
        }
        else if (Unit_Paturn1 == 8)
        {
            Instantiate(Unit, new Vector2(32f, 1.74f), Quaternion.identity);
            Instantiate(Unit, new Vector2(-18.3f, 1.74f), Quaternion.identity);
        }

        if (Unit_Paturn2 == 1 && Unit_Paturn1 != 1)
        {
            Instantiate(Unit, new Vector2(63.5f, 1.75f), Quaternion.identity);
            Instantiate(Unit, new Vector2(13.5f, 1.74f), Quaternion.identity);
        }
        else if (Unit_Paturn2 == 2 && Unit_Paturn1 != 2)
        {
            Instantiate(Unit, new Vector2(58.2f, 7.045f), Quaternion.identity);
            Instantiate(Unit, new Vector2(7.8f, 7.04f), Quaternion.identity);
        }
        else if (Unit_Paturn2 == 3 && Unit_Paturn1 != 3)
        {
            Instantiate(Unit, new Vector2(68f, 13.24f), Quaternion.identity);
            Instantiate(Unit, new Vector2(17.7f, 13.24f), Quaternion.identity);
        }
        else if (Unit_Paturn2 == 4 && Unit_Paturn1 != 4)
        {
            Instantiate(Unit, new Vector2(60.9f, 19.24f), Quaternion.identity);
            Instantiate(Unit, new Vector2(11.4f, 19.24f), Quaternion.identity);
        }
        else if (Unit_Paturn2 == 5 && Unit_Paturn1 != 5)
        {
            Instantiate(Unit, new Vector2(26.7f, 19.24f), Quaternion.identity);
            Instantiate(Unit, new Vector2(-23.4f, 19.24f), Quaternion.identity);
        }
        else if (Unit_Paturn2 == 6 && Unit_Paturn1 != 6)
        {
            Instantiate(Unit, new Vector2(37f, 13.24f), Quaternion.identity);
            Instantiate(Unit, new Vector2(-13.63f, 13.24f), Quaternion.identity);
        }
        else if (Unit_Paturn2 == 7 && Unit_Paturn1 != 7)
        {
            Instantiate(Unit, new Vector2(22.46f, 7f), Quaternion.identity);
            Instantiate(Unit, new Vector2(-27.8f, 7.04f), Quaternion.identity);
        }
        else if (Unit_Paturn2 == 8 && Unit_Paturn1 != 8)
        {
            Instantiate(Unit, new Vector2(32f, 1.74f), Quaternion.identity);
            Instantiate(Unit, new Vector2(-18.3f, 1.74f), Quaternion.identity);
        }

    }

    void Teling()
    {
        if (gameManager.TimeLine_On == true)
        {
            transform.position = new Vector2(45.5f, 13.2f);
        }
        else if (gameManager.TimeLine_On == false)
        {
            transform.position = new Vector2(-4.5f, 13.2f);
        }
    }
}
