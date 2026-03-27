using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scene Settings")] 
    [SerializeField] int mainMenuSceneIndex = 0;
    [SerializeField] int gameMenuSceneIndex = 1;
    public MonoBehaviour menuSystem;
    public GameObject Menu;
    public void Resume()
    {
        GameManager.Instance.SetOffOpenUI();
        GameManager.Instance.ResumeGame(Menu);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameMenuSceneIndex);
    }
}
