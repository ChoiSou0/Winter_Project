using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Sheild : MonoBehaviour
{
    private Boss_Ctrl boss_Ctrl;

    // Start is called before the first frame update
    void Start()
    {
        boss_Ctrl = GameManager.Instance.boss_Ctrl;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(boss_Ctrl.transform.position.x, boss_Ctrl.transform.position.y);
    }
}
