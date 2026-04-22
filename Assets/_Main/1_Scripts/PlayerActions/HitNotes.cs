using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

[RequireComponent(typeof(InputHandler))]
public class HitNotes : MonoBehaviour
{
    private InputHandler _playerInput;
    private Camera _camera;

    [SerializeField] private Animator popAnimator;
    [SerializeField] private TextMeshProUGUI scoreGradeText;
    
    [SerializeField] private Color perfectColor;
    [SerializeField] private Color goodColor;
    [SerializeField] private Color missColor;

    void Start()
    {
        _playerInput = GetComponent<InputHandler>();
        _camera = Camera.main;
    }

    void Update()
    {
        if (_playerInput.ClickActionValue > 0f)
        {
            Ray ray = _camera.ScreenPointToRay(_playerInput.PointerLocationValue);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (!hit.collider.CompareTag("Note")) return;

                GameObject note = hit.collider.gameObject;

                // Hit window check
                float accuracy = Mathf.Abs(transform.position.z - hit.transform.position.z);
                
                if (hit.transform.position.z < transform.position.z + 0.5f &&
                    hit.transform.position.z > transform.position.z - 0.5f)
                {
                    PerfectScore(accuracy);
                }
                else if (hit.transform.position.z < transform.position.z + 1f &&
                         hit.transform.position.z > transform.position.z - 1f)
                {
                    GoodScore(accuracy);
                }
                else
                {
                    MissScore();
                }
                SpawnParticle(note.transform.position);
                popAnimator.Play("ScoreGradePopUp", 0, 0f);

                NotePool.Instance.ReturnNote(note);

            }
        }
    }
    private void GoodScore(float accuracy)
    {
        GameManager.Instance.AddScore(100 - (int)(accuracy * 100));
        scoreGradeText.text = "Good";
        scoreGradeText.color = goodColor;
    }

    private void MissScore()
    {
        GameManager.Instance.AddScore(-10);
        scoreGradeText.text = "Miss";
        scoreGradeText.color = missColor;
    }
    
    private void PerfectScore(float accuracy)
    {
        GameManager.Instance.AddScore(200 - (int)(accuracy * 200));
        scoreGradeText.text = "Perfect";
        scoreGradeText.color = perfectColor;
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
