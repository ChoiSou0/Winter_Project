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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Skill_D_On == true && TheWorldTime <= 9)
        {
            TheWorldTime += Time.deltaTime;

            if (TheWorldTime >= 9)
            {
                TheWorldTime = 0;
                Skill_D_On = false;
            }
        }

    }

}
