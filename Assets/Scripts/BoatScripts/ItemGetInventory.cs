using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemGetInventory : MonoBehaviour
{
    private MainInventory inventory;
    [SerializeField]private ItemDetail itemDetail;
    [SerializeField]private FuelSystem fuelSystem;
    public int currentItemPrice = 0;
    public float addFuel = 0f;
    public AudioSource pickSound;
    public AudioSource fuelSound;
    
    void Start()
    {
        inventory = GetComponent<MainInventory>();
        fuelSystem = GetComponent<FuelSystem>();
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
                itemDetail = collider.GetComponent<ItemDetail>();
                currentItemPrice += itemDetail.currentItemPrice;

            }
            else if(collider.CompareTag("fuel"))
            {
                var forntObject = collider.GetComponent<ItemPick>();
                itemDetail = collider.GetComponent<ItemDetail>();
                addFuel += itemDetail.addFuel;
                if (forntObject != null)
                {
                    fuelSystem.currentFuel += addFuel;
                }
                addFuel = 0;
                Destroy(collider.gameObject);
            }
    }
}
