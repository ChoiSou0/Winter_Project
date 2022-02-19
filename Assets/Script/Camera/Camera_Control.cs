using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    private GameManager gameManager;
    private Camera_MoveRange moveRange;
    private Player_Control player;
    public GameObject Taget;
    Transform A;

    // Start is called before the first frame update
    void Start()
    {
        moveRange = GameObject.Find("Camera_Move_Range").GetComponent<Camera_MoveRange>();
        player = GameObject.Find("Player").GetComponent<Player_Control>();
        gameManager = GameManager.Instance;
        A = Taget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRange.CameraMove == true && gameManager.GameOver == false)
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

        if (gameManager.GameOver == true)
        {
            Vector2 Vec = (new Vector3(player.transform.position.x, player.transform.position.y + 1) - this.transform.position).normalized;
            transform.Translate(Vec * (player.Player_Speed + 5) * Time.deltaTime);
            if (this.transform.position.z <= -3)
                transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + (player.Player_Speed + 5) * Time.deltaTime);
        }

    }
}
