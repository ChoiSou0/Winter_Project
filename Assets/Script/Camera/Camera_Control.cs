using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
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
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Taget.transform.position.x, Taget.transform.position.y + 2, Taget.transform.position.z - 10), player.Player_Speed * Time.deltaTime);
        }

        if (this.transform.position == Taget.transform.position)
        {
            moveRange.CameraMove = false;
        }

    }
}
