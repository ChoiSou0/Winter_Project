using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    private TimeLine timeLine;

    public GameObject Sheild;
    private GameObject Unit;
    private GameObject Fire;
    private GameObject Bomb;

    public bool Grogy;
    public bool Spawn_Unit;
    public bool Sheild_On;
    public bool Attacking;

    public int Unit_Paturn1;
    public int Unit_Paturn2;
    public float AttackTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        timeLine = GameManager.Instance.timeLine;

        Sheild_On = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Grogy == false)
        {
            AttackTime += Time.deltaTime;
        }

        if (Spawn_Unit == false && Grogy == true)
        {
            Spawn();
            Spawn_Unit = true;
        }

        if (AttackTime >= 2 && Attacking && Grogy == false)
        {
            Attack();
        }

        if (Grogy == false)
        {
            Teling();
        }

    }

    void Attack()
    {

    }

    void Spawn()
    {
        Unit_Paturn1 = Random.Range(1, 8);
        Unit_Paturn2 = Random.Range(1, 8);

        if (Unit_Paturn1 == 1)
        {

        }
        else if (Unit_Paturn1 == 2)
        {

        }
        else if (Unit_Paturn1 == 3)
        {

        }
        else if (Unit_Paturn1 == 4)
        {

        }
        else if (Unit_Paturn1 == 5)
        {

        }
        else if (Unit_Paturn1 == 6)
        {

        }
        else if (Unit_Paturn1 == 7)
        {

        }
        else if (Unit_Paturn1 == 8)
        {

        }

        if (Unit_Paturn2 == 1)
        {

        }
        else if (Unit_Paturn2 == 2)
        {

        }
        else if (Unit_Paturn2 == 3)
        {

        }
        else if (Unit_Paturn2 == 4)
        {

        }
        else if (Unit_Paturn2 == 5)
        {

        }
        else if (Unit_Paturn2 == 6)
        {

        }
        else if (Unit_Paturn2 == 7)
        {

        }
        else if (Unit_Paturn2 == 8)
        {

        }

    }

    void Teling()
    {
        if (timeLine.TimeLine_On == true)
        {
            transform.position = new Vector2(45.5f, 13.2f);
        }
        else if (timeLine.TimeLine_On == false)
        {
            transform.position = new Vector2(-4.5f, 13.2f);
        }
    }
}
