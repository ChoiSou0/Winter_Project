using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    private Camera_MoveRange moveRange;
    public GameObject Taget;
    Transform A;

    // Start is called before the first frame update
    void Start()
    {
        moveRange = GameObject.Find("Camera_Move_Range").GetComponent<Camera_MoveRange>();
        A = Taget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
