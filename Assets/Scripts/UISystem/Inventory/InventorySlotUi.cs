using UnityEngine;

public class InventorySlotUi : MonoBehaviour
{
    public int index;
    public MainInventory inventory;

    public void OnDropButtonPressed()
    {
        inventory.ItemCheck(index);
    }
}
