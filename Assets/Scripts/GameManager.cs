using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isPaused = false;
    public GameObject[] UIs;

    void Awake()
    {
        Instance = this;
    }
    public void SetOffOpenUI()
    {
        foreach (var ui in UIs)
        {
            ui.SetActive(false);
        }
    }
    public void PauseGame(GameObject targetUI)
    {
        isPaused = true;
        targetUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame(GameObject targetUI)
    {
        targetUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
