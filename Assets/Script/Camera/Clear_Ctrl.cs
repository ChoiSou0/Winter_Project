using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear_Ctrl : MonoBehaviour
{
    Image image;
    SpriteRenderer spriteRenderer;
    GameManager gameManager;
    Camera_Control camera;

    public float  RGB;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        gameManager = GameManager.Instance;
        
        camera = GameManager.Instance.camera;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GameClear == true)
        {
            RGB += Time.deltaTime;
            image.color = new Color(1, 1, 1, RGB);
        }

    }
}
