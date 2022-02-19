using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SOUND
{
    BGM,
    SFX,
    END,
}

public class SoundManager : MonoBehaviour
{
    public const string SOUND_PATH = "Sounds/";

    AudioSource[] audioSources = new AudioSource[(int)SOUND.END];
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    private float _bgmVolume;
    private float _sfxVolume;

    public float BGMVolume
    {
        get => _bgmVolume;
    }

    public float SFXVolume
    {
        get => _sfxVolume;
    }

    private static SoundManager _Instance;
    public static SoundManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                var go = new GameObject("SoundManager");
                var bgm = new GameObject("BGM");
                var sfx = new GameObject("SFX");

                DontDestroyOnLoad(go);

                bgm.transform.parent = go.transform;
                sfx.transform.parent = go.transform;

                _Instance = go.AddComponent<SoundManager>();
                _Instance.audioSources[(int)SOUND.BGM] = bgm.AddComponent<AudioSource>();
                _Instance.audioSources[(int)SOUND.SFX] = sfx.AddComponent<AudioSource>();
                _Instance.audioSources[(int)SOUND.SFX].volume = 0.5f;
                _Instance.audioSources[(int)SOUND.BGM].volume = 0.5f;

                _Instance.audioClips = Resources.LoadAll<AudioClip>(SOUND_PATH).ToDictionary(p => p.name);

                foreach (var sound in _Instance.audioClips)
                {
                    Debug.Log(sound.Key);
                }
            }

            return _Instance;
        }
    }
    public void Play(string soundName, SOUND sound = SOUND.SFX, float pitch = 1f)
    {
        int i = (int)sound;

        if (sound == SOUND.BGM)
        {
            audioSources[i].clip = audioClips[soundName];
            audioSources[i].loop = true;
            audioSources[i].pitch = pitch;
            audioSources[i].Play();
        }
        else
        {
            audioSources[i].pitch = pitch;
            audioSources[i].PlayOneShot(audioClips[soundName]);
        }
    }

    public void StopBGM()
    {
        audioSources[(int)SOUND.BGM].Stop();
    }

    public void SetVolume(SOUND sound, float _volume)
    {
        audioSources[(int)sound].volume = _volume;
    }
}