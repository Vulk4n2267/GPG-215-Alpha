using Unity.VisualScripting;
using UnityEngine;

namespace _Main.Scripts
{
    public class BeatSpawn : MonoBehaviour
    {
        public Transform[] spawnPoints;
        public GameObject notePrefab;
        void Start()
        {

            SpawnManager.Instance.OnSpawn +=
            SpawnRandomNote;
            
        }

          void SpawnRandomNote()
        {
            
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform randomSpawnPoint = spawnPoints[randomIndex];

            Instantiate(notePrefab, randomSpawnPoint.position, Quaternion.identity);
            Debug.Log("Spawned a Note");
        }
        
    }

}