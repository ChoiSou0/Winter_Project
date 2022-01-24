using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1_Control : MonoBehaviour
{
    public Transform target;
    public Vector2 direcotion;
    public float velocity;
    public float accelaration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        target = GameObject.Find("Player").transform;

        direcotion = (target.position - transform.position).normalized;

        accelaration = 0.1f;

        velocity = (velocity + accelaration * Time.deltaTime);

        float distance = Vector2.Distance(target.position, target.position);

        this.transform.position = new Vector2(transform.position.x + (direcotion.x * velocity / 3), 1);
    }
}
