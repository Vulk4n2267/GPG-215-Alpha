using TMPro;
using UnityEngine;

public class ScoreAndStreakTextUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI streakText;
    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
        int streak = PlayerPrefs.GetInt("Streak", 0);
        streakText.text = streak > 0 ? $"x{streak}" : "";
    }
}
