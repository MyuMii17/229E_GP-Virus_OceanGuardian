using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShopSettingUI : MonoBehaviour
{
    [SerializeField]private MainInventory inventory;
    [SerializeField]private ItemGetInventory itemGet;
    [SerializeField]private GameObject shopPanel;
    [SerializeField]private GameObject MainPanel;
    [SerializeField]private GameObject sellPanel;
    [SerializeField]private GameObject upgradPanel;
    [SerializeField]private GameObject ClosrShop;
    [SerializeField]private MainInventory inv;
    [SerializeField]private FuelSystem fuel;
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

    private bool isInTriggerUpgrade;
    private int maxSlotUpgrad = 1;
    private float maxFuelUpgrad = 50f;
    private int currentMoney = 0;
    public int currenPriceSlot = 10;
    public int currenPriceMaxFuel = 15;
    private int slotPriceIncrease = 15;
    private int maxFuelPriceIncrease = 20;

    void Start()
    {
        interractAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        currentMoney = inventory.currentMoney;

        isPress = interractAction.WasPressedThisFrame();
        if(isPress && isInTriggerShop)
        {
            ToggleShop();
        }
        bool isShopOpen = shopPanel.activeSelf;
        if (!isShopOpen)
        {
            MainPanel.SetActive(true);
            upgradPanel.SetActive(false);
            sellPanel.SetActive(false);
            ClosrShop.SetActive(true);
        }
    }
    void ToggleShop()
    {
        GameManager.Instance.SetOffOpenUI();
        GameManager.Instance.PauseGame(shopPanel);
    }
    public void Upgrade()
    {
        if (isPress && isInTriggerUpgrade && inv.maxSlot != 0 && fuel.maxFuel != 0)
        {
            PressUpgrade();
        }
    }
    public void PressUpgrade()
    {
        MainPanel.SetActive(false);
        upgradPanel.SetActive(true);
        sellPanel.SetActive(false);
        ClosrShop.SetActive(false);
    }
    public void UpgradeSlot()
    {
        if(currentMoney >= currenPriceSlot)
        {
            inventory.currentMoney -= currenPriceSlot;
            inv.IncreaseSlot(1);
            currenPriceSlot += slotPriceIncrease;
        }
    }
    public void UpgradeMaxFuel()
    {
        if(currentMoney >= currenPriceMaxFuel)
        {
            inventory.currentMoney -= currenPriceMaxFuel;
            fuel.maxFuel += maxFuelUpgrad;
            currenPriceMaxFuel += maxFuelPriceIncrease;

        }
    }
    public void PressSell()
    {
        MainPanel.SetActive(false);
        upgradPanel.SetActive(false);
        sellPanel.SetActive(true);
        ClosrShop.SetActive(false);
        OnSellItem();
    }
    public void PressDone()
    {
        MainPanel.SetActive(true);
        ClosrShop.SetActive(true);
        upgradPanel.SetActive(false);
        sellPanel.SetActive(false);
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
