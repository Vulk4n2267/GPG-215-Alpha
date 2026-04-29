using UnityEngine;
using ScriptLibrary.Singletons;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI streakText;
    
    [SerializeField] private Animator scoreAnimator;
    [SerializeField] private Animator streakAnimator;
    
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
        streakAnimator.Play("StreakTextPopUp", 0, 0f);
    }

    private void UpdateScore()
    {
        scoreText.text = _score.ToString();
        scoreAnimator.Play("ScoreTextPopUp", 0, 0f);
    }

    public void EndGame()
    {
        PlayerPrefs.SetInt("Score", _score);
        PlayerPrefs.SetInt("Streak", _score);
        SceneManager.LoadScene("_Main/0_Scenes/Main menu/LeaderBoard");
    }
}
