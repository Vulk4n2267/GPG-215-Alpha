using UnityEngine;
using TMPro;
public class LeaderBoardEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public void SetEntry(int rank, string playerName, int score)
    {
        rankText.text = $"#{rank}";
        playerNameText.text = playerName;
        scoreText.text = score.ToString();
    }
}
