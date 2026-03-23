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
            // Get random spawn point
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform randomSpawnPoint = spawnPoints[randomIndex];

            // Get random note type
            NoteType randomType = NoteFactory.GetRandomNoteType();

            // Create note using factory
            GameObject note = NoteFactory.CreateNote(
                randomType,
                randomSpawnPoint.position,
                randomSpawnPoint.rotation
            );
        }
    }
}

