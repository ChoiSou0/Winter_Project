using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bangtan_AttackRange : MonoBehaviour
{
    public GameObject bangtan;
    public bool Attacked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(bangtan.transform.position.x, bangtan.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("d");
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
