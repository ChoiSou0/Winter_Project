using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mir : MonoBehaviour
{
    public GameObject Player;
    Transform A;

    // Start is called before the first frame update
    void Start()
    {
        A = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(A.position.x, -A.position.y, A.position.z);
    }

}
