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
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Taget.transform.position.x, Taget.transform.position.y + 2, Taget.transform.position.z - 10), (player.Player_Speed + 5)* Time.deltaTime);

            if (this.transform.position.x > 60.02f)
                transform.position = new Vector3(60.02f, transform.position.y , -10);
            if (this.transform.position.x < -19.2)
                transform.position = new Vector3(-19.2f, transform.position.y, -10);
            if (this.transform.position.y < 5.5f)
                transform.position = new Vector3(transform.position.x, 5.5f, -10);
            if (this.transform.position.y > 19.92f)
                transform.position = new Vector3(transform.position.x, 19.92f, -10);

        }

        if (this.transform.position == Taget.transform.position)
        {
            moveRange.CameraMove = false;
        }

    }
}
