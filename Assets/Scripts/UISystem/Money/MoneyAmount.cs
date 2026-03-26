using TMPro;
using UnityEngine;

public class MoneyAmount : MonoBehaviour
{
    [SerializeField]private TMP_Text moneyAmount;
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
    }
}
