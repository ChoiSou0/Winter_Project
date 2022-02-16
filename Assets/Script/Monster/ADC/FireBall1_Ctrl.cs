using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall1_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject player;
    public GameObject ADC;
    
    public float FollowPos;

    public Vector2 v, w;
    public float m_Angle;
    public float Vec;
    //public Vector2 FollowPos, player;

    public float LifeTime;
    public float Speed;
    public bool Follow;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_Angle);

        if (gameManager.FireBall1_On == true)
        {
            m_Angle = Vector2.Angle(ADC.transform.position, player.transform.position);
            
            Follow = true;
        }

        if (Follow == true && LifeTime <= 5)
        {
            LifeTime += Time.deltaTime;
            
            

            if (LifeTime >= 5)
                Destroy(gameObject);
        }

    }
}
