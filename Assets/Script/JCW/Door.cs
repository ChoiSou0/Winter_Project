using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int Move;

    private Image image;

    public float CurTime;

    public float OutSpeed;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        SoundManager.Instance.Play("Main", SOUND.BGM);
    }

    // Update is called once per frame
    void Update()
    {
        if(Move == 1)
        {
            CurTime += Time.deltaTime;
            image.color += new Color(0, 0, 0, OutSpeed * Time.deltaTime);
            if(CurTime>= 2)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            Door door = GameObject.Find("PadeOut").GetComponent<Door>();
            door.Move = 1; 
        }
    }
}
