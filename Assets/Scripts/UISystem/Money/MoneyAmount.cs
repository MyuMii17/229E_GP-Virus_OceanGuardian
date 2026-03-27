using TMPro;
using UnityEngine;

public class MoneyAmount : MonoBehaviour
{
    [SerializeField]private TMP_Text moneyAmount;
    [SerializeField]private TMP_Text slotPrice;
    [SerializeField]private TMP_Text maxFuelPrice;
    [SerializeField]private ShopSettingUI shopSetting;
    [SerializeField]private MainInventory inventory;
    public float currentMoneyAmount;
    public float maxMoneyAmount;
    void Update()
    {
        SetCurrentMoney();
    }
    public void SetCurrentMoney()
    {
        currentMoneyAmount = inventory.currentMoney;
        maxMoneyAmount = inventory.maxMoney;
        moneyAmount.text = $"{currentMoneyAmount}";
        slotPrice.text = $"${shopSetting.currenPriceSlot}";
        maxFuelPrice.text = $"${shopSetting.currenPriceMaxFuel}";
    }
}
