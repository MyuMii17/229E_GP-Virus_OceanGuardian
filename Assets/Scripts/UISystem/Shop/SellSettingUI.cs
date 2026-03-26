using UnityEngine;
using UnityEngine.InputSystem;

public class SellSettingUI : MonoBehaviour
{
    private InputAction interractAction;
    public GameObject IsSellPanel;
    public GameObject SellPanel;
    public MonoBehaviour ThirdPersonCamera;
    public MonoBehaviour PlayerController;
    bool isOpen = false;
    bool isInTriggerShop;
    bool isPress;
    void Start()
    {
        interractAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        isPress = interractAction.WasPressedThisFrame();
        if(isPress && isInTriggerShop)
        {
            ToggleSetting();
        }
    }
    void ToggleSetting()
    {
        isOpen = !isOpen;

        SellPanel.SetActive(isOpen);
        ThirdPersonCamera.enabled = !isOpen;
        PlayerController.enabled = !isOpen;
        

        if (isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsSellPanel.SetActive(true);
            isInTriggerShop = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsSellPanel.SetActive(false);
            isInTriggerShop = false;
        }
    }
}
