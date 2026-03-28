using UnityEngine;
using UnityEngine.InputSystem;

public class MenuSystem : MonoBehaviour
{
    private bool isMenuTrigger = false;
    [SerializeField]private GameManager gameManager;

    private InputAction mainmenuAction;
    public GameObject menuUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainmenuAction = InputSystem.actions.FindAction("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (mainmenuAction.WasPressedThisFrame()&&gameManager.isPaused != true)
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        GameManager.Instance.SetOffOpenUI();
        GameManager.Instance.PauseGame(menuUI);
    }
}
