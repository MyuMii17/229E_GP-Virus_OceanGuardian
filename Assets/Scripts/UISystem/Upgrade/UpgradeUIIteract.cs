using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeUIIteract : MonoBehaviour
{
    [SerializeField]private GameObject upgradPanel;
    [SerializeField]private MainInventory inv;
    [SerializeField]private FuelSystem fuel;
    public GameObject pressToUpgrade;
    private InputAction interactAction;
    private bool isInTriggerUpgrade;
    private bool isPress;
    private int maxSlotUpgrad = 1;
    private float maxFuelUpgrad = 50f;
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }
    void Update()
    {
        isPress = interactAction.WasPressedThisFrame();

        if (isPress && isInTriggerUpgrade && inv.maxSlot != 0 && fuel.maxFuel != 0)
        {
            Upgrade();
        }
    }
    public void Upgrade()
    {
        fuel.maxFuel += maxFuelUpgrad;
        inv.IncreaseSlot(1);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressToUpgrade.SetActive(true);
            isInTriggerUpgrade = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressToUpgrade.SetActive(false);
            isInTriggerUpgrade = false;
        }
    }
}
