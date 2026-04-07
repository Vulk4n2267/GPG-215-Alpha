using System;
using System.Collections.Generic;
using UnityEngine;



public class SpawnManager : ScriptLibrary.Singletons.Singleton<SpawnManager>
{
    public event Action OnSpawn;
    public float bpm = 124f;
    public float startDelay = 2.0f;
    public float travelTime = 2.438f;
    public Transform hitPoint;


    private AudioSource _musicSource;
    private double _songStartTime;
    private double _nextBeatTime;
    private float _secondsPerBeat;
    private bool _songStarted = false;
    
    // queue containing all the beat flags, if its true, its played, if its false its not
    private Queue<bool> _beatQueue = new Queue<bool>();

    void Start()
    {
        _musicSource = GetComponent<AudioSource>();
        _secondsPerBeat = 60f/bpm;

        LoadBeatsFromJSON("beatpattern");

        _songStartTime = AudioSettings.dspTime + startDelay;
        _nextBeatTime = _songStartTime;

        _musicSource.PlayScheduled(_songStartTime); 
        _songStarted = true;
    }

    private void LoadBeatsFromJSON(string fileName)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(fileName);
        
        if (jsonFile == null)
        {
            Debug.LogError($"Couldn't load {fileName}");
            return;
        }

        try
        {
            //convert json to array in beatpattern class
            BeatPattern pattern = JsonUtility.FromJson<BeatPattern>(jsonFile.text);
            
            //checking if beats is null or if its empty
            if (pattern?.beats == null || pattern.beats.Length == 0)
            {
                Debug.LogError("Beat pattern is empty!");
                return;
            }

            //add the beats(array of bool) to local queue of bool
            for (int i = 0; i < pattern.beats.Length; i++)
            {
                _beatQueue.Enqueue(pattern.beats[i]);
            }

            Debug.Log($"loaded {_beatQueue.Count} beats from {fileName}");
        }
        catch (Exception e)
        {
            Debug.LogError($"parsing error: {e.Message}");
        }
    }

    void Update()
    {
        if (!_songStarted) return;

        if (AudioSettings.dspTime >= _nextBeatTime - travelTime)
        {
            //check if beat should be played from queee
            bool shouldPlayBeat = _beatQueue.Count <= 0 || _beatQueue.Dequeue();
            
            print(shouldPlayBeat);
            if (shouldPlayBeat)
            {
                OnSpawn?.Invoke();
            }
            
            _nextBeatTime += _secondsPerBeat;
        }

    }
    public float GetNoteSpeed(Vector3 spawnPos, Vector3 hitPos)
    {
        float distance = Vector3.Distance(spawnPos, hitPos);
        return distance / travelTime;
    }
}

[Serializable]
public class BeatPattern
{
    public bool[] beats;
}

