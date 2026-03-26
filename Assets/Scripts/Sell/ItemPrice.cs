using UnityEngine;

public class ItemPrice : MonoBehaviour
{
    public int currentItemPrice;
    [SerializeField]private ItemData itemData;
    void Start()
    {
        currentItemPrice = Random.Range(itemData.minPrice, itemData.maxPrice);
    }
}
