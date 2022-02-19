using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManaGer : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject Boss;

    public int a;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Wavecount wavecount = GameObject.Find("Wave_Count").GetComponent<Wavecount>();

        if(wavecount.Wave == 8 && a==0)
        {
            GameObject go = Instantiate(Boss, gameObject.transform);
            a++;
        }
    }
}
