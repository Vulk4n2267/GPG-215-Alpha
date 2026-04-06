using UnityEngine;

namespace _Main.Scripts
{
    public class NoteFactory
    {
        public static GameObject CreateNote(NoteType type, Vector3 position, Quaternion rotation)
        {
            GameObject note = NotePool.Instance.GetNote();

            NoteSlide slide = note.GetComponent<NoteSlide>();
            SpriteRenderer renderer = note.GetComponent<SpriteRenderer>();

            
            switch (type)
            {
                case NoteType.Quarter:
                    if (renderer != null) renderer.color = Color.white;
                    break;

                case NoteType.Eighth:
                    if (renderer != null) renderer.color = Color.yellow;
                    break;

                case NoteType.Half:
                    if (renderer != null) renderer.color = Color.blue;
                    break;

                case NoteType.Whole:
                    if (renderer != null) renderer.color = Color.green;
                    break;
            }

            note.transform.position = position;
            note.transform.rotation = rotation;

            
            Vector3 hitPosition = SpawnManager.Instance.transform.position;
            
            float speed = SpawnManager.Instance.GetNoteSpeed(position, hitPosition);

            slide.speed = -speed;

            return note;
        }
        public static NoteType GetRandomNoteType()
        {
            int randomIndex = Random.Range(0, 4); 
            return (NoteType)randomIndex;
        }
    }
}