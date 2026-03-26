using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Scene Settings")] 
    [SerializeField] int gameSceneIndex = 1;
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
        GameManager.Instance.ResumeGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

