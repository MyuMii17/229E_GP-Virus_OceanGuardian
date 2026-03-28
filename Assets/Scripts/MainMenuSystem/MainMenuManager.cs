using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Scene Settings")] 
    [SerializeField] int gameSceneIndex = 3;
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

