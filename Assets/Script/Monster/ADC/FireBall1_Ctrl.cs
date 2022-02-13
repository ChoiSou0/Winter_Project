using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall1_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    public Transform target;
    public Vector2 FollowPos;

    public float LifeTime;
    public float Speed;

    public int xVec;
    public int yVec;

    int cnt;

    public bool Follow;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.FireBall1_On == true && cnt == 0)
        {
            cnt = 1;
            FollowPos = target.transform.position;

            if (target.transform.position.x > this.gameObject.transform.position.x)
            {
                xVec = -7;
            }
            else if (target.transform.position.x < this.gameObject.transform.position.x)
            {
                xVec = 7;
            }

            if (target.transform.position.y > this.gameObject.transform.position.y)
            {
                yVec = 7;
            }
            else if (target.transform.position.y < this.gameObject.transform.position.y)
            {
                yVec = -7;
            }

            gameManager.FireBall1_On = false;
            Follow = true;
        }

        if (Follow == true && LifeTime <= 5)
        {
            LifeTime += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(FollowPos.x * xVec, FollowPos.y * yVec + 1f), Speed * Time.deltaTime);

            if (LifeTime >= 5)
            {
                Destroy(gameObject);
                Follow = false;
                LifeTime = 0;
            }
        }
    }
}
