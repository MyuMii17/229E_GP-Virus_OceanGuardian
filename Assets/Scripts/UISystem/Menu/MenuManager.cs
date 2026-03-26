using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scene Settings")] 
    [SerializeField] int mainMenuSceneIndex = 0;
    public MonoBehaviour menuSystem;
    public GameObject Menu;
    public void Resume()
    {
        Menu.SetActive(false);
        GameManager.Instance.ResumeGame();
        gameObject.SetActive(false);
    }
    public void MainMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
