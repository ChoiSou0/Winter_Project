using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPCount : MonoBehaviour
{
    public GameObject isSP;

    public int SP;

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        SP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "SP:" + SP.ToString();
    }
}
