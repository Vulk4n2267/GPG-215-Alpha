using System;
using UnityEngine;

public class AudioManager : ScriptLibrary.Singletons.Singleton<AudioManager>
{
    public Action OnBeat;
    public Action OnSpawn;
    public GameObject prefab;
    public float bpm = 124f;
    public float startDelay = 2.0f;
    
    
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

    void Update()
    {
        if (!_songStarted) return;

        if (AudioSettings.dspTime >= _nextBeatTime + 1f)
        {
            OnSpawn?.Invoke();
        }
        else if (AudioSettings.dspTime >= _nextBeatTime)
        {
            OnBeat?.Invoke();
            _nextBeatTime += _secondsPerBeat;
        }
    }
}

