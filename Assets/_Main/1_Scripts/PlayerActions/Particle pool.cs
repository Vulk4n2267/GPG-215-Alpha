using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool Instance;

    public GameObject particlePrefab;
    public int initialPoolSize = 5;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(particlePrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetParticle()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(particlePrefab);
            return obj;
        }
    }

    public void ReturnParticle(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}