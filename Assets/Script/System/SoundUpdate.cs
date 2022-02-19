using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUpdate : MonoBehaviour
{
    public Slider BGM;
    public Slider SFX;

    private void Start()
    {
        BGM.value = 0.5f;
        SFX.value = 0.5f;

    }

    void Update()
    {
        SoundManager.Instance.SetVolume(SOUND.BGM, BGM.value);
        SoundManager.Instance.SetVolume(SOUND.SFX, SFX.value);
    }
}
