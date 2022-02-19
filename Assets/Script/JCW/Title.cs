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

    public int a;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        image = GetComponent<Image>();
        SoundManager.Instance.Play("Title", SOUND.BGM);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (a == 0)
            {
                SoundManager.Instance.Play("Game_Start");
                a++;
            }
            isTitle = true;
        }

        if(isTitle)
        {
            CurTime += Time.deltaTime;
            image.color += new Color(0, 0, 0, OutSpeed * Time.deltaTime);
            if (CurTime >= 3)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
}
