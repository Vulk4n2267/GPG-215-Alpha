using UnityEngine;

public class MusicSample : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clip;
    public float startTime;

    public void Play()
    {
        audioSource.clip = clip;
        audioSource.time = startTime;
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}