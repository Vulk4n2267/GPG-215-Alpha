using UnityEngine;


    public class NoteSlide : MonoBehaviour
    {
        public float speed = 5f;

        private Vector3 moveDirection;

        private void Awake()
        {
            moveDirection = transform.forward;
        }

        private void OnEnable()
        {
            // Reset movement direction every time it's reused
            moveDirection = transform.forward;
        }

        void Update()
        {
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
