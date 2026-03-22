using Unity.VisualScripting;
using UnityEngine;

namespace _Main.Scripts
{
    public class BeatSpawn : MonoBehaviour
    {
        public Transform[] spawnPoints;

        void Start()
        {
            SpawnManager.Instance.OnSpawn += SpawnRandomNote;
        }

        void SpawnRandomNote()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform randomSpawnPoint = spawnPoints[randomIndex];

            GameObject note = NotePool.Instance.GetNote();

            note.transform.position = randomSpawnPoint.position;
            note.transform.rotation = randomSpawnPoint.rotation;
        }
    }
}

