using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    private Camera_MoveRange moveRange;
    private Player_Control player;
    public GameObject Taget;
    Transform A;

    // Start is called before the first frame update
    void Start()
    {
        moveRange = GameObject.Find("Camera_Move_Range").GetComponent<Camera_MoveRange>();
        player = GameObject.Find("Player").GetComponent<Player_Control>();
        A = Taget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRange.CameraMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Taget.transform.position.x, 0, Taget.transform.position.z - 10), (player.Player_Speed + 7) * Time.deltaTime);

            if (this.transform.position.x >= 50.8f)
                transform.position = new Vector3(50.8f, 0, -10);
            if (this.transform.position.x <= 0f)
                transform.position = new Vector3(-0f, 0, -10);

        }

        if (this.transform.position == Taget.transform.position)
        {
            moveRange.CameraMove = false;
        }

    }
}
