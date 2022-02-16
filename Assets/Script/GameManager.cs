using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool FireBall1_On;
    public bool FireBall2_On;
    public bool FireBall3_On;
    

    public bool Skill_D_On;
    public float TheWorldTime;

    public GameObject SkillD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Skill_D_On == true && TheWorldTime <= 9)
        {
            SkillD.SetActive(true);
            TheWorldTime += Time.deltaTime;

            if (TheWorldTime >= 9)
            {
                SkillD.SetActive(false);
                TheWorldTime = 0;
                Skill_D_On = false;
            }
        }

    }

}
