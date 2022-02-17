using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bangtan_Dash_Range : MonoBehaviour
{
    public bool Dashed = false;
    public GameObject bangtan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(bangtan.transform.position.x, bangtan.transform.position.y + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("d");
            Dashed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Dashed = false;
        }
    }
}
