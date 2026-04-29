using UnityEngine;
using System.Collections;

public class MenuPulse : MonoBehaviour

{
    public float pulseScale = 1.2f;
    public float pulseSpeed = 8f;

    private Vector3 originalScale;
    private Vector3 targetScale;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;

        SpawnManager.Instance.OnSpawn += Pulse;
    }

    void OnDestroy()
    {
        if (SpawnManager.Instance != null)
            SpawnManager.Instance.OnSpawn -= Pulse;
    }

    void Update()
    {
       
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * pulseSpeed);

     
        targetScale = originalScale;
    }

    void Pulse()
    {
        
        transform.localScale = originalScale * pulseScale;
    }
}