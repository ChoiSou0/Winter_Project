using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public GameObject Taget;
    Transform A;

    // Start is called before the first frame update
    void Start()
    {
        A = Taget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(A.position.x, A.position.y, -10);
    }
}
