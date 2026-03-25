using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Uimanage : MonoBehaviour
{
    private InputAction invAction;
    public GameObject InvPanel;
    public GameObject CursorUI;
    public MonoBehaviour FirstPersonCamera;
    public MonoBehaviour PlayerController;
    bool isOpen = false;
    public void Start()
    {
        invAction = InputSystem.actions.FindAction("Inventory");
        invAction.Enable();
    }
    void Update()
    {
        bool isHideInv = invAction.WasPressedThisFrame();
        if (isHideInv)
        {
            ToggleInventory();
        }
    }
    void ToggleInventory()
    {
        isOpen = !isOpen;
        InvPanel.SetActive(isOpen);
        
        CursorUI.SetActive(!isOpen);
        FirstPersonCamera.enabled = !isOpen;
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
}
