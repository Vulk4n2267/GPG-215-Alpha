using UnityEngine;

public class NoteSlide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public float speed = 5f;

    void Update()
    {
        // Move the object along its local forward axis at a consistent speed
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
