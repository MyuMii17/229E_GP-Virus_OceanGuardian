using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scene Settings")] 
    [SerializeField] int mainMenuSceneIndex = 2;
    [SerializeField] int gameMenuSceneIndex = 3;
    public MonoBehaviour menuSystem;
    public GameObject Menu;
    public GameObject assest;
    public GameObject assestButton;
    public GameObject groupName;
    public GameObject groupNameButton;
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
    public void Assest()
    {
        assest.SetActive(true);
        groupName.SetActive(false);
        groupNameButton.SetActive(true);
        assestButton.SetActive(false);
        
    }
    public void GroupName()
    {
        groupName.SetActive(true);
        assest.SetActive(false);
        assestButton.SetActive(true);
        groupNameButton.SetActive(false);
    }
}
