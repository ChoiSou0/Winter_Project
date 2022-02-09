using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Wolf_Control wolf;
    private Player_Control player;

    // Start is called before the first frame update
    void Start()
    {
        wolf = GameObject.Find("Wolf").GetComponent<Wolf_Control>();
        player = GameObject.Find("Player").GetComponent<Player_Control>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Wolf")
        {
            Debug.Log("¸ÂÀ½");
            wolf.Hp -= player.Player_Power;
        }
    }
}
