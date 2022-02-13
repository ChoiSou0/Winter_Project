using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBufer_Magic : MonoBehaviour
{
    private Player_Control player;
    private DeBufer_Ctrl deBuferCtrl;
    public float LifeTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player_Control>();
        deBuferCtrl = GameObject.Find("DeBufer").GetComponent<DeBufer_Ctrl>();
    }

    // Update is called once per frame
    void Update()
    {
        deBuferCtrl.Magicing = false;

        LifeTime += Time.deltaTime;

        if (LifeTime >= 5)
        {
            Destroy(gameObject);
        }

    }

}
