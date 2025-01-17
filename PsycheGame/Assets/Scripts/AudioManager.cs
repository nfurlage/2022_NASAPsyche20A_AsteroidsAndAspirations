﻿using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public bool loadingMainMenu, loadingShipScene, loadingCardGame, loadingSaveStuff, loadingWireGame = false;
    // Start is called before the first frame update
    void Awake()
    {
        foreach( Sound s in sounds )
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }
    }

    void Start()
    {
        if ( loadingMainMenu ) Play("SpaceChillout");
        if ( loadingShipScene ) Play("ChillAmbient");
        if ( loadingCardGame ) Play("SpaceChillout");
        if ( loadingSaveStuff ) Play("CosmicGlow");
        if ( loadingWireGame ) Play("Dunes");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name );
        if ( s == null || s.source.isPlaying )
            return;
        s.source.Play();
    }

    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name );
        if ( s == null || !s.source.isPlaying )
            return;
        s.source.Stop();
    }
}
