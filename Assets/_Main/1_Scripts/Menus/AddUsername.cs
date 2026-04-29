using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddUsername : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;


    public void AddName()
    {
        string playerName = inputField.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString("PlayerName", playerName);
            Debug.Log($"Player name set to: {playerName}");
        }
        else
        {
            Debug.LogWarning("Player name cannot be empty");
        }

        SceneManager.LoadScene("_Main/0_Scenes/Main menu/MusicSelect");
    }
}
