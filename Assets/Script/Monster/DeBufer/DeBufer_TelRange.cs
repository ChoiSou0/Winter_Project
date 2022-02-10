using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBufer_TelRange : MonoBehaviour
{
    public bool Teling;
    public GameObject DeBufer;
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
            Teling = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Teling = true;
        }
    }
}
