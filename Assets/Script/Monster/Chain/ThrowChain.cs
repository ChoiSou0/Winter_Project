using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowChain : MonoBehaviour
{
    public Transform target;
    public float Speed;
    public float LifeTime;
    public int Vec;
    // Start is called before the first frame update
    void Start()
    {
        if (target.transform.position.x > this.transform.position.x)
        {
            Vec = 1;
        }
        else
        {
            Vec = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTime <= 4)
        {
            LifeTime += Time.deltaTime;
            transform.position = new Vector2(transform.position.x + Speed * Vec, transform.position.y);

            if (LifeTime >= 4)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
