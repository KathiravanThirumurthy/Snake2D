using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] _sounds;
    public static AudioManager _instance;
    private void Awake()
    {

        singleInstance();

        foreach (Sounds _sound in _sounds)
        {
            _sound._source = gameObject.AddComponent<AudioSource>();
            _sound._source.clip = _sound.audioClip;
            _sound._source.volume = _sound.volume;
            _sound._source.pitch = _sound.pitch;
            _sound._source.loop = _sound.loop;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void singleInstance()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Debug.Log(name);
        Sounds snd = Array.Find(_sounds, sound => sound.nameofAudio == name);
        if (snd == null)
        {
            Debug.LogWarning("Sound:" + name + "not found !");
            return;
        }
        snd._source.Play();

    }
}