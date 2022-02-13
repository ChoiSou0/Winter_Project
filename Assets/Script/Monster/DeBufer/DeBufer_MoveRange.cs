using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBufer_MoveRange : MonoBehaviour
{
    public GameObject DeBufer;
    public bool isMove;

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
            isMove = true;
        }
    }
}
