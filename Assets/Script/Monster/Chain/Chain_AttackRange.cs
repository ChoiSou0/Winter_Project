using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_AttackRange : MonoBehaviour
{
    public Transform Chain;
    public bool Attacked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Chain.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attacked = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attacked = false;
        }
    }
}
