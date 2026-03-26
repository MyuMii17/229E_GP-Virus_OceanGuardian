using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemGetInventory : MonoBehaviour
{
    private MainInventory inventory;
    [SerializeField]private ItemPrice itemPrice;
    public int currentItemPrice = 0;
    
    void Start()
    {
        inventory = GetComponent<MainInventory>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Items"))
            {
                var forntObject = collider.GetComponent<ItemPick>();
                if (forntObject != null && forntObject.item.isItem)
                {
                    forntObject.OnPickItem(inventory);
                }
                itemPrice = collider.GetComponent<ItemPrice>();
                currentItemPrice += itemPrice.currentItemPrice;
            }
    }
}
