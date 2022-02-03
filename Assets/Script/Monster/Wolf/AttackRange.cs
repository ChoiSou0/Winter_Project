using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public bool Wolf_Attack = false;
    private bool Deal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("¤·¤·");
        if (collision.gameObject.tag == "Player")
        {
            Wolf_Attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Wolf_Attack = false;
        }
    }

}
