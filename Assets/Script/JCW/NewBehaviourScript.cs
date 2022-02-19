using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Play("Main", SOUND.BGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
