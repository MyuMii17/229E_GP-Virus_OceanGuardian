using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReFillUI : MonoBehaviour
{
    public GameObject pressToFill;
    public InputAction interactAction;
    [SerializeField]private FuelSystem fuel;
    private bool isInTriggerRefill;
    private bool isPress;
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }
    void Update()
    {
        isPress = interactAction.WasPressedThisFrame();

        if (isPress && isInTriggerRefill && fuel.currentFuel != fuel.maxFuel)
        {
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
