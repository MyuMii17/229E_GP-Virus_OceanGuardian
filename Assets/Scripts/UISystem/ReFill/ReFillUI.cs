using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReFillUI : MonoBehaviour
{
    public GameObject pressToFill;
    public InputAction interactAction;
    [SerializeField]private FuelSystem fuel;
    [SerializeField]private MainInventory inventory;
    private int currentMoney = 0;
    public int fuelPrice = 10;
    private bool isInTriggerRefill;
    private bool isPress;
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }
    void Update()
    {
        currentMoney = inventory.currentMoney;
        isPress = interactAction.WasPressedThisFrame();

        if (isPress && isInTriggerRefill && fuel.currentFuel != fuel.maxFuel && currentMoney >= fuelPrice)
        {
            inventory.currentMoney -= fuelPrice;
            fuel.currentFuel = fuel.maxFuel;
        }
        else if (isPress && isInTriggerRefill && fuel.currentFuel == fuel.maxFuel)
        {
            Debug.Log("You Fuel Is Max");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressToFill.SetActive(true);
            isInTriggerRefill = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressToFill.SetActive(false);
            isInTriggerRefill = false;
        }
    }
}
