using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBufer_Magic : MonoBehaviour
{
    private Player_Control player;
    public bool Magiced;
    public float LifeTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player_Control>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeTime = Time.deltaTime;

        if (LifeTime >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Magiced = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Magiced = false;
    }
}
