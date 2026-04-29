using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadSNA()
    {
        SceneManager.LoadScene("SevenNationArmy");
    }

    public void LoadNFA()
    {
        SceneManager.LoadScene("NeverFadeAway");
    }
    public void LoadSA()
    {
        SceneManager.LoadScene("StepAhead");
    }

    public void MusicSelect()
    {
        SceneManager.LoadScene("MusicSelect");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); 
    }
}
