using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall3_Ctrl : MonoBehaviour
{
    private Animator animator;
    private GameManager gameManager;
    public GameObject player;
    public GameObject ADC;

    public float FollowPos;

    public bool Hiting;
    public float HitTime;

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
        animator = GetComponent<Animator>();
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

        if (Follow == true && LifeTime <= 8 && Hiting == false)
        {
            LifeTime += Time.deltaTime;
            transform.Translate(Vec * Speed * Time.deltaTime);



            if (LifeTime >= 8)
            {
                gameManager.FireBall2_On = false;
                Destroy(gameObject);
            }

        }

        if (Hiting == true && HitTime <= 0.5f)
        {
            HitTime += Time.deltaTime;
            if (HitTime >= 0.5f)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("¾î");
            animator.SetBool("isHit", true);
            Hiting = true;
        }
    }
}
