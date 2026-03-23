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
                    slide.speed = -5f;
                    if (renderer != null) renderer.color = Color.white;
                    break;

                case NoteType.Eighth:
                    slide.speed = -7f;
                    if (renderer != null) renderer.color = Color.yellow;
                    break;

                case NoteType.Half:
                    slide.speed = -3f;
                    if (renderer != null) renderer.color = Color.blue;
                    break;

                case NoteType.Whole:
                    slide.speed = -2f;
                    if (renderer != null) renderer.color = Color.green;
                    break;
            }

         
            note.transform.position = position;
            note.transform.rotation = rotation;

            return note;
        }

        public static NoteType GetRandomNoteType()
        {
            int randomIndex = Random.Range(0, 4); 
            return (NoteType)randomIndex;
        }
    }
}