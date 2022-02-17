using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall3_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject player;
    public GameObject ADC;

    public float FollowPos;

    public Vector3 v, w;
    public float m_Angle;
    //public float Dot;
    public Vector2 Vec;
    //public Vector2 FollowPos, player;

    public float LifeTime;
    public float Speed;
    public bool Follow;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_Angle);

        if (gameManager.FireBall3_On == false)
        {
            Vec = (player.transform.position - this.transform.position).normalized;
        }

        if (gameManager.FireBall3_On == true)
        {
            Follow = true;
        }

        if (Follow == true && LifeTime <= 8)
        {
            LifeTime += Time.deltaTime;
            transform.Translate(Vec * Speed * Time.deltaTime);



            if (LifeTime >= 8)
            {
                gameManager.FireBall2_On = false;
                Destroy(gameObject);
            }

        }

    }
}
