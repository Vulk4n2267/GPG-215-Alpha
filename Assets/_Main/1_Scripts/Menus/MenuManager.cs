using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("SevenNationArmy");
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
