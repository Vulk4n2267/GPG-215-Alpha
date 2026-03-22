using System;
using UnityEngine;

public class SpawnManager : ScriptLibrary.Singletons.Singleton<SpawnManager>
{
    public Action OnSpawn;
    public float bpm = 124f;
    public float startDelay = 2.0f;
    public float travelTime = 2.438f;
    
    
    private AudioSource _musicSource;
    private double _songStartTime;
    private double _nextBeatTime;
    private float _secondsPerBeat;
    private bool _songStarted = false;

    void Start()
    {
        _musicSource = GetComponent<AudioSource>();
        _secondsPerBeat = 60f/bpm;

        _songStartTime = AudioSettings.dspTime + startDelay;
        _nextBeatTime = _songStartTime;

        _musicSource.PlayScheduled(_songStartTime); 
        _songStarted = true;
    }

    private int _beatIndex = 0;
    void Update()
    {
        if (!_songStarted) return;

        if (AudioSettings.dspTime >= _nextBeatTime - travelTime)
        {
            if (_beatIndex % 4 == 0)
                OnSpawn?.Invoke(); 
            _beatIndex++;
            _nextBeatTime += _secondsPerBeat;
        }
    }
}

