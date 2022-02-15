using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall2_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    public Transform target;
    public Vector3 player;
    public Vector3 d;
    public float FollowPos;

    public Vector2 v, w;
    public float num1;
    public float num2;
    public float num3;
    public float num4;
    //public Vector2 FollowPos, player;

    public float LifeTime;
    public float Speed;

    public int xVec;
    public int yVec;

    int cnt;

    public bool Follow;

    private float distanceLength;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.FireBall2_On == true)
        {
            gameManager.FireBall2_On = false;
            //Vector2 v = target.transform.position;
            //Vector2 w = this.transform.position;
            //num1 = v.x - w.x;
            //num2 = v.y - w.y;
            //num3 = num1 * num1 + num2 * num2;
            //num4 = (float)Mathf.Sqrt(num3);

            v = transform.position;
            if (target.transform.position.x > transform.position.x && target.transform.position.y > transform.position.y)
            {
                w = new Vector2(target.transform.position.x + transform.position.x, target.transform.position.y + transform.position.y);
                w = w + w + w;
            }
            else if (target.transform.position.x < transform.position.x && target.transform.position.y > transform.position.y)
            {
                w = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y + transform.position.y);
                w = w + w + w;
            }
            else if (target.transform.position.x > transform.position.x && target.transform.position.y < transform.position.y)
            {
                w = new Vector2(target.transform.position.x + transform.position.x, target.transform.position.y - transform.position.y);
                w = w + w + w;
            }
            else if (target.transform.position.x < transform.position.x && target.transform.position.y < transform.position.y)
            {
                w = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
                w = w + w + w;
            }

            startTime = Time.time;
            distanceLength = Vector2.Distance(v, w);
            Follow = true;
        }

        if (Follow == true && LifeTime <= 5)
        {
            LifeTime += Time.deltaTime;
            float distCovered = (Time.time - startTime) * Speed;
            float franJourney = distCovered / distanceLength;
            transform.position = Vector2.Lerp(v, w, franJourney);


            if (LifeTime >= 5)
                Destroy(gameObject);
        }

    }
}
