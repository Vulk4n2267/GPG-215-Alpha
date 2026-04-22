using UnityEngine;
using System.Collections;

[RequireComponent(typeof(InputHandler))]
public class HitNotes : MonoBehaviour
{
    private InputHandler _playerInput;
    private Camera _camera;

    void Start()
    {
        _playerInput = GetComponent<InputHandler>();
        _camera = Camera.main;
    }

    void Update()
    {
        if (_playerInput.ClickActionValue > 0f)
        {
            Debug.Log("Clicked at " + Time.deltaTime);

            Ray ray = _camera.ScreenPointToRay(_playerInput.PointerLocationValue);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Hit " + hit.collider.gameObject.name);

                if (hit.collider.CompareTag("Note"))
                {
                    GameObject note = hit.collider.gameObject;

                    // Hit window check
                    if (hit.transform.position.z < transform.position.z + 0.5f &&
                        hit.transform.position.z > transform.position.z - 0.5f)
                    {
                        GameManager.Instance.AddScore(100);
                        SpawnParticle(note.transform.position);


                    }
                    else
                    {
                        GameManager.Instance.AddScore(-10);
                    }

                    
                    NotePool.Instance.ReturnNote(note);
                    
                }
            }
        }
    }

    void SpawnParticle(Vector3 position)
    {
        GameObject particle = ParticlePool.Instance.GetParticle();

        particle.transform.position = position;

        ParticleSystem ps = particle.GetComponent<ParticleSystem>();
        ps.Play();

        StartCoroutine(ReturnParticleAfterTime(particle, ps.main.duration + ps.main.startLifetime.constantMax));
    }
    
    IEnumerator ReturnParticleAfterTime(GameObject particle, float time)
    {
        yield return new WaitForSeconds(time);
        ParticlePool.Instance.ReturnParticle(particle);
    }
}
