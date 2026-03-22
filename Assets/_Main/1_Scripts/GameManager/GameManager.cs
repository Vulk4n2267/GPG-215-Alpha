using UnityEngine;
using ScriptLibrary.Singletons;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI streakText;
    
    private int _streak = 0;
    private int _score = 0;

    public void AddScore(int points)
    {
        _score += points;
        _streak++;
        
        UpdateScore();
        UpdateStreak();
    }
    public void ResetStreak()
    {
        _streak = 0;
    }

    private void UpdateStreak()
    {
        if (_streak == 0)
        {
            streakText.text = "";
            return;
        }
        streakText.text = $"x{_streak}";
    }

    private void UpdateScore()
    {
        scoreText.text = _score.ToString();
    }
}
