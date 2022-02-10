using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBufer_AttackRange : MonoBehaviour
{
    public GameObject DeBufer;
    public bool StartAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = DeBufer.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartAttack = false;
        }
    }
}
