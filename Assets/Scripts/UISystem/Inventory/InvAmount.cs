using System.Linq;
using TMPro;
using UnityEngine;

public class InvAmount : MonoBehaviour
{
    [SerializeField]private TMP_Text invAmount;
    [SerializeField]private MainInventory inventory;
    public float currentItemAmount;
    public float maxAmount;
    void Update()
    {
        SetCurrentInvSlot();
    }
    public void SetCurrentInvSlot()
    {
        currentItemAmount = inventory.items.Count(items => items != null);
        maxAmount = inventory.items.Count;
        invAmount.text = $"{currentItemAmount} / {maxAmount}";   
    }
}
