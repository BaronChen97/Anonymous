using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioControl : MonoBehaviour {

    public Sounds[] sounds;
    public static float volume;
    public static float tempVolume;

    private void Start()
    {
        if (!gameStart.gameFirstTimeOpen)
        {
            volume = 1;
            gameStart.gameFirstTimeOpen = true;
        }
    }
    private void Update()
    {
        AudioListener.volume = volume;
    }

    void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }
}
