using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bangtan_MoveRange : MonoBehaviour
{
    public GameObject bangtan;
    public bool isMove = false;
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
            isMove = true;
        }
    }
}
