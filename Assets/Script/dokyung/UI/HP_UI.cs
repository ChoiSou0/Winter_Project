using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_UI : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    // Start is called before the first frame update

    public float maxHp = 100;
    public float curHp = 100;

    void Start()
    {
        hpbar.value = (float)curHp / (float)maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value,(float)curHp / (float)maxHp, Time.deltaTime*10);
    }
}
