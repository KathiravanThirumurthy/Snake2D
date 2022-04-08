using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{

    public string nameofAudio;
    public AudioClip audioClip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool loop;
    [HideInInspector]
    public AudioSource _source;
}