using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public float CurTime;

    Image image;

    public bool isTitle;

    public float OutSpeed;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            isTitle = true;
        }

        if(isTitle)
        {
            CurTime += Time.deltaTime;
            image.color += new Color(0, 0, 0, OutSpeed * Time.deltaTime);
            if (CurTime >= 2)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
}
