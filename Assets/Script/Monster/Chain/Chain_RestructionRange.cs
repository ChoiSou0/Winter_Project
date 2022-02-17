using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_RestructionRange : MonoBehaviour
{
    public GameObject Chain;
    public bool Restructioning;
    public bool Once;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Chain.transform.position.x, Chain.transform.position.y + 0.7f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Restructioning == false && Once == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                Restructioning = true;
                Once = true;
            }
        }

    }
}
