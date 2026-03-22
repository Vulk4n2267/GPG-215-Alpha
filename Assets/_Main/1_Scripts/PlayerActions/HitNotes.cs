using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class HitNotes : MonoBehaviour
{
    private InputHandler _playerInput;
    private Camera _camera;

    void Start()
    {
        _playerInput = GetComponent<InputHandler>();
        _camera = Camera.main;
        
        //print("initialize playerInput, Camera, Note Tag on Note Prefab, GameManager with AddScore method");
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
                    if (hit.transform.position.z < transform.position.z + 0.5f && hit.transform.position.z > transform.position.z - 0.5f)
                    {
                        GameManager.Instance.AddScore(100);
                    }
                    else
                    {
                        GameManager.Instance.AddScore(-10);
                        Destroy(hit.transform.gameObject);
                    }
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
