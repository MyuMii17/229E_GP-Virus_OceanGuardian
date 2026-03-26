using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SellSettingUI : MonoBehaviour
{
    [SerializeField]private MainInventory inventory;
    [SerializeField]private ItemGetInventory itemGet;
    public TMP_Text sellAmount;
    private InputAction interractAction;
    public GameObject IsSellPanel;
    public GameObject SellPanel;
    public MonoBehaviour ThirdPersonCamera;
    public MonoBehaviour PlayerController;
    public int TotalItemPrice = 0;
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
        OnSellItem();
        GameManager.Instance.SetOffOpenUI();
        GameManager.Instance.PauseGame(SellPanel);
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
    public void CloseSell()
    {
        GameManager.Instance.SetOffOpenUI();
        GameManager.Instance.ResumeGame(SellPanel);
    }
    public void OnSellItem()
    {
        inventory.AddNull();
        TotalItemPrice = itemGet.currentItemPrice;
        sellAmount.text = TotalItemPrice.ToString();
        inventory.Money(TotalItemPrice);
        itemGet.currentItemPrice = 0;
    }
}
